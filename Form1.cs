using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Text;
using System.Windows.Forms;
using System.IO;

namespace Car_Parking
{
    public partial class Form1 : Form
    {
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            //Add
            StreamWriter sr = new StreamWriter("a.txt", true);
            
            sr.WriteLine(textBox1.Text);
            sr.WriteLine(textBox2.Text);
            sr.WriteLine(textBox3.Text);
            sr.WriteLine(textBox4.Text);

            sr.Close();

            textBox1.Text = "";
            textBox2.Text = "";
            textBox3.Text = "";
            textBox4.Text = "";

        }

        private void button2_Click(object sender, EventArgs e)
        {
            //List
            StreamReader sr = new StreamReader("a.txt");

            while (!sr.EndOfStream)
            {
                listBox1.Items.Add(sr.ReadLine() + " , " + sr.ReadLine() + " , " + sr.ReadLine() + " , " + sr.ReadLine());
            }

            sr.Close();
        }

        private void button3_Click(object sender, EventArgs e)
        {
            //Search
            StreamReader sr = new StreamReader("a.txt");

            listBox2.Items.Clear();

            while (!sr.EndOfStream)
            {
                string s = sr.ReadLine();
                if (s == textBox5.Text)
                {
                    listBox2.Items.Add(sr.ReadLine() + " , " + s + " , " + sr.ReadLine() + " , " + sr.ReadLine());
                }
                else
                {
                    sr.ReadLine();
                    sr.ReadLine();
                    sr.ReadLine();
                }
            }
        }

        private void button4_Click(object sender, EventArgs e)
        {
            System.Diagnostics.Process.Start("http://WWw.SourceCodes.ir");
        }


    }
}