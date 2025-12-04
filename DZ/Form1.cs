using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
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
        public Form1()
        {
            InitializeComponent();
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Graphics draw = pictureBox.CreateGraphics();
            SolidBrush brush = new SolidBrush(Color.FromArgb(255, 255, 255));
            Pen pen = new Pen(brush);
            Rectangle rect = new Rectangle();
            rect.X = 10; rect.Y = 10; rect.Width = 1; rect.Height = 1;
            decoder.BeginWork("C:\\Users\\dlyut\\OneDrive\\Desktop\\Учёба\\ОП\\Semester III\\DZ\\obj\\Debug\\Linear");
            int pixel = decoder.DecodeNext();
            int cx = 0; int cy = 0;
            while (pixel != -1)
            {
                rect.X = cx * 2; rect.Y = cy * 2;
                brush.Color = Color.FromArgb(pixel, pixel, pixel);
                pen.Brush = brush;
                draw.DrawRectangle(pen, rect);
                cx++;
                if (cx % 388 == 0)
                {
                    cy++;
                    cx = 0;
                }
                pixel = decoder.DecodeNext();
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
                case 0: { decoder = new ClassicDecoder(); break; }
                case 1: { decoder = new Crypt1Decoder(); break; }
                case 2: { decoder = new Crypt2Decoder(); break; }
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
