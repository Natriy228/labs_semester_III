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
                    if (i == 0 && CI[0] == 0)
                    {
                        error("Первый коэффициент не может быть нулём.");
                        --i;
                        continue;
                    }
                }
            }
            
            double D = CI[1] * CI[1] - 4 * CI[2] * CI[0];
            if (D > 0)
            {
                double R1 = (-1 * CI[1] + Math.Sqrt(D)) / 2 / CI[0];
                double R2 = (-1 * CI[1] - Math.Sqrt(D)) / 2 / CI[0];
                if (R1 < 0 && R2 < 0)
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Дискриминант больше нуля. Корней нет.");
                    Console.ForegroundColor = ConsoleColor.White;
                    Environment.Exit(0);
                }
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write("Дискриминант больше нуля. Корни: ");
                if (R1 == 0)
                {
                    Console.Write("{0} и ", R1);
                }
                if (R1 > 0)
                {
                    Console.Write("{0}, {1} и ", Math.Sqrt(R1), -1 * Math.Sqrt(R1));
                }
                if (R2 == 0)
                {
                    Console.Write("{0}", R2);
                }
                if (R2 > 0)
                {
                    Console.Write("{0}, {1}", Math.Sqrt(R2), -1 * Math.Sqrt(R2));
                }
                Console.WriteLine();
            }
            else if (D == 0)
            {
                double R = -1 * CI[1] / 2 / CI[0];
                if (R == 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Дискриминант равен нулю. Единственный корень: {0}", R);
                }
                else if (R > 0)
                {
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine("Дискриминант равен нулю. Корни: {0}, {1}", Math.Sqrt(R), -1 * Math.Sqrt(R));
                }
                else
                {
                    Console.ForegroundColor = ConsoleColor.Red;
                    Console.WriteLine("Дискриминант равен нулю. Корней нет.");
                }
            }
            else
            {
                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine("Дискриминант меньше нуля. Корней нет.");
            }

            Console.ResetColor();
        }
    }
}
