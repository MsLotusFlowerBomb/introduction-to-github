// Simple C# Calculator Console App using OOP principles
using System;
using System.Linq;

namespace CalculatorApp
{
    /// <summary>
    /// Main program class that handles user interaction
    /// </summary>
    class Program
    {
        static void Main(string[] args)
        {
            var app = new CalculatorApplication();
            app.Run();
        }
    }

    /// <summary>
    /// Calculator application class that manages the user interface and workflow
    /// </summary>
    public class CalculatorApplication
    {
        private readonly Calculator _calculator;
        private readonly InputValidator _inputValidator;

        public CalculatorApplication()
        {
            _calculator = new Calculator();
            _inputValidator = new InputValidator();
        }

        /// <summary>
        /// Runs the calculator application
        /// </summary>
        public void Run()
        {
            DisplayWelcomeMessage();

            bool continueCalculating = true;
            while (continueCalculating)
            {
                PerformCalculation();
                continueCalculating = AskToContinue();
            }

            DisplayExitMessage();
        }

        private void DisplayWelcomeMessage()
        {
            Console.WriteLine("=== Simple Calculator ===");
            Console.WriteLine();
        }

        private void DisplayExitMessage()
        {
            Console.WriteLine("Thank you for using the calculator!");
        }

        private void PerformCalculation()
        {
            // Get first number
            if (!_inputValidator.TryGetNumber("Enter first number: ", out double num1))
            {
                Console.WriteLine("Invalid number. Please try again.");
                Console.WriteLine();
                return;
            }

            // Get operation
            Console.Write("Enter operation (+, -, *, /): ");
            string? operation = Console.ReadLine();

            if (!_inputValidator.IsValidOperation(operation))
            {
                Console.WriteLine("Error: Invalid operation!");
                Console.WriteLine();
                return;
            }

            // Get second number
            if (!_inputValidator.TryGetNumber("Enter second number: ", out double num2))
            {
                Console.WriteLine("Invalid number. Please try again.");
                Console.WriteLine();
                return;
            }

            // Perform calculation
            try
            {
                double result = _calculator.Calculate(num1, num2, operation!);
                Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
            }
            catch (DivideByZeroException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }
            catch (InvalidOperationException ex)
            {
                Console.WriteLine($"Error: {ex.Message}");
            }

            Console.WriteLine();
        }

        private bool AskToContinue()
        {
            Console.Write("Do you want to perform another calculation? (yes/no): ");
            string? response = Console.ReadLine()?.ToLower();
            Console.WriteLine();
            return response == "yes" || response == "y";
        }
    }

    /// <summary>
    /// Calculator class that performs arithmetic operations
    /// </summary>
    public class Calculator
    {
        /// <summary>
        /// Performs the specified operation on two numbers
        /// </summary>
        public double Calculate(double num1, double num2, string operation)
        {
            return operation switch
            {
                "+" => Add(num1, num2),
                "-" => Subtract(num1, num2),
                "*" => Multiply(num1, num2),
                "/" => Divide(num1, num2),
                _ => throw new InvalidOperationException($"Invalid operation: {operation}")
            };
        }

        /// <summary>
        /// Adds two numbers
        /// </summary>
        public double Add(double a, double b) => a + b;

        /// <summary>
        /// Subtracts the second number from the first
        /// </summary>
        public double Subtract(double a, double b) => a - b;

        /// <summary>
        /// Multiplies two numbers
        /// </summary>
        public double Multiply(double a, double b) => a * b;

        /// <summary>
        /// Divides the first number by the second
        /// </summary>
        /// <exception cref="DivideByZeroException">Thrown when attempting to divide by zero</exception>
        public double Divide(double a, double b)
        {
            if (b == 0)
            {
                throw new DivideByZeroException("Cannot divide by zero!");
            }
            return a / b;
        }
    }

    /// <summary>
    /// Input validator class that handles user input validation
    /// </summary>
    public class InputValidator
    {
        private readonly string[] _validOperations = { "+", "-", "*", "/" };

        /// <summary>
        /// Attempts to get a valid number from user input
        /// </summary>
        public bool TryGetNumber(string prompt, out double number)
        {
            Console.Write(prompt);
            return double.TryParse(Console.ReadLine(), out number);
        }

        /// <summary>
        /// Checks if the operation is valid
        /// </summary>
        public bool IsValidOperation(string? operation)
        {
            return operation != null && _validOperations.Contains(operation);
        }
    }
}
