using System;
using System.Text;


namespace Lab2OOP
{    
    partial class MyMatrix
    {
        private double[,] _matrix;
        //Constructors                
        public MyMatrix(MyMatrix myMatrix) : this(myMatrix._matrix) 
        {

        }
        public MyMatrix(double[,] matrix)
        {            
            _matrix = (double[,])matrix.Clone();
        }
        public MyMatrix(double[][] matrix) 
        {
            _matrix = new double[matrix.Length, matrix[0].Length];
            int len = _matrix.GetLength(1);
            try
            {
                for (int i = 0; i < matrix.Length; i++)
                {
                    for (int j = 0; j < matrix[i].Length; j++)
                    {
                        if (matrix[i].Length != len) throw new ArgumentException();
                        _matrix[i, j] = matrix[i][j];
                    }
                }
            }
            catch (Exception)
            {
                Console.WriteLine("The array is not rectangular");
                throw;
            }
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
                throw new Exception("The array is not rectangular!");
            }
        }
        public MyMatrix(string matrix) : this(matrix.Split("\n")) 
        { 

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
