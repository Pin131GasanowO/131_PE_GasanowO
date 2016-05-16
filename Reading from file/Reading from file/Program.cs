using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace Reading_from_file
{
    class Program
    {
        static int OnlyForDay(int result, bool isOverride)
        {
            int forDayMin = 300;
            int forDay;
            if (result == 10000)
            {
                forDay = 500;
            }
            else if (result > 10000)
            {
                forDay = ((result - 10000) / 100) * 10 + 500;
            }
            else if (result > 100000)
            {
                forDay = result / 100 * 15;
            }
            else
            {
                forDay = forDayMin;
            }
            return isOverride ? 2 * forDay : forDay;
        }
        static int[] KeyboardInput()
        {
            Console.Write("Количество дней, отработанных сотрудником: ");
            int Week = Convert.ToInt32(Console.ReadLine());
            int[] days = new int[Week];

            for (int i = 0; i < Week; i++)
            {
                Console.Write("Сумма, зарабатываемая за день: ");
                days[i] = Convert.ToInt32(Console.ReadLine());
            }

            return days;
        }
        static void Main(string[] args)
        {
            int total = 0;
            int[] days = null;
            ConsoleKeyInfo mode;

            while (days == null)
            {
                Console.WriteLine("1 - Ввести данные с клавиатуры " + " 2 - Считать данные из файла");

                mode = Console.ReadKey(true);

                switch (mode.Key)
                {
                    case ConsoleKey.D2:

                        int counter = 0;
                        string line;

                        System.IO.StreamReader file =
                        new System.IO.StreamReader(@"C:\Users\Admin\Source\Repos\131_PE_GasanowO\Reading from file\Reading from file\bin\Debug\Валера.txt");
                        while ((line = file.ReadLine()) != null)
                        {
                            System.Console.WriteLine(line);
                            counter++;
                        }
                        Console.ReadKey();
                        break;
                    case ConsoleKey.D1:

                        days = KeyboardInput();

                        break;
                }

            }
            for (int i = 0; i < days.Length; i++)
            {
                int dayPay = OnlyForDay(days[i], i > 4);
                total += dayPay;
                Console.WriteLine("В день {0} заработано: {1} руб.", i + 1, dayPay);
            }
            Console.WriteLine("Итого выручка за неделю составляет: {0} руб.", total);
            Console.ReadKey();
        }
    }
}
