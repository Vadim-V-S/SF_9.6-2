using System;
using System.Collections;

namespace SF_9._6_2
{
    class NumberReader
    {
        public delegate void NumberEnteredDelegate(int number);
        public event NumberEnteredDelegate NumberHandler;
        protected virtual void NumberEntered(int num)
        {
            NumberHandler?.Invoke(num);
        }

        public void Read()
        {
            Console.WriteLine("\nДля сортировки списка от  А до Я введите - 1\nДля сортировки списка от  Я до А введите - 2");
            int num = int.Parse(Console.ReadLine());
           if (num != 1 && num != 2) throw new FormatException();

            NumberEntered(num);
        }

    }

    class Program
    {
        static ArrayList list;
        static void Main(string[] args)
        {
            list = new ArrayList { "Иванов", "Сидоров", "Киладзе", "Андреев", "Петров", "Николаев" };
            PrintList(list);

            NumberReader numberReader = new NumberReader();
                numberReader.NumberHandler += SortList;

            while (true)
            {
                try
                {
                    numberReader.Read();
                }
                catch (FormatException)
                {
                    Console.WriteLine("Введено некорректное значение");
                }
            }
        }

        public static void SortList(int num)
        {
            switch (num)
            {
                case 1: list.Sort(); break;
                case 2: list.Sort(); list.Reverse(); break;
            }
            PrintList(list);
        }

        static void PrintList(ArrayList list)
        {
            Console.WriteLine();
            foreach (var name in list)
                Console.Write(name + " ");
            Console.WriteLine();
        }
    }
}
