using System;

namespace Task1
{
    class Program
    {
        static void Main(string[] args)
        {
            var exceptionArray = new Exception[] { new ArgumentException(), new ArgumentOutOfRangeException(), new DivideByZeroException(), 
                                 new FormatException(), new UserException("My exception") };

            foreach (var item in exceptionArray)
            {
                try
                {
                    throw item;
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.Message);
                }
            }

            Console.ReadKey();
        }
    }

    public class UserException : Exception
    {
        public UserException(string message) : base(message)
        {

        }
    }
}
