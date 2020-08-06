using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ3
{
    class Program
    {
        static void Main(string[] args)
        {
            int number;
            ReadNumber(out number);
        }

        static void ReadNumber(out int number)
        {
            number = 0;
            bool isWork = true;

            while (isWork)
            {
                Console.Write("Введите число: ");
                string userInput = Console.ReadLine();
                bool result = int.TryParse(userInput, out number);
                if (result)
                {
                    isWork = false;
                }
                else
                {
                    Console.WriteLine("Вы ввели не число, попробуйте ещё раз!");
                }
            }   
        }
    }
}
