﻿
using CLAIMGenerator;
using ClosedXML.Excel;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Net.NetworkInformation;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DECOGenerator
{
    public partial class Claim_Generator : Form
    {
        public List<string> layoutFieldsList { get; set; }

        public Claim_Generator()
        {
            InitializeComponent();
            UpdateSubtitle(); // Display initial value

            advancedDataGridView1.RowsAdded += (sender, args) => UpdateSubtitle();
            advancedDataGridView1.RowsRemoved += (sender, args) => UpdateSubtitle();
            advancedDataGridView1.ColumnAdded += (sender, args) => UpdateSubtitle();
            advancedDataGridView1.ColumnRemoved += (sender, args) => UpdateSubtitle();

        }

        //Updating row and column counter
        private void UpdateSubtitle()
        {
            Total.Text = advancedDataGridView1.RowCount.ToString();
            TotalF.Text = advancedDataGridView1.ColumnCount.ToString();
        }

        // removing from string array items with value equal "" (spaces).
        private string[] removeSpaces(string[] data)
        {
            var list = new List<string>();

            foreach (var item in data)
            {
                if (item != "")
                {

                    list.Add(item);
                }
            }

            return list.ToArray();
        }

       readonly System.Data.DataTable table = new System.Data.DataTable();
        private void Claim_File_Generator_Load(object sender, EventArgs e)
        {
            //This fields should be created dinamicaly throughout that Layout defined (grab data from db.)

            layoutFieldsList = new List<string> {"DIST-INST","SCHL-INST","YEAR","SURVEY","DIST NAME","LAST NAME","FIRST NAME","BIRTH DATE",
                                          "AGE", "GRADE","DIST","SCHL","SORT-IND","FLEID","COURSE","SECTION","B-PERIOD","E-PERIOD",
                                                  "FEFP","FTE","MINS","SCHL-FTE","TERM","FTE-CALAB","CALCUL","PRORATE-ID","FUND-GROUP","DUAL-ENRL",
                                                  "FTE-VIRT_EST","MIDDLE NAME","SEX","CLAIM" };

            foreach (var item in layoutFieldsList)
            {
                                
                table.Columns.Add(item, typeof(string));
                
            }
            advancedDataGridView1.DataSource = table;

            

        }
       
        //Import Text file to DataGrid View.
        private void OpenTool_StripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialogBox.Title = "Select the DECO file";
            openFileDialogBox.Filter ="Text Files (*.txt)|*.txt" + "|" +
                                      "Excel Files (*.xlsx)|*.xlsx " + "|" +
                                      "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                                      "All Files (*.*)|*.*";

            if (openFileDialogBox.ShowDialog() == DialogResult.OK)
            {
                try
                {
                    var lines = File.ReadAllLines(openFileDialogBox.FileName.ToString());

                    string[] data;

                    for (int i = 0; i < lines.Length; i++)                    
                    {

                        //Using extension method to insert string in a given list of position indexs.
                        
                        string line = lines[i].ToString().InsertInPositions(new List<int> {2,8,13,15,38,56,69,78,81,84,87,107,109,124,132,138,141,144,148,154,159,164,166,172,174,184,186,188,194,205}, "/");                       
                        
                        //Create new string array splitting by character.
                        data = line.ToString().Split("/");
                                                
                        //string[] newData = removeSpaces(data);
                        
                        string[] row = new string[data.Length];
                         
                        for (int z = 0; z < data.Length ; z++)
                        {
                            row[z] = data[z].Trim();
                        }

                        table.Rows.Add(row);
                    }

                    MessageBox.Show("Your data have been imported successfuly.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex )
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }            

            }
        }

        //Exit functionality option.
        private void ExitTool_StripMenuItem_Click(object sender, EventArgs e)
        
        {
            if (MessageBox.Show("Are You Sure you want to Exit?", "Exit", MessageBoxButtons.OKCancel, MessageBoxIcon.Information) == DialogResult.OK)
            {
                System.Windows.Forms.Application.ExitThread();
            }

        }

        //Method for copying all data from DataGridView is not in use.
        public void CopyAllToClipboard()
        {
            advancedDataGridView1.SelectAll();
            var dataObject = advancedDataGridView1.GetClipboardContent();
            if (dataObject != null)
            {
                Clipboard.SetDataObject(dataObject);
            }
        }

        // Export DataGrid View to Excel file. Package Microsoft.Office.Interop.Excel need to be isntalled.
        private void ExportTool_StripMenuItem_Click(object sender, EventArgs e)
        {
            if (backgroundWorker.IsBusy)
                return;

            using (SaveFileDialog sfd = new SaveFileDialog() 
            {
                Filter = saveFileDialogBox.Filter = "Excel Files (*.xlsx)|*.xlsx" + "|" +
                      "Text Files (*.txt)|*.txt" + "|" +
                     "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                     "All Files (*.*)|*.*",
                Title = saveFileDialogBox.Title = "Save as Excel file"
            })

            {
                if (saveFileDialogBox.ShowDialog() != DialogResult.Cancel)
                {
                    progressBar1.Minimum = 0;
                    progressBar1.Value = 0;
                    backgroundWorker.RunWorkerAsync(sfd.FileName);

                }
            
            }
 
        } 

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int processCount = advancedDataGridView1.Rows.Count;
            int index = 1;
            var ExcelApp = new Microsoft.Office.Interop.Excel.Application();
            
                try
                {
                    //Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                    ExcelApp.Application.Workbooks.Add(Type.Missing);

                    if (!backgroundWorker.CancellationPending)
                    {
                        //storing header part in excel.
                        for (int i = 1; i < advancedDataGridView1.Columns.Count; i++)
                        {
                            ExcelApp.Cells[1, i] = advancedDataGridView1.Columns[i - 1].HeaderText;
                        }
                        //storing each row and column value to excel.

                        for (int i = 0; i < advancedDataGridView1.Rows.Count; i++)
                        {

                            for (int j = 0; j < advancedDataGridView1.Columns.Count; j++)
                            {
                                ExcelApp.Cells[i + 2, j + 1] = advancedDataGridView1.Rows[i].Cells[j].Value.ToString();

                            }
                            //Progress bar counter incremental.    
                            backgroundWorker.ReportProgress((index++) * 100 / processCount);
                        }
                    }

                    ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialogBox.FileName.ToString());
                    ExcelApp.ActiveWorkbook.Saved = true;
                    ExcelApp.Quit();
                }
                catch (Exception ex)
                {
                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);

                }          
         }

        private void backgroundWorker_ProgressChanged(object sender, ProgressChangedEventArgs e)
        {
            progressBar1.Value = e.ProgressPercentage;
            lablStatusBar.Text = string.Format("Processing...{0} %", e.ProgressPercentage);
            progressBar1.Update();
        }

        private void backgroundWorker_RunWorkerCompleted(object sender, RunWorkerCompletedEventArgs e)
        {
            if (e.Error == null)
            {
                Thread.Sleep(100);

                MessageBox.Show("You have successfully exported your data.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);
            }
        }

        DataTable OrignalADGVdt = null;
        private void advancedDataGridView1_FilterStringChanged(object sender, EventArgs e)
        {
            
            var fdgv = advancedDataGridView1;
            DataTable dt = null;
            if (OrignalADGVdt == null)
            {
                OrignalADGVdt = (DataTable)fdgv.DataSource;
            }
            if (fdgv.FilterString.Length > 0)
            {
                dt = (DataTable)fdgv.DataSource;
            }
            else//Clear Filter
            {
                dt = OrignalADGVdt;
            }

            fdgv.DataSource = dt.Select(fdgv.FilterString).CopyToDataTable();

        }

        private void advancedDataGridView1_SortStringChanged(object sender, EventArgs e)
        {
            
        }
    }

}

