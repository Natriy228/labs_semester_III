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
                List<string> words = new List<string>();
                foreach (string i in File.ReadAllText(openFileDialog1.FileName).Split())
                {
                    words.Add(i);
                }

                List<int> dublicates = new List<int>();
                for (int i = 0; i < words.Count; i++)
                {
                    if (dublicates.Contains(i)) { continue; }
                    for (int b = 0; b < words.Count; b++)
                    {
                        if (words[i] == words[b] && b != i)
                        {
                            dublicates.Add(b);
                        }
                    }
                }
                foreach (int i in dublicates)
                {
                    words.RemoveAt(i);
                }

                foreach (string i in words)
                {
                    listBox1.Items.Add(i);
                }

            }
            else if (res1 == DialogResult.Cancel)
            {
                MessageBox.Show("Файл не был выбран!", "Ошибка", MessageBoxButtons.OK, MessageBoxIcon.Error);
            }
        }
    }
}
