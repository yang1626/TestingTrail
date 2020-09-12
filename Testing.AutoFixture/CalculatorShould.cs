using AutoFixture;
using AutoFixture.Xunit2;
using System;
using TestingSystem;
using Xunit;

namespace Testing.AutoFixture
{
    public class CalculatorShould
    {
        [Fact]
        public void HasNoProblemWithAdd()
        {
            var fixture = new Fixture();
            int a = fixture.Create<int>();
            int b = fixture.Create<int>();
            Calculator calculator = new Calculator();
            int sum = calculator.Add(a, b);
            Assert.Equal(sum,a+b);
        }


        [Fact]
        public void HasNoProblemWithAddInjiectedNumber()
        {
            var fixture = new Fixture();
            fixture.Inject<int>(123);
            int a = fixture.Create<int>();
            int b = fixture.Create<int>();
            Calculator calculator = new Calculator();
            int sum = calculator.Add(a, b);
            Assert.Equal(246, sum);
        }

        [Theory]
        [AutoData]
        public void HasNoProblemWithAddWithAutoData(int a,int b)
        {
            Calculator calculator = new Calculator();
            int sum = calculator.Add(a, b);
            Assert.Equal(sum, a + b);
        }

        [Theory, AutoData]
        public void HasNoProblemWithAddAutoWithMoreAutoData(int a, int b, Calculator calculator)
        {
            int sum = calculator.Add(a, b);
            Assert.Equal(sum, a + b);
        }

    }
}
