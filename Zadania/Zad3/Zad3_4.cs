using System;
using System.Runtime.ConstrainedExecution;
using System.Runtime.Remoting.Proxies;

namespace Zad3_4
{
    //complex class with real and imaginary part with 2 generic types
    public class Complex<T1, T2>
    {
        public T1 real { get; set; }
        public T2 imaginary { get; set; }
        
        public Complex(T1 real, T2 imaginary)
        {
            this.real = real;
            this.imaginary = imaginary;
        }
        
        public T1 ReturnReal()
        {
            return real;
        }
        
        public T2 ReturnImaginary()
        {
            return imaginary;
        }
        
    }
    
}