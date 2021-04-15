using System;
using System.Collections.Generic;
using System.Linq;

namespace Task2
{
    class Program
    {
        static void Main(string[] args)
        {
            var persons = new List<string> { "Корнеев", "Федеров", "Яшин", "Акулов", "Игнатов" };

            bool isFalseNumber = true;

            while (isFalseNumber)
            {
                try
                {
                    Console.Write("Enter the 1 or 2: ");
                    var str = Console.ReadLine();
                    var result = int.TryParse(str, out int number);
                    if (!result || (number != 1 && number != 2))
                    {
                        throw new MyException("Введите цифру один или два");
                    }
                    else
                    {
                        var user = new UserNumber();
                        user.CompletedEnter += Sort;
                        user.Start(persons, number);
                        isFalseNumber = false;
                    }
                }
                catch (MyException ex)
                {
                    Console.WriteLine(ex.Message);
                    isFalseNumber = true;
                }
            }

            Console.ReadKey();

        }

        static void Sort(List<string> persons, int number)
        {
            var sortedPerson = number == 1 ? persons.OrderBy(x => x) : persons.OrderByDescending(x => x);

            foreach (var item in sortedPerson)
            {
                Console.WriteLine(item);
            }
        }
    }

    class UserNumber
    {
        public delegate void UserEntered(List<string> persons, int number);
        public event UserEntered CompletedEnter;

        public void Start(List<string> persons, int number)
        {
            OnProccessCompleted(persons, number);
        }

        protected void OnProccessCompleted(List<string> persons, int number)
        {
            CompletedEnter?.Invoke(persons, number);
        }

    }

    class MyException : Exception
    {
        public MyException(string message) : base(message)
        {

        }
    }
}
