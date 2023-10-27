using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Lab2OOP
{    
    partial class MyMatrix
    {
        private double[,] _matrix;
        //Constructors                
        public MyMatrix(MyMatrix other)
        {
            _matrix = (double[,])other._matrix.Clone();            
        }
        public MyMatrix(double[,] matrix)
        {
            _matrix = matrix;
        }
        public MyMatrix(double[][] matrix) 
        {
            if (IsRectangular(matrix))
            {
                double[,] result = new double[matrix.GetLength(0),matrix.GetLength(1)];
                for (int i = 0; i < matrix.GetLength(0); i++)
                {
                    for (int j = 0; j < matrix.GetLength(1); j++)
                    {
                        result[i, j] = matrix[i][j];
                    }
                }
                _matrix = result;
            }
            else
            {
                throw new Exception("The array should be rectangular!");
            }
            //try
            //{
            //    for (int i = 0; i < matrix.GetLength(0); i++)
            //    {
            //        for (int j = 0; j < matrix.GetLength(1); j++)
            //        {
            //            _matrix[i, j] = matrix[i][j];
            //        }
            //    }
            //}
            //catch (Exception)
            //{
            //    throw new Exception("The array should be rectangular!");
            //}
        }
        public MyMatrix(string[] matrix)
        {
            try
            {
                double[,] result = new double[matrix.Length ,matrix[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length];
                for (int i = 0; i < matrix.Length; i++)
                {
                    string[] input = matrix[i].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < matrix[0].Length; j++)
                    {                        
                        result[i, j] = Convert.ToInt32(input[j]);
                    }
                }
                _matrix = result;
            }
            catch (Exception)
            {
                throw new Exception("Amount of numbers in each string should be equal!");
            }
        }
        public MyMatrix(string matrix)
        {
            try
            {                
                string[] stringIntoArray = matrix.Split("\\n");                
                double[,] result = new double[stringIntoArray.Length, stringIntoArray[0].Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries).Length];
                for (int i = 0; i < stringIntoArray.Length; i++)
                {
                    string[] input = stringIntoArray[i].Trim().Split(new string[] { " " }, StringSplitOptions.RemoveEmptyEntries);
                    for (int j = 0; j < input.Length; j++)
                    {                        
                        result[i, j] = Convert.ToInt32(input[j]);
                    }
                }
                _matrix = result;
            }
            catch (Exception)
            {
                throw new Exception("Can't create rectangular matrix. The string should follow input rules!");
            }
        }
        //Properties
        public double Height
        {
            get
            {
                return _matrix.GetLength(0);
            }
        }
        public double Width
        {
            get 
            {
                return _matrix.GetLength(1); 
            }
        }
        //Indexator
        public double this[int rowIndex, int colIndex]
        {
            get
            {
                return _matrix[rowIndex,colIndex];
            }
            set
            {
                _matrix[rowIndex, colIndex] = value;
            }
        }
        //Java-style getters
        public double GetHeight()
        {
            return _matrix.GetLength(0);
        }
        public double GetWidth()
        {
            return _matrix.GetLength(1);
        }
        //Java-style getters and setters for specific element
        public double GetElement(int rowIndex, int colIndex)
        {
            return _matrix[rowIndex, colIndex];
        }
        public void SetElement(int rowIndex, int colIndex, double value)
        {
            _matrix[rowIndex, colIndex] = value;
        }
        //Another case of making one of the constructors with the double[][] input
        public bool IsRectangular(double[][] matrix)
        {
            foreach (double[] array in matrix)
            {
                if (array.Length != matrix[0].Length)
                {
                    return false;
                }
            }
            return true;
        }
        public override string ToString()
        {
            StringBuilder result = new StringBuilder();
            result.Append("\n");
            for (int i = 0; i < _matrix.GetLength(0); i++)
            {
                for (int j = 0; j < _matrix.GetLength(1); j++)
                {
                    result.Append(Convert.ToString(_matrix[i,j]) + " ");                    
                }
                result.Append("\n");                
            }
            return Convert.ToString(result);            
        }
    }
}
