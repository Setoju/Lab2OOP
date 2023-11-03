using System;
using System.Collections.Generic;
using System.Text;

namespace Lab2OOP
{
    partial class MyMatrix
    {        
        public static MyMatrix operator +(MyMatrix firstMatrix, MyMatrix secondMatrix)
        {            
            try
            {
                double[,] sumArray = new double[firstMatrix._matrix.GetLength(0), firstMatrix._matrix.GetLength(1)];
                for (int i = 0; i < firstMatrix._matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < firstMatrix._matrix.GetLength(1); j++)
                    {
                        sumArray[i, j] = firstMatrix._matrix[i, j] + secondMatrix._matrix[i, j];
                    }
                }
                return new MyMatrix(sumArray);
            }
            catch (Exception)
            {
                throw new Exception("Matrix hsould be the same size!");
            }
        }  
        public static MyMatrix operator *(MyMatrix firstMatrix, MyMatrix secondMatrix)
        {                    
            try
            {
                double[,] multiplicationArray = new double[firstMatrix._matrix.GetLength(0), secondMatrix._matrix.GetLength(1)];
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
                        multiplicationArray[i, j] = sum;
                    }
                }
                return new MyMatrix(multiplicationArray);
            }
            catch (Exception)
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
