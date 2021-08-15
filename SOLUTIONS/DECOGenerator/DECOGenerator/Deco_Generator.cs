
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
using System.Threading.Tasks;
using System.Windows.Forms;

namespace DECOGenerator
{
    public partial class Deco_Generator : Form
    {
        public Deco_Generator()
        {
            InitializeComponent();
        }



        System.Data.DataTable table = new System.Data.DataTable();
        private void Deco_Generator_Load(object sender, EventArgs e)
        {
            //This fields should be created dinamicaly in future.

            table.Columns.Add("DIST-INST", typeof(string));
            table.Columns.Add("SCHL-INST", typeof(string));
            table.Columns.Add("YEAR", typeof(string));
            table.Columns.Add("SUR", typeof(string));
            table.Columns.Add("DIST NAME", typeof(string));
            table.Columns.Add("LAST NAME", typeof(string));
            table.Columns.Add("FIRST NAME", typeof(string));
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
            table.Columns.Add("CLAIM", typeof(string));

            dataGridView1.DataSource = table;


        }


        //The event over this button was desable.
        private void Button_Import_Click(object sender, EventArgs e)
        {

            saveFileDialog1.Title = "Select the DECO file";
            saveFileDialog1.Filter = "Text Files (*.txt)|*.txt" + "|" +
                    "Excel Files (*.xlsx)|*.xlsx" + "|" +
                    "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                    "All Files (*.*)|*.*";
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = saveFileDialog1.InitialDirectory;
            }
        }

        //Import Text file to DataGrid View.
        private void OpenTool_StripMenuItem_Click(object sender, EventArgs e)
        {

            openFileDialog1.Title = "Select the DECO file";
            openFileDialog1.Filter = "Text Files (*.txt)|*.txt" + "|" +
                    "Excel Files (*.xlsx)|*.xlsx " + "|" +
                    "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                    "All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
            }
        }

        private void ExitTool_StripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure you want to Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                
                System.Windows.Forms.Application.ExitThread();
            }

        }

        //Method for copying all data from DataGridView.
        public void CopyAllToClipboard()
        {
            dataGridView1.SelectAll();
            var dataObject = dataGridView1.GetClipboardContent();
            if (dataObject != null)
            {
                Clipboard.SetDataObject(dataObject);
            }
        }

        private void releaseObject(object obj)
        {

        }



        // Export DataGrid View to Excel file. Package Microsoft.Office.Interop.Excel need to be isntalled.
        private void ExportTool_StripMenuItem_Click(object sender, EventArgs e)
        {
            /*CopyAllToClipboard();
            Microsoft.Office.Interop.Excel.Application xlexel = new Microsoft.Office.Interop.Excel.Application();
            Microsoft.Office.Interop.Excel.Workbook xlWorkBook;
            Microsoft.Office.Interop.Excel.Worksheet xlWorkSheet;

            xlexel.Visible = true;*/
            using (SaveFileDialog sfd = new SaveFileDialog() 
            {
                Filter = saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx" + "|" +
                      "Text Files (*.txt)|*.txt" + "|" +
                     "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                     "All Files (*.*)|*.*",
                Title = saveFileDialog1.Title = "Save as Excel file"
            })

            {
                if (saveFileDialog1.ShowDialog() != DialogResult.Cancel)
                {

                    
                    try
                    {
                        Microsoft.Office.Interop.Excel.Application ExcelApp = new Microsoft.Office.Interop.Excel.Application();
                        ExcelApp.Application.Workbooks.Add(Type.Missing);

                        ExcelApp.Columns.ColumnWidth = 20;

                        //storing header part in excel.
                        for (int i = 1; i < dataGridView1.Columns.Count; i++)
                        {
                            ExcelApp.Cells[1, i] = dataGridView1.Columns[i - 1].HeaderText;
                        }

                        //storing each row and column value to excel.

                        for (int i = 0; i < dataGridView1.Rows.Count; i++)
                        {
                            for (int j = 0; j < dataGridView1.Columns.Count; j++)
                            {
                                ExcelApp.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value.ToString();
                            }
                        }

                        ExcelApp.ActiveWorkbook.SaveCopyAs(saveFileDialog1.FileName.ToString());
                        ExcelApp.ActiveWorkbook.Saved = true;
                        ExcelApp.Quit();

                        var customMessageBox = new MessageBox();
                        customMessageBox.

                        //customMessageBox.Show("You have successfully exported your data.", "Message",MessageBoxButtons.OK, MessageBoxIcon.Information);

                    }
                    catch (Exception ex)
                    {

                        MessageBox.Show(ex.Message, "The operation could not be completed.", MessageBoxButtons.OK, MessageBoxIcon.Error);
                    }

                    
                }
            
            }

            /*     saveFileDialog1.Title = 
             saveFileDialog1.Filter = "Excel Files (*.xlsx)|*.xlsx" + "|" +
                      "Text Files (*.txt)|*.txt" + "|" +
                     "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                     "All Files (*.*)|*.*";
             saveFileDialog1.InitialDirectory = Environment.GetFolderPath(Environment.SpecialFolder.MyDocuments);

             */

            /* This method doesn't work.
             * 
             * DataTable data = table;
             var excel = new OfficeOpenXml.ExcelPackage();
             var ws = excel.Workbook.Worksheets.Add("worksheet-name");
             // you can also use LoadFromCollection with an `IEnumerable<SomeType>`
             ws.Cells["A1"].LoadFromDataTable(data, true, OfficeOpenXml.Table.TableStyles.Light1);
             ws.Cells[ws.Dimension.Address.ToString()].AutoFitColumns();

             using (var file = File.Create(saveFileDialog1.FileName))
                 excel.SaveAs(file);
            */
            /*
            if (sfd.Rows.Count > 0)
            {
                Microsoft.Office.Interop.Excel.Application excelExport = new Microsoft.Office.Interop.Excel.Application();
                excelExport.Application.Workbooks.Add(Type.Missing);
                for (int i = 0; i < dataGridView1.Columns.Count + 1; i++)
                {
                    excelExport.Cells[1, i] = "dasdas";
                }

                for (int i = 0; i < dataGridView1.Rows.Count; i++)
                {
                    for (int j = 0; j <  dataGridView1.Columns.Count; j++)
                    {
                        excelExport.Cells[i + 2, j + 1] = dataGridView1.Rows[i].Cells[j].Value;
                    }
                }

                excelExport.Columns.AutoFit();
                excelExport.Visible = true;
            }

        */
        }

        private void topMenuStrip_ItemClicked(object sender, ToolStripItemClickedEventArgs e)
        {

        }
    }

}

