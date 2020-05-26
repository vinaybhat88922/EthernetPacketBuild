using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;
using System.IO;

namespace Form1
{

    public partial class Form2 : Form
    {
        private static Microsoft.Office.Interop.Excel.Workbook mWorkBook;
        private static Microsoft.Office.Interop.Excel.Sheets mWorkSheets;
        private static Microsoft.Office.Interop.Excel.Worksheet mWSheet1;
        private static Microsoft.Office.Interop.Excel.Application oXL;
        
        public Form2()
        {

            InitializeComponent();
        }
        private Form1 mainForm = null;
  public Form2(Form callingForm)
   {
          mainForm = callingForm as Form1;
          InitializeComponent();
   }
        public void textBox1_TextChanged(object sender, EventArgs e)
        {


        }

        public void Form2_Load(object sender, EventArgs e)
        {

        }

        public void textBox2_TextChanged(object sender, EventArgs e)
        {

        }

        internal void textBox1_TextChanged()
        {
            throw new NotImplementedException();
        }

        private void button1_Click(object sender, EventArgs e)
        {
          

            string path = @"D:\NYT_Lasttry\MyConfigScapy.xls";
            oXL = new Microsoft.Office.Interop.Excel.Application();
            oXL.Visible = true;
            oXL.DisplayAlerts = false;
            mWorkBook = oXL.Workbooks.Open(path, 0, false, 5, "", "", false, Microsoft.Office.Interop.Excel.XlPlatform.xlWindows, "", true, false, 0, true, false, false);
            //Get all the sheets in the workbook
            mWorkSheets = mWorkBook.Worksheets;
            //Get the allready exists sheet
            mWSheet1 = (Microsoft.Office.Interop.Excel.Worksheet)mWorkSheets.get_Item("Sheet1");
            Microsoft.Office.Interop.Excel.Range range = mWSheet1.UsedRange;

            mWSheet1.Cells[3, 2] = this.textBox1.Text;
            mWSheet1.Cells[4, 2] = this.textBox2.Text;

            mWorkBook.SaveAs(path, Microsoft.Office.Interop.Excel.XlFileFormat.xlWorkbookNormal,
System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value, Microsoft.Office.Interop.Excel.XlSaveAsAccessMode.xlExclusive,
System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value,
System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            mWorkBook.Close(System.Reflection.Missing.Value, System.Reflection.Missing.Value, System.Reflection.Missing.Value);
            mWSheet1 = null;
            mWorkBook = null;
            oXL.Quit();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();



            this.mainForm.label1.Text ="IP = " + this.textBox1.Text; ;
            this.mainForm.label2.Text = "Payload = " + this.textBox2.Text; ;



            int ExitCode;
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = "D:\\NYT_Lasttry\\batch.bat";
            p.Start();

p.WaitForExit();
ExitCode = p.ExitCode;
p.Close();











            this.Close();

        }

        private void label1_Click(object sender, EventArgs e)
        {

        }
    }
}
