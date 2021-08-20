
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
    public partial class Deco_Generator : Form
    {
        public Deco_Generator()
        {
            InitializeComponent();
            UpdateSubtitle(); // Display initial value

            advancedDataGridView1.RowsAdded += (sender, args) => UpdateSubtitle();
            advancedDataGridView1.RowsRemoved += (sender, args) => UpdateSubtitle();
            advancedDataGridView1.ColumnAdded += (sender, args) => UpdateSubtitle();
            advancedDataGridView1.ColumnRemoved += (sender, args) => UpdateSubtitle();

        }

        private void UpdateSubtitle()
        {
            Total.Text = advancedDataGridView1.RowCount.ToString();
            TotalF.Text = advancedDataGridView1.ColumnCount.ToString();
        }



        
        System.Data.DataTable table = new System.Data.DataTable();
        private void Deco_Generator_Load(object sender, EventArgs e)
        {
            //This fields should be created dinamicaly throughout that Layout defined (grab data from db.)

            table.Columns.Add("DIST-INST", typeof(string));
            table.Columns.Add("SCHL-INST", typeof(string));
            table.Columns.Add("YEAR", typeof(string));
            table.Columns.Add("SUR", typeof(string));
            table.Columns.Add("DIST NAME", typeof(string));
            table.Columns.Add("LAST NAME", typeof(string));
            /*table.Columns.Add("FIRST NAME", typeof(string));
            table.Columns.Add("BIRTHDATE", typeof(string));
            table.Columns.Add("GRADE", typeof(string));
            table.Columns.Add("DIST", typeof(string));
            table.Columns.Add("SCHL", typeof(string));
            table.Columns.Add("SORT-IND", typeof(string));
            table.Columns.Add("FLEID", typeof(string));
            table.Columns.Add("COURSE", typeof(string));
            table.Columns.Add("SECTION", typeof(string));
            table.Columns.Add("B-PERIOD", typeof(string));
            table.Columns.Add("E-PERIOD", typeof(string));
            table.Columns.Add("FEFP", typeof(string));
            table.Columns.Add("FTE", typeof(string));
            table.Columns.Add("MINS", typeof(string));
            table.Columns.Add("SCHL-FTE", typeof(string));
            table.Columns.Add("TERM", typeof(string));
            table.Columns.Add("FTE-CALAB", typeof(string));
            table.Columns.Add("CALCUL", typeof(string));
            table.Columns.Add("PRORATE-ID", typeof(string));
            table.Columns.Add("FUND-GROUP", typeof(string));
            table.Columns.Add("DUAL-ENRL", typeof(string));
            table.Columns.Add("FTE-VIRT_EST", typeof(string));
            table.Columns.Add("MIDDLE NAME", typeof(string));
            table.Columns.Add("SEX", typeof(string));
            table.Columns.Add("CLAIM", typeof(string));*/

            // dataGridView1.DataSource = table;
            // advancedDataGridView1.DataSource = table;
            
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
                    string[] lines = File.ReadAllLines(openFileDialogBox.FileName.ToString());
                    string[] data;

                    for (int i = 0; i < lines.Length; i++)
                    {
                            
                        
                        data = lines[i].ToString().Split(' ');

                         string[] p = removeSpaces(data);
                        
                        string[] row = new string[p.Length];

                        for (int j = 0; j < p.Length; j++)
                        {

                            row[j] = p[j].Trim();

                        }

                        table.Rows.Add(row);
                    }


                    //----------------------------------------------------------------->

                    /*
                    var lines = File.ReadAllLines(openFileDialogBox.FileName.ToString());
                    string[] data;

                    for (int i = 0; i < lines.Length; i++)
                    {
                        data = lines[i].ToString().Split(" ");

                        string[] row = new string[data.Length];

                        for (int j = 0; j < data.Length; i++)
                        {
                            row[j] = data[j];
                        }

                        table2.Rows.Add(row);
                    }

                   // advancedDataGridView1.DataSource = dataTable2;*/


                    //-----------------------------------------------------------------------

                    MessageBox.Show("Your data have been imported successfuly.", "Message", MessageBoxButtons.OK, MessageBoxIcon.Information);

                }
                catch (Exception ex )
                {

                    MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
             

            }
        }

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

        private void ExitTool_StripMenuItem_Click(object sender, EventArgs e)
        
        {
            if (MessageBox.Show("Are You Sure you want to Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
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

                  /*
                   * try
                    {
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);

                        ExcelApp.Columns.ColumnWidth = 20;

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
                        }

                        ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialogBox.FileName.ToString());
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();
                        //backgroundWorker.RunWorkerAsync(sfd.FileName);

                    }
                    catch (Exception ex)
                    {
                        MessageBox.Show(ex.Message, "Error Message", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }
                  */
                    
                }
            
            }
 
        } 
     

        private void backgroundWorker_DoWork(object sender, DoWorkEventArgs e)
        {
            int process = advancedDataGridView1.Rows.Count;
            int index = 1;
            try
            {

                Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
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
                        backgroundWorker.ReportProgress(index++ * 100 / process);
                    }
                }
              

                ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialogBox.FileName.ToString());
                ExcelApp.ActiveWorkbook.Saved = true;
                ExcelApp.Quit();
                //backgroundWorker.RunWorkerAsync(sfd.FileName);

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
    }

}

