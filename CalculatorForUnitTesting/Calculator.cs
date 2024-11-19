using CalculatorForUnitTesting;
using CalculatorForUnitTesting.Interfaces;
using System;

namespace BasicExampleUnitTests
{
    public class Calculator
    {
        private readonly INumberRepository _numberRepository;

        public Calculator(INumberRepository numberRepository)
        {
            _numberRepository = numberRepository ?? throw new ArgumentNullException(nameof(numberRepository));
        }

        public double Add()
        {
            return _numberRepository.GetNumberA() + _numberRepository.GetNumberB();
        }

        public double Subtract()
        {
            return _numberRepository.GetNumberA() - _numberRepository.GetNumberB();
        }

        public double Multiply()
        {
            return _numberRepository.GetNumberA() * _numberRepository.GetNumberB();
        }

        public double Divide()
        {
            double numberB = _numberRepository.GetNumberB();

            if (numberB == 0)
                throw new DivideByZeroException("Division by zero is not allowed.");

            return _numberRepository.GetNumberA() / numberB;
        }
    }
}
