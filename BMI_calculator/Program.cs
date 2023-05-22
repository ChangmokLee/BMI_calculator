using System;

abstract class Calculator
{
    public abstract void Calculate(double weight, double height);
}

class BMICalculator : Calculator
{
    public override void Calculate(double weight, double height)
    {
        double bmi = CalculateBMI(weight, height);
        string category = GetBMICategory(bmi);

        Console.WriteLine($"Your BMI is: {bmi:F2}");
        Console.WriteLine($"BMI Category: {category}");
    }

    private double CalculateBMI(double weight, double height)
    {
        double weightInPounds = ConvertKilogramsToPounds(weight);
        double heightInInches = ConvertMetersToInches(height);

        return (weightInPounds / (heightInInches * heightInInches)) * 703; // Multiply by 703 for the BMI calculation in the US customary units
    }

    private double ConvertKilogramsToPounds(double kilograms)
    {
        return kilograms * 2.20462; // Conversion factor for kilograms to pounds
    }

    private double ConvertMetersToInches(double meters)
    {
        return meters * 39.3701; // Conversion factor for meters to inches
    }

    private string GetBMICategory(double bmi)
    {
        if (bmi < 18.5)
            return "Underweight";
        else if (bmi < 25)
            return "Normal weight";
        else if (bmi < 30)
            return "Overweight";
        else
            return "Obese";
    }
}

class Program
{
    static void Main()
    {
        Console.WriteLine("BMI Calculator");
        Console.WriteLine("==============");

        bool retry = false;

        do
        {
            Console.Write("Enter your weight in pounds: ");
            double weight = ReadDoubleInput();

            Console.Write("Enter your height in inches: ");
            double height = ReadDoubleInput();

            Calculator calculator = new BMICalculator();
            calculator.Calculate(weight, height);

            Console.WriteLine("\nWhat would you like to do next?");
            Console.WriteLine("1. Calculate BMI again");
            Console.WriteLine("2. Exit");
            Console.Write("Enter your choice (1-2): ");
            int choice = ReadIntInput(1, 2);

            retry = (choice == 1);

            Console.Clear();
        }
        while (retry);

        Console.WriteLine("Thank you for using the BMI Calculator. Goodbye!");
        Console.ReadLine();
    }

    static double ReadDoubleInput()
    {
        double value;
        while (!double.TryParse(Console.ReadLine(), out value))
        {
            Console.Write("Invalid input. Please enter a valid number: ");
        }
        return value;
    }

    static int ReadIntInput(int minValue, int maxValue)
    {
        int value;
        while (!int.TryParse(Console.ReadLine(), out value) || value < minValue || value > maxValue)
        {
            Console.Write($"Invalid input. Please enter a number between {minValue} and {maxValue}: ");
        }
        return value;
    }
}
