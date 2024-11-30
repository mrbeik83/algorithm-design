using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chained_Matirx_Multiplication
{
    internal class Program
    {
        static void Main(string[] args)
        {
            int[] d = { 5, 2, 3, 4, 6, 7, 8 };
            int n = d.Length;
            int[,] temp = matrixChain(d, n);
            Console.WriteLine(temp[4,6]);
            Console.ReadKey();
        }
        public static int[,] matrixChain(int[] d, int n)
        {
            int[,] m = new int[n, n];
            for (int i = 1; i < n; i++)
            {
                m[i, i] = 0;
            }
            for (int diagonal = 2; diagonal < n; diagonal++) 
            { 
                for (int i = 1; i < n - diagonal + 1; i++)
                {
                    int j = i + diagonal - 1;
                    m[i,j] = int.MaxValue;
                    for (int k = i; k <= j - 1; k++)
                    {
                        int temp = m[i,k] + m[k+1,j] + (d[i-1] * d[k] * d[j]);
                        if(temp < m[i, j])
                        {
                            m[i,j] = temp;
                        }
                    }
                }
            }
            return m;

        }
    }
}
