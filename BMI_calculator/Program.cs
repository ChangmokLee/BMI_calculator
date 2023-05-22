using System;

class Program
{
    static void Main()
    {
        Console.WriteLine("BMI Calculator");
        Console.WriteLine("==============");

        Console.Write("Enter your weight in kilograms: ");
        double weight = ReadDoubleInput();

        Console.Write("Enter your height in meters: ");
        double height = ReadDoubleInput();

        double bmi = CalculateBMI(weight, height);
        string category = GetBMICategory(bmi);

        Console.WriteLine($"Your BMI is: {bmi:F2}");
        Console.WriteLine($"BMI Category: {category}");

        Console.WriteLine("\nWhat would you like to do next?");
        Console.WriteLine("1. Calculate BMI again");
        Console.WriteLine("2. Get BMI range information");
        Console.WriteLine("3. Calculate Ideal Weight");
        Console.WriteLine("4. Exit");
        Console.Write("Enter your choice (1-4): ");
        int choice = ReadIntInput(1, 4);

        switch (choice)
        {
            case 1:
                Console.Clear();
                Main();
                break;
            case 2:
                Console.WriteLine("\nBMI Ranges");
                Console.WriteLine("==========");
                PrintBMIRanges();
                Console.ReadLine();
                break;
            case 3:
                Console.WriteLine("\nIdeal Weight Calculation");
                Console.WriteLine("========================");
                CalculateIdealWeight(height);
                Console.ReadLine();
                break;
            case 4:
                Console.WriteLine("\nThank you for using the BMI Calculator. Goodbye!");
                break;
        }
    }

    static double CalculateBMI(double weight, double height)
    {
        return weight / (height * height);
    }

    static string GetBMICategory(double bmi)
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

    static void PrintBMIRanges()
    {
        Console.WriteLine("BMI Categories:");
        Console.WriteLine("---------------");
        Console.WriteLine("Underweight: Less than 18.5");
        Console.WriteLine("Normal weight: 18.5 - 24.9");
        Console.WriteLine("Overweight: 25 - 29.9");
        Console.WriteLine("Obese: 30 or greater");
    }

    static void CalculateIdealWeight(double height)
    {
        Console.Write("Enter your gender (M/F): ");
        string gender = ReadGenderInput();

        double idealWeight;
        if (gender.ToUpper() == "M")
            idealWeight = 22 * (height * height);
        else
            idealWeight = 21 * (height * height);

        Console.WriteLine($"Your ideal weight is: {idealWeight:F2} kg");
    }

    static string ReadGenderInput()
    {
        string gender = Console.ReadLine().ToUpper();
        while (gender != "M" && gender != "F")
        {
            Console.Write("Invalid input. Please enter 'M' or 'F': ");
            gender = Console.ReadLine().ToUpper();
        }
        return gender;
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