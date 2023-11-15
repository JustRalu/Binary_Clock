using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices.ComTypes;
using System.Text;
using System.Threading.Tasks;

namespace Binary_Clock
{
    internal class Program
    {
  
        private static void conversie_baza_2(string[,] arr, int l, int c, int num)
        {
            if (num != 0)
            {
                conversie_baza_2(arr, l - 1, c, num / 2);
                if (num % 2 == 1)
                    arr[l, c] = "O";

            }

        }
        private static int convertToInt(string a)
        {
            int x = 0;
            for (int i = 0; i < a.Length; i++)
            {
                int temp = a[i] - '0';
                if (temp != 0)
                {
                    x += temp * (int)Math.Pow(10, (a.Length - (i + 1)));
                }
            }
            return x;
        }
        private static bool IsNumeric(char s)
        {

            if (!char.IsDigit(s))
                
               return false;
            
            return true;
        }
        static void Main(string[] args)
        {
            Console.WriteLine("Scrieti datele unei ore:");
            string x = Console.ReadLine();
            Console.WriteLine();
            Console.WriteLine("si reprezentati-le printr un Binary Clock: ");

            if (x.Length != 8)
            {
                Console.WriteLine();
                Console.WriteLine("Date gresite scrise de la tastatura");
            }
            else
            {

                char[] temp = new char[x.Length];

                temp = x.ToCharArray();
                int i;

                if (!IsNumeric(temp[0]) || !IsNumeric(temp[1]) || !IsNumeric(temp[3]) || !IsNumeric(temp[4]) || !IsNumeric(temp[6]) || !IsNumeric(temp[7]))
                {
                    Console.WriteLine();
                    Console.WriteLine("Date gresite scrise de la tastatura");
                }
                else
                    if (temp[2] != ':' || temp[5] != ':')
                {
                    Console.WriteLine();
                    Console.WriteLine("Date gresite scrise de la tastatura");
                }
                else
                {
                    string[] result = new string[8];
                    for (i = 0; i < 8; i++)
                    {
                        result[i] = Convert.ToString(temp[i]);

                    }

                    int ora, minute, secunde;
                    ora = convertToInt(result[0]) * 10 + convertToInt(result[1]);
                    minute = convertToInt(result[3]) * 10 + convertToInt(result[4]);
                    secunde = convertToInt(result[6]) * 10 + convertToInt(result[7]);

                    if (ora > 24 || minute > 59 || secunde > 59)
                    {
                        Console.WriteLine();
                        Console.WriteLine("Date gresite scrise de la tastatura");
                    }

                    else

                    {
                        int col = 2, timp, pow = 100000;
                        Console.WriteLine();
                        Console.WriteLine("  H     H     M     M     S     S  ");

                        string[,] arr = new string[5, 33];

                        for (i = 0; i < 5; i++)
                            for (int j = 0; j < 33; j++)
                                arr[i, j] = " ";

                        arr[4, 0] = "1";
                        arr[3, 0] = "2";
                        arr[2, 0] = "4";
                        arr[1, 0] = "8";
                        for (i = 3; i < 5; i++)
                            arr[i, 2] = "X";
                        for (i = 1; i < 5; i++)
                            arr[i, 8] = "X";
                        for (i = 2; i < 5; i++)
                            arr[i, 14] = "X";
                        for (i = 1; i < 5; i++)
                            arr[i, 20] = "X";
                        for (i = 2; i < 5; i++)
                            arr[i, 26] = "X";
                        for (i = 1; i < 5; i++)
                            arr[i, 32] = "X";

                        timp = ora * 10000 + minute * 100 + secunde;
                        for (i = 0; i < 6; i++)
                        {
                            conversie_baza_2(arr, 4, col, timp / pow % 10);
                            pow /= 10;
                            col += 6;
                        }
                        for (i = 0; i < 5; i++)
                        {
                            for (int j = 0; j < 33; j++)
                                Console.Write(arr[i, j]);
                            Console.WriteLine();
                        }

                        Console.Write($"  {result[0]}     {result[1]}     {result[3]}     {result[4]}     {result[6]}     {result[7]}  ");
                    }

                }
            }
            
            Console.ReadKey();

        }
    }
}
