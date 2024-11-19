using BasicExampleUnitTests;
using CalculatorForUnitTesting.Interfaces;

public class Program
{
    public static void Main(string[] args)
    {
        try
        {
            var realRepo = new NumberRep();
            var calculator = new Calculator(realRepo);

            Console.WriteLine($"Addition Result: {calculator.Add()}");
            Console.WriteLine($"Subtraction Result: {calculator.Subtract()}");
            Console.WriteLine($"Multiplication Result: {calculator.Multiply()}");

            try
            {
                Console.WriteLine($"Division Result: {calculator.Divide():F2}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Unhandled exception: {ex.Message}");
        }
        finally
        {
            Console.WriteLine("Press any key to exit...");
            Console.ReadKey();
        }
    }

    public class NumberRep : INumberRepository
    {
        private double _numberA;
        private double _numberB;

        public NumberRep()
        {
            _numberA = GetValidNumber();
            _numberB = GetValidNumber();
        }
        public double GetNumberA()
        {
            return _numberA;
        }

        public double GetNumberB()
        {
            return _numberB;
        }
    }

    public static double GetValidNumber()
    {
        double number;
        int currentQuantity = 0;
        int maxNumbers = 2;

        while (currentQuantity < maxNumbers)
        {
            Console.WriteLine("Type a number:");

            string input = Console.ReadLine();

            if (double.TryParse(input, out number))
            {
                return number;
            }
            else
            {
                Console.WriteLine("Invalid input. Please enter a valid number.");
                currentQuantity++;
            }
        }

        Console.WriteLine("Too many invalid attempts. Exiting.");
        Environment.Exit(5);
        return 0;
    }
}
