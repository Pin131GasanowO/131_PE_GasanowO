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
        static double GetDaySalary(Day day)
        {
            double salary;
            if (day.IsWeekend)
            {
                if (day.Revenue <= 100000)
                {
                    salary = day.Revenue / 100 * 15;
                }
                if (day.Revenue > 10000)
                {
                    salary = ((day.Revenue - 10000) / 100 * 10 + 500) * 2;
                }
                else
                {
                    salary = (day.Revenue / 100) * 5;
                }

            }
            else
            {
                if (day.Revenue > 10000)
                {
                    salary = (day.Revenue - 10000) / 100 * 10 + 500;
                }
                else
                {
                    salary = (day.Revenue / 100) * 5;
                }
            }
            return salary;
        }
        static void Main(string[] args)
        {
            Sotrudnik sotrudnik;
            Console.WriteLine("Введите название файла");
            string name = Console.ReadLine();
            using (StreamReader reader = new StreamReader(name, Encoding.Default))
            {
                sotrudnik = new Sotrudnik(reader);
            }
            double sum = 0;
            for (int i = 0; i < sotrudnik.days.Count; i++)
            {
                double salary = GetDaySalary(sotrudnik.days[i]);
                sum += salary;
                Console.WriteLine("Заработано за {0} - {1} руб.", sotrudnik.days[i].Date, salary);
            }
            Console.WriteLine("Всего заработано: " + sum);
            Console.ReadKey();
        }
        public class Day
        {
            public DateTime Date;
            public double Revenue;
            public bool IsWeekend;
            public Day(DateTime date, double revenue, bool iW)
            {
                Date = date;
                Revenue = revenue;
                IsWeekend = iW;
            }
        }
        public class Sotrudnik
        {
            public List<Day> days;

            public Sotrudnik(StreamReader reader)
            {
                days = new List<Day>();
                int i = 1;
                while (!reader.EndOfStream)
                {
                    string[] parseLine = reader.ReadLine().Split(';');
                    bool isWeekend;
                    if (i >= 5 && i++ <= 7) isWeekend = true;
                    else isWeekend = false;
                    if (i == 7) i = 1;
                    days.Add(new Day(DateTime.Parse(parseLine[0]),Double.Parse(parseLine[1]), isWeekend));
                }
            }
        }
    }
}