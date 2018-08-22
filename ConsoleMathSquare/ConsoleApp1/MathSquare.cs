using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApp1
{
    class Program
    {
        static void Main(string[] args)
        {
            Double a, b, c, D, x1, x2;
            Console.WriteLine("******************************************************");
            Console.WriteLine("*********Math of square*******************************");
            Console.WriteLine("******************************************************");
            Console.ForegroundColor = ConsoleColor.DarkCyan;
        Start1:
            Console.WriteLine("-------------------------------------------------------");
            Console.WriteLine("Write for input");
            Console.ReadLine();

            Console.WriteLine("enter a,b,c");
            try
            {
                a = Convert.ToDouble(Console.ReadLine());
                b = Convert.ToDouble(Console.ReadLine());
                c = Convert.ToDouble(Console.ReadLine());

                Console.ForegroundColor = ConsoleColor.DarkMagenta;
                D = b * b - 4 * a * c;

                if (D >= 0 && a != 0)
                {
                    x1 = (-b + Math.Sqrt(D)) / (2 * a);
                    x2 = (-b - Math.Sqrt(D)) / (2 * a);
                    Console.WriteLine("X1 =", x1, "X2 = ", x2);
                }
                else
                {
                    Console.WriteLine("No square's");
                    Console.ReadKey();
                    goto Start1;
                }
                Console.ReadLine();
                Console.ReadKey();

            }
            catch (FormatException ex)
            {
                Console.WriteLine("You write not allowed number");
            }
            finally
            {
                Console.WriteLine("Press key for exit");
                Console.ReadKey();
            }


           

        }
    }
}
