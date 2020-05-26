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
    public partial class Form1 : Form
    {
        Form2 form2 = new Form2();
        public static string IP = null;
        public static string payload = null;
        public Form1()
        {
            InitializeComponent();
          
        }

        public void Form1_Load(object sender, EventArgs e)
        {
            
            this.label2.Text = "Payload = Null";
            this.label1.Text = "IP = 127.0.0.1";
        }

        public void button1_Click(object sender, EventArgs e)
        {
            Form2 form2 = new Form2(this);
            form2.Show();
           
        }

        public void textBox1_TextChanged(object sender, EventArgs e)
        {
            
        }

        public void label1_Click(object sender, EventArgs e)
        {
           
        }

        public void label2_Click(object sender, EventArgs e)
        {

        }

        private void button2_Click(object sender, EventArgs e)
        {
            
            Process p = new Process();
            p.StartInfo.UseShellExecute = true;
            p.StartInfo.FileName = "D:\\NYT_Lasttry\\batch1.bat";
            p.Start();
            p.WaitForExit();
            p.Close();

        }
    }
}
