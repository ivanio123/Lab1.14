using System;
using System.Globalization;
using System.Linq;

namespace Lab1._14
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Enter the number of elements: ");
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine("Your array X is:");
            int[] arr = CreateArrayRandomly(n);
            PrintArray(arr);
            int [,] matrixC = ArrayToMatrix(arr);
            Console.WriteLine("Square matrix C:");
            PrintMatrix(matrixC);
            SortRowsDescendant(matrixC);
            Console.WriteLine("Square matrix C after sorting rows in descending order:");
            PrintMatrix(matrixC);
            int[][] jaggedY = CreateRandomJaggedArray(matrixC);
            Console.WriteLine("Jagged array Y:");
            PrintJaggedMatrix(jaggedY);
            int sum = SumOfElements(jaggedY);
            Console.WriteLine("Sum of elements in jagged array Y is "+ sum);
            Console.ReadKey();
        }
        static void PrintMatrix(int[,] matrix)
        {
            var rows = matrix.GetLength(0);
            var columns = matrix.GetLength(1);
            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < columns; j++)
                {
                    Console.Write("{0,-5}", matrix[i, j]);
                }
                Console.WriteLine();
            }
        }
        static void PrintJaggedMatrix(int[][] matrix)
        {
            for (int i = 0; i < matrix.Length; i++)
            {
                for (int j = 0; j < matrix[i].Length; j++)
                {
                    Console.Write("{0,-5}", matrix[i][j]);
                }
                Console.WriteLine();
            }
        }
      
        static int[] CreateArrayRandomly(int n) 
        {
            Random r = new Random();
            int[] arr = new int[n];
            for (int i = 0; i < n; i++)
            {
                arr[i] = r.Next(0, 10);
                
            }
            return arr;
        }
       static void PrintArray(int[] arr) 
        {
            for (int i = 0; i < arr.GetLength(0); i++)
            {
                Console.Write(string.Format("{0} ", arr[i]));
            }
        }
    static int[,] ArrayToMatrix(int[] array)
        {
            int n = array.Length;
            int[,]matrixC = new int[n, n];
            for (int i = 0; i < n; i++)
            {
                for (int j = 0; j < n; j++)
                {
                    matrixC[i, j] = array[i].CompareTo(array[j]) == 0 ? 1 : 0;
                }
            }
            return matrixC;
        }
        static void SortRowsDescendant(int[,] matrix)
        {
            for (int i = 0; i < matrix.GetLength(0); i++)
            {
                for (int j = 0; j < matrix.GetLength(1) - 1; j++)
                {
                    for (int k = j + 1; k < matrix.GetLength(1); k++)
                    {
                        if (matrix[i, j] < matrix[i, k])
                        {
                            int temp = matrix[i, j];
                            matrix[i, j] = matrix[i, k];
                            matrix[i, k] = temp;
                        }
                    }
                }
            }
        }
        static int[][] CreateRandomJaggedArray(int[,] matrix)
        {
            Random r = new Random();
            int rows = matrix.GetLength(0);
            int[][] jaggedArray = new int[rows][];
            for (int i = 0; i < rows; i++)
            {
                int onesCounter = GetOnesCount(matrix, i);
                if (onesCounter > 0)
                {
                    jaggedArray[i] = Enumerable.Range(0, onesCounter).Select(j => r.Next(1, 30)).ToArray();
                }
            
                else
                {
                    jaggedArray[i] = new int[0];
                }
            }
            return jaggedArray;
        }
        static int GetOnesCount(int[,] matrix, int row)
        {
            int counter = 0;
            for (int j = 0; j < matrix.GetLength(1); j++)
            {
                counter += matrix[row, j] == 1 ? 1 : 0;
            }
            return counter;
        }
        static int SumOfElements(int[][] matrix)
        {
            int sum = 0;
            foreach (var item in matrix)
                foreach (var j in item)
                {
                    sum += j;
                }
            return sum;
        }
    }
}
    
