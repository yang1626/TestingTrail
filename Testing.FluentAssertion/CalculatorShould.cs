using FluentAssertions;
using System;
using TestingSystem;
using Xunit;

namespace Testing.FluentAssertion
{
    public class CalculatorShould
    {
        [Theory]
        [InlineData(1,1)]
        [InlineData(1, -1001)]
        [InlineData(1, 1000000)]
        [InlineData(1, 0)]
        [InlineData(0, 0)]
        [InlineData(-100,-100)]
        public void HasNoProblemWithAdd(int a,int b)
        {
            Calculator calculator = new Calculator();
            int sum = calculator.Add(a,b);
            sum.Should().Be(a+b);
        }

        [Theory]
        [InlineData(0, 1)]
        [InlineData(2, 5)]
        public void HasNoProblemWithNegativeResult(int a, int b)
        {
            Calculator calculator = new Calculator();
            int sub = calculator.Sub(a, b);
            sub.Should().BeNegative();    
        }

        [Theory]
        [InlineData(5,2)]
        [InlineData(1,0)]
        [InlineData(10000,99)]
        public void HasNoProblemWithPositiveResult(int a, int b)
        {
            Calculator calculator = new Calculator();
            int sub = calculator.Sub(a, b);
            sub.Should().BePositive();
        }

        [Theory]
        [InlineData(1,0)]
        public void HasProblemWithDirectlyDivideZero(int a,int b)
        {
            Calculator calculator = new Calculator();
            Action action = () => calculator.DivideDirectly(a, b);
            action.Should().Throw<DivideByZeroException>();
        }

        [Theory]
        [InlineData(1, 0)]
        public void HasProblemWithDivideZero(int a, int b)
        {
            Calculator calculator = new Calculator();
            Action action = () => calculator.Divide(a, b);
            action.Should().Throw<ArgumentOutOfRangeException>()
                            .And
                            .ParamName.Should().Be("divideByZero");
        }

        [Theory]
        [InlineData(1.0,3,0.33)]
        public void WorkWellWithDecimalPrecisionRange(decimal a,decimal b, decimal exceptResult)
        {
            Calculator calculator = new Calculator();
            decimal result=calculator.Divide(a,b);

            decimal precision = 0.01m;
            result.Should().BeApproximately(exceptResult, precision);
        }
    }
}
