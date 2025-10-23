using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CsharpWFPlaceholder
{
    public partial class Form1 : Form
    {
        System.Diagnostics.Stopwatch timer1 = new System.Diagnostics.Stopwatch();
        List<string> words = new List<string>();
        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            
        }

        private void button1_Click(object sender, EventArgs e)
        {
            DialogResult res1 = openFileDialog1.ShowDialog();
            if (res1 == DialogResult.OK)
            {
                timer1.Reset();
                timer1.Start();
                words.Clear();
                foreach (string i in File.ReadAllText(openFileDialog1.FileName).Split())
                {
                    if (!words.Contains(i))
                    {
                        words.Add(i);
                    }
                }
                while (words.Contains(""))
                {
                    words.Remove("");
                }

                listBox1.BeginUpdate();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (string i in words)
                {
                    string word = i;
                    foreach (char b in ".,?!")
                    {
                        word = word.Replace(b, '\0');
                    }
                    listBox1.Items.Add(word);
                }
                listBox1.EndUpdate();
                timer1.Stop();
                label1.Text = "Затраченное время: " + timer1.ElapsedMilliseconds.ToString() + " мс";
            }
            else if (res1 == DialogResult.Cancel)
            {
                MessageBox.Show("Файл не был выбран!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }

        private void button2_Click(object sender, EventArgs e)
        {
            string word = textBox1.Text;
            bool found = false;
            timer1.Reset();
            timer1.Start();
            foreach (string i in words)
            {
                if (i.Contains(word))
                {
                    listBox2.BeginUpdate(); //????????????
                    listBox2.Items.Add(word);
                    listBox2.EndUpdate();
                    found = true;
                    break;
                }
            }
            timer1.Stop();
            label5.Text = "Затраченное время: ";
            if (timer1.ElapsedMilliseconds == 0) { label5.Text += "<1 мс"; }
            else { label5.Text += timer1.ElapsedMilliseconds.ToString() + " мс" ; }
            if (!found) { label5.Text += " (Слово не найдено)"; }
            textBox1.Text = "";
        }
    }
}
