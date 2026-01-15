// Simple C# Calculator Console App
Console.WriteLine("=== Simple Calculator ===");
Console.WriteLine();

bool continueCalculating = true;

while (continueCalculating)
{
    // Get first number
    Console.Write("Enter first number: ");
    if (!double.TryParse(Console.ReadLine(), out double num1))
    {
        Console.WriteLine("Invalid number. Please try again.");
        Console.WriteLine();
        continue;
    }

    // Get operation
    Console.Write("Enter operation (+, -, *, /): ");
    string? operation = Console.ReadLine();

    // Get second number
    Console.Write("Enter second number: ");
    if (!double.TryParse(Console.ReadLine(), out double num2))
    {
        Console.WriteLine("Invalid number. Please try again.");
        Console.WriteLine();
        continue;
    }

    // Perform calculation
    double result = 0;
    bool validOperation = true;

    switch (operation)
    {
        case "+":
            result = num1 + num2;
            break;
        case "-":
            result = num1 - num2;
            break;
        case "*":
            result = num1 * num2;
            break;
        case "/":
            if (num2 == 0)
            {
                Console.WriteLine("Error: Cannot divide by zero!");
                validOperation = false;
            }
            else
            {
                result = num1 / num2;
            }
            break;
        default:
            Console.WriteLine("Error: Invalid operation!");
            validOperation = false;
            break;
    }

    if (validOperation)
    {
        Console.WriteLine($"Result: {num1} {operation} {num2} = {result}");
    }

    Console.WriteLine();
    Console.Write("Do you want to perform another calculation? (yes/no): ");
    string? response = Console.ReadLine()?.ToLower();
    continueCalculating = response == "yes" || response == "y";
    Console.WriteLine();
}

Console.WriteLine("Thank you for using the calculator!");
