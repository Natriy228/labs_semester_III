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

        public int Levenstein(string s1, string s2)
        {
            List<List<int>> matrix = new List<List<int>>();
            List<int> first = new List<int>();
            for (int i = 0; i <= s1.Length; i++) { first.Add(i); }
            matrix.Add(first);
            for (int i = 1; i <= s2.Length; i++)
            {
                List<int> nextl = new List<int>();
                nextl.Add(i);
                for (int b = 1; b <= s1.Length; b++) { nextl.Add(0); }
                matrix.Add(nextl);
                for (int b = 1; b <= s1.Length; b++)
                {
                    int xl = matrix[i][b - 1] + 1;
                    int xu = matrix[i - 1][b] + 1;
                    int xd = matrix[i - 1][b - 1] + Convert.ToInt32(s1[b - 1] != s2[i - 1]);
                    matrix[i][b] = (Math.Min(Math.Min(xl, xu), xd));
                }
            }
            return matrix[s2.Length][s1.Length];
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
                    string word = i;
                    foreach (char b in ".,?!")
                    {
                        word = word.Replace(b, '\0');
                    }
                    word.ToLower();
                    if (!words.Contains(word))
                    {
                        words.Add(word);
                    }
                }
                while (words.Contains(""))
                {
                    words.Remove("");
                }

                listBox1.BeginUpdate();
                listBox2.BeginUpdate();
                listBox1.Items.Clear();
                listBox2.Items.Clear();
                foreach (string i in words)
                {
                    listBox1.Items.Add(i);
                }
                listBox1.EndUpdate();
                listBox2.EndUpdate();
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
            int Lev = Convert.ToInt32(textBox2.Text);
            foreach (string i in words)
            {
                if (Levenstein(word, i) <= Lev)
                {
                    listBox2.BeginUpdate(); //????????????
                    listBox2.Items.Add(i);
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
