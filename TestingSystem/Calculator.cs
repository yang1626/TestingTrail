using System;

namespace TestingSystem
{
    public class Calculator
    {
        public int Add(int a,int b)
        {
            return a + b;
        }

        public int Sub(int a,int b)
        {
            return a - b;
        }

        public int DivideDirectly(int a,int b)
        {
            return a / b;
        }

        public int Divide(int a, int b)
        {
            if (b==0) throw new ArgumentOutOfRangeException("divideByZero");
            return a / b;
        }

        public decimal Divide(decimal a,decimal b)
        {
            if (b == 0) b = 1;
            return a / b;
        }
    }
}
