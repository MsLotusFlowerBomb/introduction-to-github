# Simple C# Calculator Console App

A console-based calculator application built with C# using Object-Oriented Programming (OOP) principles.

## Features

- Addition (+)
- Subtraction (-)
- Multiplication (*)
- Division (/)
- Division by zero error handling
- Option to perform multiple calculations in a single session

## Architecture (OOP Design)

The application follows object-oriented programming principles with the following classes:

### Classes

- **`Program`**: Entry point of the application
- **`CalculatorApplication`**: Manages the user interface and application workflow
  - Handles user interaction
  - Coordinates between input validation and calculation
- **`Calculator`**: Performs arithmetic operations
  - `Add(double a, double b)`: Addition operation
  - `Subtract(double a, double b)`: Subtraction operation
  - `Multiply(double a, double b)`: Multiplication operation
  - `Divide(double a, double b)`: Division operation with zero-check
  - `Calculate(double num1, double num2, string operation)`: Dispatcher method
- **`InputValidator`**: Validates user input
  - `TryGetNumber(string prompt, out double number)`: Validates numeric input
  - `IsValidOperation(string operation)`: Validates operation symbols

### OOP Concepts Demonstrated

- **Encapsulation**: Each class has a single, well-defined responsibility
- **Abstraction**: Implementation details hidden behind clean public interfaces
- **Separation of Concerns**: UI logic, validation, and calculation logic are separated
- **Exception Handling**: Custom exceptions for error conditions
- **XML Documentation**: Classes and methods are documented

## Requirements

- .NET 10.0 or later

## How to Build

```bash
cd Calculator
dotnet build
```

## How to Run

```bash
cd Calculator
dotnet run
```

## Usage

1. Enter the first number when prompted
2. Enter the operation (+, -, *, /)
3. Enter the second number when prompted
4. View the result
5. Choose whether to perform another calculation (yes/no)

## Example

```
=== Simple Calculator ===

Enter first number: 10
Enter operation (+, -, *, /): +
Enter second number: 5
Result: 10 + 5 = 15

Do you want to perform another calculation? (yes/no): no

Thank you for using the calculator!
```
