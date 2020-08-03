using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DZ2
{
    class Program
    {
        static void Main(string[] args)
        {
            int health = 50, maxHealth = 100;
            int mana = 40, maxMana = 100;

            while (true)
            {

                DrawBar(health, maxHealth, ConsoleColor.Red, 0);
                DrawBar(mana, maxMana, ConsoleColor.Green, 1);

                Console.SetCursorPosition(0, 5);
                Console.Write("На какое количество процентов изменить жизни: ");
                health += Convert.ToInt32(Console.ReadLine());
                Console.Write("На сколько процентов изменить ману: ");
                mana += Convert.ToInt32(Console.ReadLine());
               
                Console.ReadKey();
                Console.Clear();
            }
        }

        static void DrawBar(int value, int maxValue, ConsoleColor color, int position, char symbol = '#')
        {
            Console.SetCursorPosition(0, position);
            value /= 10;
            maxValue /= 10;
            Console.BackgroundColor  = default;
            string bar = "";
            for(int i = 0; i < value; i++)
            {
                bar += symbol;
            }

            Console.Write('[');
            Console.BackgroundColor = color;
            Console.Write(bar);
            bar = "";

            for(int i = value; i< maxValue; i++)
            {
                bar += '_';
            }

            Console.BackgroundColor = default;
            Console.Write(bar + ']');
        }
    }
}
