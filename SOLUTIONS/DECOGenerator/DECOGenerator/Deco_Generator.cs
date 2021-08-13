using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
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



        DataTable table = new DataTable();
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
                    "Excel Files (*.xsl)|*.xsl" + "|" +
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
                    "Excel Files (*.xsl)|*.xsl" + "|" +
                    "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                    "All Files (*.*)|*.*";
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string file = openFileDialog1.FileName;
            }
        }

        private void ExitTool_StripMenuItem_Click(object sender, EventArgs e)
        {
            if (MessageBox.Show("Are You Sure To Exit?", "Exit", MessageBoxButtons.OKCancel) == DialogResult.OK)
            {
                Application.Exit();
            }

        }

        //Method for copying all data from DataGridView.
        public void CopyAllToClipboard ()
        {
            dataGridView1.SelectAll();
            var dataObject = dataGridView1.GetClipboardContent();
            if (dataObject!=null)
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


            openFileDialog1.Title = "Export data to";
            openFileDialog1.Filter = "Excel Files (*.xsl)|*.xsl" + "|" +
                     "Text Files (*.txt)|*.txt" + "|" +
                    "Image Files (*.png;*.jpg)|*.png;*.jpg" + "|" +
                    "All Files (*.*)|*.*";
            
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                string exportFile = openFileDialog1.InitialDirectory;
                MessageBox.Show(exportFile);

            }

            
        }

        private void dataGridView1_CellContentClick(object sender, DataGridViewCellEventArgs e)
        {

        }


        //Showing message on MouseHover event.
        private void Button_Import_MouseHover(object sender, EventArgs e)
        {
            toolTip1.Show("Select a file to import", button_Import);
        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        
    }
}
