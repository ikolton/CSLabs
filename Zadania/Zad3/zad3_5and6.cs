using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Proxies;

namespace Zad3_5and6
{
    internal class zad3_5and6
    {
        public static void Main(string[] args)
        {
            SquareMatrix<Complex<int>> matrix;
            matrix = new SquareMatrix<Complex<int>>();
            matrix.Add(matrix);
            matrix.Multiply(matrix);
            matrix.IsDiagonal();
        }
        
       
    }
    
    //Matrix class with generic types such as double float int
    class Matrix<T> where T : IComparable, IFormattable
    {
        public Matrix<T> Add(Matrix<T> matrix)
        {
            Console.WriteLine("Add");
            return matrix;
        }
        
        public Matrix<T> Multiply(Matrix<T> matrix)
        {
            Console.WriteLine("Multiply");
            return matrix;
        }
        
    }
    
    //square Matrix class that inherits after Matrix class
    class SquareMatrix<T> : Matrix<T> where T : IComparable, IFormattable
    {
        public bool IsDiagonal()
        {
            Console.WriteLine("IsDiagonal");
            return true;
        }
    }

    public class Complex<T> : IComparable, IFormattable where T : IComparable, IFormattable
    {
        public int CompareTo(object obj)
        {
            throw new NotImplementedException();
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            throw new NotImplementedException();
        }
    }

}