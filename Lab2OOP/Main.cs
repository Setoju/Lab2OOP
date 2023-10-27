using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OOP
{
    public class Matrix
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Input rows:");
            int rows = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input cols");
            int cols = Convert.ToInt32(Console.ReadLine());
            Console.WriteLine("Input matrix");
            MyMatrix matrix = new MyMatrix(InputMatrix(rows, cols));
            MyMatrix matrix_2 = (MyMatrix)new MyMatrix(matrix);
            matrix[1, 0] = 0;
            Console.WriteLine(matrix_2);
            Console.WriteLine("The height of the matrix : " + matrix.Height);
            Console.WriteLine("The width of the matrix : " + matrix.Width);

            Console.WriteLine("The height of the matrix got in java-style : " + matrix.GetHeight());
            Console.WriteLine("The width of the matrix got in java-style : " + matrix.GetWidth());

            Console.WriteLine("Element of the matrix in place [0,0] : " + matrix[0, 0]);

            Console.WriteLine("Element of the matrix in place [0,0] got in java-style : " + matrix.GetElement(0, 0));
            matrix.SetElement(0, 0, -1);
            Console.WriteLine("Element [0,0] of the matrix has been changed to -1 ");
            Console.WriteLine("Your matrix : " + matrix);
            matrix.TransponeMe();
            Console.WriteLine("Transponed matrix : " + matrix);

            Console.WriteLine("Input matrix in one string");
            string input = Console.ReadLine();
            MyMatrix diffMatrix = new MyMatrix(input);
            //Console.WriteLine("Sum of two matrix : " + (matrix + diffMatrix));
            Console.WriteLine("Multiplication fo two matrix : " + (matrix * diffMatrix));
        }
        public static double[,] InputMatrix(int rows, int cols)
        {
            double[,] result = new double[rows, cols];
            for (int i = 0; i < rows; i++)
            {
                string[] input = Console.ReadLine().Trim().Split();
                for (int j = 0; j < cols; j++)
                {
                    result[i,j] = Convert.ToDouble(input[j]);
                }
            }
            return result;
        }
    }
}