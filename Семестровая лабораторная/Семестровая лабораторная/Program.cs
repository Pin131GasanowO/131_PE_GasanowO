using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace _131_PE_GasanowO
{
    class Program
    {
        static int[] Array(int[] Calculation_of_wages)
        {
            int[] z = new int[Calculation_of_wages.Length];
            for (int i = 0; i < Calculation_of_wages.Length; i++)
            {
                if (i > 4)
                {
                    if (Calculation_of_wages[i] <= 100000)
                    {
                        z[i] = Calculation_of_wages[i] / 100 * 15;
                    }
                    if (Calculation_of_wages[i] > 10000)
                    {
                        z[i] = ((Calculation_of_wages[i] - 10000) / 100 * 10 + 500) * 2;
                    }
                    else
                    {
                        z[i] = (Calculation_of_wages[i] / 100) * 5;
                    }
                }
                else
                {
                    if (Calculation_of_wages[i] > 10000)
                    {
                        z[i] = (Calculation_of_wages[i] - 10000) / 100 * 10 + 500;
                    }
                    else
                    {
                        z[i] = (Calculation_of_wages[i] / 100) * 5;
                    }
                }

            }
            return z;
        }
        static void Main(string[] args)
        {
            int i = 0;
            int[] t;

            Console.WriteLine("Введите имя файла:");

            string name = Console.ReadLine();
            string[] mas = File.ReadAllText(name).Split(new char[] { ' ' });
            int[] total = new int[mas.Length];
            for (i = 0; i < mas.Length; i++)
            {
                total[i] = Int32.Parse(mas[i]);
            }

            t = Array(total);
            int summa = t.Sum();

            Console.WriteLine("\n");
            Console.WriteLine("Зарплата работника составляет: {0} рублей.", summa);
            Console.ReadKey();
            Console.ReadKey();
        }
    }
}

