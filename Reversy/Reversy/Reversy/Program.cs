using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Reversy
{
    class Program
    {
        static void PrintColor(int[,] mat)
        {
            int c1 = 0, c2 = 0;
            Console.Clear();
            Console.WriteLine("  1  2  3  4  5  6  7  8  9  0");
            for (int i = 1; i < mat.GetLength(0) - 1; i++)
            {
                if (i == 10)
                    Console.Write("0 ");
                else
                    Console.Write(i + " ");

                for (int j = 1; j < mat.GetLength(1) - 1; j++)
                {
                    if (mat[i, j] == 1)
                    {
                        Console.BackgroundColor = ConsoleColor.Blue;
                        c1++;
                    }
                    else
                    if (mat[i, j] == 2)
                    {
                        Console.BackgroundColor = ConsoleColor.Red;
                        c2++;
                    }
                    else
                        Console.BackgroundColor = ConsoleColor.Black;
                    Console.Write("__|");
                }
                Console.WriteLine();
            }
            Console.BackgroundColor = ConsoleColor.Black;
            if ((c1 + c2) == ((mat.GetLength(0) - 2) * (mat.GetLength(1) - 2)) - 4)
            {
                if (c1 > c2)
                {
                    Console.WriteLine("The player 1 is winner!!!");
                }
                else
                {
                    Console.WriteLine("The player 2 is winner!!!");
                }
            }
        }
        static bool Check(int[,] mat, int i, int j)
        {
            bool flag = false;
            int[,] m = { { 1, 1, 1 }, { 1, 0, 1 }, { 1, 1, 1 } };
            if (i < 1 || i > 10 || j < 1 || j > 10)
            {
                Console.WriteLine("Error! play again");
                return true;
            }
            if (mat[i, j] != 0)
            {
                Console.WriteLine("Error! play again");
                return true;
            }
            for (int a = -1; a < 2 && !flag; a++)
            {
                for (int b = -1; b < 2 && !flag; b++)
                {
                    if (mat[i + a, j + b] != 0)
                    {
                        flag = true;
                    }
                }
            }
            if (!flag)
            {
                Console.WriteLine("Error! play again");
                return true;
            }
            return false;
        }
        static void Play(int[,] mat, int i, int j)
        {
            int t, s;
            //מימין
            for (t = j - 1; t >= 1 && mat[i, t] != mat[i, j] && mat[i, t] != 0; t--)
                if (mat[i, t - 1] == mat[i, j])
                    for (int r = t; r < j; r++)
                        mat[i, r] = mat[i, j];
            //משמאל
            for (t = j + 1; t < mat.GetLength(0) && mat[i, t] != mat[i, j] && mat[i, t] != 0; t++)
                if (mat[i, t + 1] == mat[i, j])
                    for (int r = t; r >= j; r--)
                        mat[i, r] = mat[i, j];
            //מלמעלה
            for (t = i - 1; i >= 1 && mat[t, j] != mat[i, j] && mat[t, j] != 0; t--)
                if (mat[t - 1, t] == mat[i, j])
                    for (int r = t; r < i; r++)
                        mat[r, j] = mat[i, j];
            //מלמטה
            for (t = i + 1; t < mat.GetLength(0) && mat[t, j] != mat[i, j] && mat[t, j] != 0; t++)
                if (mat[t + 1, j] == mat[i, j])
                    for (int r = t; r >= i; r--)
                        mat[r, j] = mat[i, j];
            //אלכסון משמאל למעלה
            for (t = i - 1, s = j - 1; t >= 1 && s >= 1 && mat[t, s] != mat[i, j] && mat[t, s] != 0; t--, s--)
                if (mat[t - 1, s - 1] == mat[i, j])
                    for (int r = t, q = s; r < i && q < j; r++, q++)
                        mat[r, q] = mat[i, j];
            //אלכסון מימין למטה
            for (t = i + 1, s = j + 1; t < mat.GetLength(0) && s < mat.GetLength(1) && mat[t, s] != mat[i, j] && mat[t, s] != 0; t++, s++)
                if (mat[t - 1, s - 1] == mat[i, j])
                    for (int r = t, q = s; r >= i && q >= j; r--, q--)
                        mat[r, q] = mat[i, j];
            //אלכסון מימין למעלה
            for (t = i - 1, s = j + 1; t >= 1 && s < mat.GetLength(0) && mat[t, s] != mat[i, j] && mat[t, s] != 0; t--, s++)
                if (mat[t - 1, s + 1] == mat[i, j])
                    for (int r = t, q = s; r < i && q >= j; r++, q--)
                        mat[r, q] = mat[i, j];
            //אלכסון משמאל למטה
            for (t = i + 1, s = j - 1; t < mat.GetLength(0) && s >= 1 && mat[t, s] != mat[i, j] && mat[t, s] != 0; t++, s--)
                if (mat[t + 1, s - 1] == mat[i, j])
                    for (int r = t, q = s; r >= i && q < j; r--, q++)
                        mat[r, q] = mat[i, j];
        }
        static void Main(string[] args)
        {
            //Reversy
            const int n = 10;
            int[,] mat = new int[n + 2, n + 2];
            mat[mat.GetLength(0) / 2 - 1, mat.GetLength(0) / 2 - 1] = mat[mat.GetLength(0) / 2, mat.GetLength(0) / 2] = 1;
            mat[mat.GetLength(0) / 2, mat.GetLength(0) / 2 - 1] = mat[mat.GetLength(0) / 2 - 1, mat.GetLength(0) / 2] = 2;
            PrintColor(mat);
            int i, j, p;
            for (p = 1; p <= (n * n) - 4; p++)
            {
                if (p % 2 != 0)
                {
                    Console.WriteLine("Player 1, your time is now");
                    Console.WriteLine("enter place between 1-10");
                    i = int.Parse(Console.ReadLine());
                    j = int.Parse(Console.ReadLine());
                    while (Check(mat, i, j))
                    {
                        Console.WriteLine("Player 1, your time is now");
                        Console.WriteLine("enter place between 1-10");
                        i = int.Parse(Console.ReadLine());
                        j = int.Parse(Console.ReadLine());
                    }
                    mat[i, j] = 1;
                }
                else
                {
                    Console.WriteLine("Player 2, your time is now");
                    Console.WriteLine("enter place between 1-10");
                    i = int.Parse(Console.ReadLine());
                    j = int.Parse(Console.ReadLine());
                    while (Check(mat, i, j))
                    {
                        Console.WriteLine("Player 2, your time is now");
                        Console.WriteLine("enter place between 1-10");
                        i = int.Parse(Console.ReadLine());
                        j = int.Parse(Console.ReadLine());
                    }
                    mat[i, j] = 2;
                }
                Play(mat, i, j);
                PrintColor(mat);
            }
        }
    }
}