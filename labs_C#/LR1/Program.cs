namespace LR1
{
    internal class Program
    {
        static void error(string message)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(message);
            Console.ResetColor();
        }
        static void Main(string[] args)
        {
            double[] CI = new double[3]; //Converted inputs
            bool GotValuesFromArgs = true;

            if (args.Length >= 3)
            {
                int i = 0;
                foreach (string input in args)
                {
                    try { CI[i] = Convert.ToDouble(input); }
                    catch (FormatException)
                    {
                        error("Параметры запуска не содержат коэффициенты уравнения.");
                        GotValuesFromArgs = false;
                        break;
                    }
                    ++i;
                }
            }
            else
            {
                error("В параметрах запуска не указаны все коэффициенты уравнения.");
                GotValuesFromArgs = false;
            }

            if (!GotValuesFromArgs)
            {
                Console.WriteLine("Введите коефициенты биквадратного уравнения:");
                string? input;
                for (int i = 0; i < 3; ++i)
                {
                    input = Console.ReadLine();
                    try { CI[i] = Convert.ToDouble(input); }
                    catch (FormatException)
                    {
                        error("Введённое значение должно быть числом.");
                        --i;
                        continue;
                    }
                }
            }
            
            double D = CI[1] * CI[1] - 4 * CI[2] * CI[0];
            Console.ForegroundColor = ConsoleColor.Green;
            if (D > 0)
            {
                double R1 = (-1 * CI[1] + Math.Sqrt(D)) / 2 / CI[0];
                double R2 = (-1 * CI[1] - Math.Sqrt(D)) / 2 / CI[0];
                Console.WriteLine("D = {0} > 0\nКорни: {1} и {2}", D, R1, R2);
            }
            else if (D == 0) Console.WriteLine("D = 0\nКорень: {0}", -1 * CI[1] / 2 / CI[0]);
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("D = {0} < 0", D);
            }

            Console.ResetColor();
        }
    }
}
