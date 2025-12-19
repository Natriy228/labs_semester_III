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

namespace Decoder
{
    public partial class Form1 : Form
    {
        ILogger logger = new LogLogger();
        IDecoder decoder = new ClassicDecoder();
        IEncoder encoder = new ClassicEncoder();
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            if (openFileDialog1.ShowDialog() == DialogResult.OK)
            {
                decoder.BeginWork(openFileDialog1.FileName);
                char nexts = decoder.DecodeNext();
                richTextBox1.Clear();
                while (nexts != '\0')
                {
                    richTextBox1.Text += nexts;
                    nexts = decoder.DecodeNext();
                }
                richTextBox1.Update();
                decoder.EndWork();
                logger.SendReport(Application.StartupPath, "Чтение файла завершено\n");
            }
            else
            {
                logger.SendReport(Application.StartupPath, "Файл не найден\n");
            }
        }

        private void button1_Click_1(object sender, EventArgs e)
        {
            if (saveFileDialog1.ShowDialog() == DialogResult.OK)
            {
                encoder.BeginWork(saveFileDialog1.FileName);
                for (int i = 0; i < richTextBox1.Text.Length; ++i)
                {
                    encoder.SendNext(richTextBox1.Text[i]);
                }
                encoder.EndWork();
                logger.SendReport(Application.StartupPath, "Запись файла завершена\n");
            }
            else
            {
                logger.SendReport(Application.StartupPath, "Файл не найден\n");
            }
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            //Добавление кодеков
            codeccb.Items.Add("Последовательный");
            codeccb.Items.Add("Шифр1");
            codeccb.Items.Add("Шифр2");
            //Добавление логгеров
            loggercb.Items.Add("Журнал");
            loggercb.Items.Add("Отчёт");
        }

        private void codeccb_SelectedValueChanged(object sender, EventArgs e)
        {
            switch (codeccb.SelectedIndex)
            {
                case 0: { decoder = new ClassicDecoder(); encoder = new ClassicEncoder(); break; }
                case 1: { decoder = new Crypt1Decoder(); encoder = new Crypt1Encoder(); break; }
                case 2: { decoder = new Crypt2Decoder(); encoder = new Crypt2Encoder(); break; }
            }
        }

        private void loggercb_SelectedIndexChanged(object sender, EventArgs e)
        {
            switch (loggercb.SelectedIndex)
            {
                case 0: { logger = new LogLogger(); break; }
                case 1: { logger = new ReportLogger(); break; }
            }
        }
    }
}
