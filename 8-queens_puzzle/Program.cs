using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _8_queens_puzzle
{
    class Program
    {
        public static char[,] Solv = new char[8, 8];
        public static List<char[,]> Results = new List<char[,]>();
        static void Main()
        {
            for (int i = 0; i < Solv.GetLength(0); i++)
            {
                for (int j = 0; j < Solv.GetLength(1); j++)
                {
                    Solv[i, j] = '.';
                }
            }
            Solution(0);
            
            foreach (var Result in Results)
            {
                Console.WriteLine("Solution" + (Results.IndexOf(Result)+1));
                for (int i = 0; i < Result.GetLength(0); i++)
                {
                    for (int j = 0; j < Result.GetLength(1); j++)
                    {
                        Console.Write(Result[i, j]);
                    }
                    Console.WriteLine();
                }
            }
            Console.ReadLine();
        }

        public static void Solution(int i)
        {
            if(Solv.GetLength(0) == i)
            {                
                Results.Add((char[,])Solv.Clone());
                return;
            }
            for(int j = 0; j < Solv.GetLength(1); j++)
            {
                if (ifQueen(i,j))
                {
                    Solv[i, j] = 'Q';
                    Solution(i + 1);
                    Solv[i, j] = '.';
                }
            }
        }
        public static bool ifQueen(int i,int j)
        {
            //尋找垂直座標是否有皇后
            for (int k = 0; k < i; k++)
            {
                if (Solv[k,j] == 'Q')
                {
                    return false;
                }
            }
            //尋找斜左方是否有皇后
            for (int k = 1; k <= i && k <= j ; k++)
            {
                if (Solv[i - k,j - k] == 'Q')
                {
                    return false;
                }
            }
            //尋找斜右方是否有皇后
            for (int k = 1; k <= i  && k < Solv.GetLength(1) - j; k++)
            {
                if (Solv[i - k,j + k] == 'Q')
                {
                    return false;
                }
            }
            return true;
        }

    }
}
