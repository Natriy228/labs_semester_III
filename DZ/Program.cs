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
        char DecodeNext();
    }
    public interface IEncoder
    {
        void BeginWork(string filename);
        void SendNext(char smb);
    }
    public interface ILogger
    {
        void SendReport(string filename, string message);
    }
    //Создание классов
    public class ClassicDecoder : IDecoder
    {
        int current_char;
        string readed_info;
        public void BeginWork(string filename)
        {
            readed_info = File.ReadAllText(filename);
            current_char = 0;
        }

        public char DecodeNext()
        {
            if (current_char < readed_info.Length)
            {
                char to_return = readed_info[current_char];
                current_char += 1;
                return to_return;
            }
            else
            {
                return '\0';
            }
        }
    }

    public class Crypt1Decoder : IDecoder
    {
        int current_char;
        string readed_info;
        public void BeginWork(string filename)
        {
            readed_info = File.ReadAllText(filename);
            current_char = 0;
        }

        public char DecodeNext()
        {
            if (current_char < readed_info.Length)
            {
                char to_return = Convert.ToChar(Convert.ToInt32(readed_info[current_char]) - 4);
                current_char += 1;
                return to_return;
            }
            else
            {
                return '\0';
            }
        }
    }

    public class Crypt2Decoder : IDecoder
    {
        int current_char;
        string readed_info;
        public void BeginWork(string filename)
        {
            readed_info = File.ReadAllText(filename);
            current_char = 0;
        }

        public char DecodeNext()
        {
            if (current_char < readed_info.Length)
            {
                char to_return = Convert.ToChar(Convert.ToInt32(readed_info[current_char]) / 3);
                current_char += 1;
                return to_return;
            }
            else
            {
                return '\0';
            }
        }
    }

    public class ClassicEncoder : IEncoder
    {
        string current_file;
        public void BeginWork(string filename)
        {
            current_file = filename;
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
