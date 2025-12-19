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
        void EndWork();
    }
    public interface IEncoder
    {
        void BeginWork(string filename);
        void SendNext(char smb);
        void EndWork();
    }
    public interface ILogger
    {
        void SendReport(string filename, string message);
    }
    //Создание классов
    public class ClassicDecoder : IDecoder
    {
        FileStream f;
        public void BeginWork(string filename)
        {
            f = File.OpenRead(filename);
        }

        public char DecodeNext()
        {
            if (f.Position <= f.Length - 1)
            {
                char to_return = Convert.ToChar(f.ReadByte());
                return to_return;
            }
            else
            {
                return '\0';
            }
        }

        public void EndWork()
        {
            f.Close();
        }
    }

    public class Crypt1Decoder : IDecoder
    {
        FileStream f;
        public void BeginWork(string filename)
        {
            f = File.OpenRead(filename);
        }

        public char DecodeNext()
        {
            if (f.Position <= f.Length - 1)
            {
                char to_return = Convert.ToChar(f.ReadByte() - 4);
                return to_return;
            }
            else
            {
                return '\0';
            }
        }

        public void EndWork()
        {
            f.Close();
        }
    }

    public class Crypt2Decoder : IDecoder
    {
        FileStream f;
        public void BeginWork(string filename)
        {
            f = File.OpenRead(filename);
        }

        public char DecodeNext()
        {
            if (f.Position <= f.Length - 1)
            {
                char to_return = Convert.ToChar(f.ReadByte() - ((f.Position - 1) % 4));
                return to_return;
            }
            else
            {
                return '\0';
            }
        }

        public void EndWork()
        {
            f.Close();
        }
    }

    public class ClassicEncoder : IEncoder
    {
        FileStream f;
        public void BeginWork(string filename)
        {
            f = File.OpenWrite(filename);
        }

        public void SendNext(char smb)
        {
            f.WriteByte(Convert.ToByte(smb));
        }

        public void EndWork()
        {
            f.Close();
        }
    }

    public class Crypt1Encoder : IEncoder
    {
        FileStream f;
        public void BeginWork(string filename)
        {
            f = File.OpenWrite(filename);
        }

        public void SendNext(char smb)
        {
            f.WriteByte(Convert.ToByte(Convert.ToByte(smb) + 4));
        }

        public void EndWork()
        {
            f.Close();
        }
    }

    public class Crypt2Encoder : IEncoder
    {
        FileStream f;
        int current_pos = 0;
        public void BeginWork(string filename)
        {
            f = File.OpenWrite(filename);
        }

        public void SendNext(char smb)
        {
            f.WriteByte(Convert.ToByte(Convert.ToByte(smb) + (current_pos % 4)));
            current_pos++;
        }

        public void EndWork()
        {
            f.Close();
        }
    }

    public class LogLogger : ILogger
    {
        public void SendReport(string path, string message)
        {
            string filename = path + "/MainLog.txt";
            if (!File.Exists(filename))
            {
                File.Create(filename).Close();
                File.AppendAllText(filename, "Some programm log");
            }
            File.AppendAllText(filename, "\n" + message + " --- " + DateTime.Now.ToString());
        }
    }

    public class ReportLogger : ILogger
    {
        public void SendReport(string path, string message)
        {
            string filename = path + "/" + "Report " + DateTime.Now.ToString().Replace(':', '.') + ".txt";
            File.Create(filename).Close();
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
