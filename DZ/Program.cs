using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace Decoder
{
    //Объявление интерфейсов
    public interface IDecoder
    {
        void BeginWork(string filename);
        int DecodeNext();
    }
    public interface ILogger
    {
        void SendReport(string filename, string message);
    }
    //Создание классов
    public class ClassicDecoder : IDecoder
    {
        long current_pixel;
        byte[] readed_info;
        public void BeginWork(string filename)
        {
            readed_info = File.ReadAllBytes(filename);
            current_pixel = 0;
        }

        public int DecodeNext()
        {
            if (current_pixel < readed_info.Length)
            {
                byte to_return = readed_info[current_pixel];
                current_pixel += 1;
                return to_return;
            }
            else
            {
                return -1;
            }
        }
    }

    public class Crypt1Decoder : IDecoder
    {
        long current_pixel;
        byte[] readed_info;
        public void BeginWork(string filename)
        {
            readed_info = File.ReadAllBytes(filename);
            current_pixel = 0;
        }

        public int DecodeNext()
        {
            if (current_pixel < readed_info.Length)
            {
                byte to_return = Convert.ToByte(readed_info[current_pixel] - Convert.ToByte(4));
                current_pixel += 1;
                return to_return;
            }
            else
            {
                return -1;
            }
        }
    }

    public class Crypt2Decoder : IDecoder
    {
        long current_pixel;
        byte[] readed_info;
        public void BeginWork(string filename)
        {
            readed_info = File.ReadAllBytes(filename);
            current_pixel = 0;
        }

        public int DecodeNext()
        {
            if (current_pixel < readed_info.Length)
            {
                byte to_return = Convert.ToByte(readed_info[current_pixel] / Convert.ToByte(2));
                current_pixel += 1;
                return to_return;
            }
            else
            {
                return -1;
            }
        }
    }

    public class LogLogger : ILogger
    {
        public void SendReport(string filename, string message)
        {
            if (!File.Exists(filename))
            {
                File.Create(filename);
                File.AppendAllText(filename, "Some programm log");
            }
            File.AppendAllText(filename, "\n" + message + " --- " + DateTime.Now.ToString());
        }
    }

    public class ReportLogger : ILogger
    {
        public void SendReport(string path, string message)
        {
            string filename = path + "/" + "Report " + DateTime.Now.ToString();
            File.Create(filename);
            File.AppendAllText(filename, "Programm execution report\n");
            File.AppendAllText(filename, DateTime.Now.ToString() + "\n");
            File.AppendAllText(filename, "\nMessage:\n");
            File.AppendAllText(filename, message);
        }
    }
    //Основная программа
    internal static class Program
    {
        /// <summary>
        /// Главная точка входа для приложения.
        /// </summary>
        [STAThread]
        static void Main()
        {
            Application.EnableVisualStyles();
            Application.SetCompatibleTextRenderingDefault(false);
            Application.Run(new Form1());
        }
    }
}
