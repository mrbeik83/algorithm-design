using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Schema;

namespace floyd
{
    internal class Program
    {

        public static int max = 0;
        public static List<List<string>> Readfile(string path)
        {
            List<List<string>> listAll = new List<List<string>>();
            StreamReader st = new StreamReader(path);
            string line;
            int i = 0;
            while ((line = st.ReadLine()) != null)
            {
                List<string> list = new List<string>(line.Split(','));
                for (int j = 0; j < list.Count; j++)
                {
                    try
                    {
                        max += Int32.Parse(list[j]);
                    }
                    catch
                    {

                    }
                }
                listAll.Add(list);
                i++;
            }
            max++;
            return listAll;

        }
        public static int[,] turntoInt(List<List<string>> arr)
        {

            int[,] array = new int[arr.Count, arr.Count];
            for (int i = 0; i < arr.Count; i++)
            {
                for (int j = 0; j < arr.Count; j++)
                {
                    try
                    {
                        array[i, j] = int.Parse(arr[i][j]);
                    }
                    catch
                    {
                        array[i, j] = max;
                    }
                }
            }
            return array;
        }
        public static int[,] floydAlgoritm(int[,] arr, int n)
        {
            int[,] D = new int[n, n];
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                for (int j = 0; j < arr.GetLength(1); j++)
                {
                    D[i, j] = arr[i, j];
                }
            }
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (D[i, j] > D[k, j] + D[i, k])
                        {
                            D[i, j] = D[k, j] + D[i, k];
                        }
                    }
                }
            }
            return D;
        }
        public static int[,] floydAlgoritm2(int n, int[,] W, int[,] D, int[,]P)
        {
            //ریختن یک آرایه در آرایه دیگر
            for (int i = 0; i < W.GetLength(0); i++)
            {
                for (int j = 0; j < W.GetLength(1); j++)
                {
                    D[i, j] = W[i, j];
                }
            }
            //p صفر کردن کل خونه های آرایه   
            for (int i = 0; i < n; i++) {
                for (int j = 0; j < n; j++)
                {
                    P[i,j] = 0;
                }

            }
            //floyd2
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (D[i, j] > D[k, j] + D[i, k])
                        {
                            P[i,k] = k;
                            D[i, j] = D[k, j] + D[i, k];
                        }
                    }
                }
            }
            return D;
        }
        public static void Path (int [,] P,int q, int r)
        {
            if (P[q,r] != 0)
            {
                Path(P, q, P[q, r]);
                Console.WriteLine(" v " + P[q,r]);
                Path(P, P[q, r],r );

            }
        }
        
        public static void printFloydPath(int[,] arr, int[,]arrf,int n)
        {
            for (int k = 0; k < n; k++)
            {
                for (int i = 0; i < n; i++)
                {
                    for (int j = 0; j < n; j++)
                    {
                        if (arrf[i, j] == arr[k, j] + arr[i, k])
                        {
                            Console.WriteLine("az  " + (i+1) + "  ta  " + (j+1));
                            Console.WriteLine((i+1) + "-" + (k + 1) + "-" + (j + 1) + "= " + arrf[i,j]);
                        }
                    }
                }
            }
        }
        static void Main(string[] args)
        {
            
            int[,] W = turntoInt(Readfile("E:/exel/matris.csv"));
            int[,] P = new int[W.GetLength(0), W.GetLength(0)];
            int[,] D = new int[W.GetLength(0), W.GetLength(0)];
            P = floydAlgoritm2(W.GetLength(0), W, D,P);
            Path(P, 4, 2);
            //int[,] arr2 = floydAlgoritm(arr1 , arr1.GetLength(0));
            //for (int i = 0; i < arr1.GetLength(0); i++)
            //{
            //    for (int j = 0; j < arr1.GetLength(1); j++)
            //    {
            //        Console.Write(arr1[i, j] + "\t");
            //    }
            //    Console.WriteLine("\n");
            //}
            //printFloydPath(arr1, arr2, 5);
            Console.ReadKey();
        }
    }
}
