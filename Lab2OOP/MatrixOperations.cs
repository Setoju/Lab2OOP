using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lab2OOP
{
    partial class MyMatrix
    {        
        public static MyMatrix operator +(MyMatrix firstMatrix, MyMatrix secondMatrix)
        {
            int firstMatrixWidth = firstMatrix._matrix.GetLength(1);
            int firstMatrixHeight = firstMatrix._matrix.GetLength(0);
            int secondMatrixWidth = secondMatrix._matrix.GetLength(1);
            int secondMatrixHeight = secondMatrix._matrix.GetLength(0);
            if (firstMatrixWidth == secondMatrixWidth && firstMatrixHeight == secondMatrixHeight)
            {
                double[,] sumArray = new double[firstMatrixHeight, firstMatrixWidth];
                for (int i = 0; i < firstMatrixHeight; i++)
                {
                    for (int j = 0; j < firstMatrixWidth; j++)
                    {
                        sumArray[i, j] = firstMatrix._matrix[i, j] + secondMatrix._matrix[i, j];
                    }
                }
                return new MyMatrix(sumArray);
            }
            else
            {
                throw new Exception("Matrix should be the same size!");
            }
        }  
        public static MyMatrix operator *(MyMatrix firstMatrix, MyMatrix secondMatrix)
        {
            if (firstMatrix._matrix.GetLength(1) == secondMatrix._matrix.GetLength(0))
            {
                double[,] result = new double[firstMatrix._matrix.GetLength(0), secondMatrix._matrix.GetLength(1)];
                double sum = 0;
                for (int i = 0; i < firstMatrix._matrix.GetLength(0); i++)
                {                    
                    for (int j = 0; j < secondMatrix._matrix.GetLength(1); j++)
                    {
                        sum = 0;
                        for (int k = 0; k < firstMatrix._matrix.GetLength(1); k++)
                        {
                            sum += firstMatrix._matrix[i, k] * secondMatrix._matrix[k, j];
                        }
                        result[i, j] = sum;
                    }
                }
                return new MyMatrix(result);
            }
            else
            {
                throw new Exception("The number of cols in first matrix should be equal to the number of rows in second matrix!");
            }
        }  
        private double[,] GetTransponedArray()
        {
            int width = _matrix.GetLength(0);
            int height = _matrix.GetLength(1);
            double[,] result = new double[height,width];
            for (int i = 0; i < width; i++)
            {
                for (int j = 0; j < height; j++)
                {
                    result[j, i] = _matrix[i, j];
                }
            }
            return result;
        }
        public MyMatrix GetTransponedCopy()
        {
            return new MyMatrix(GetTransponedArray());
        }
        public void TransponeMe()
        {
            this._matrix = GetTransponedArray();
        }
    }
}
