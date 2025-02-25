public static class EmployeeHelper
{
    public static EmployeeType GetEmployeeType()
    {
        while (true)
        {
            Console.WriteLine("\nEmployee Rank? :");
            Console.WriteLine("Simple             :'1' ");
            Console.WriteLine("Senior             :'2' ");
            Console.WriteLine("Department Manager :'3' ");
            Console.WriteLine("Department Head    :'4' ");
            Console.WriteLine("Deputy             :'5' ");
            Console.WriteLine("CEO                :'6' ");

            string input = Console.ReadLine();
            return input switch
            {
                "1" => EmployeeType.Simple,
                "2" => EmployeeType.Senior,
                "3" => EmployeeType.DepartmentManager,
                "4" => EmployeeType.DepartmentHead,
                "5" => EmployeeType.Deputy,
                "6" => EmployeeType.CEO,
                _ => throw new ArgumentException("Please enter between '1-6'")
            };
        }
    }

    public static string GetStringInput(string prompt)
    {
        while (true)
        {
            Console.Write(prompt);
            string input = Console.ReadLine()?.Trim();
            if (!string.IsNullOrWhiteSpace(input))
                return input;

            Console.WriteLine("Please enter valid data(cant be whitespace)");
        }
    }

    public static string GetValidNationalCode()
    {
        while (true)
        {
            Console.Write("Enter National Code (10 digits): ");
            string input = Console.ReadLine()?.Trim();
            if (NationalCodeValidator.IsValid(input))
                return input;

            Console.WriteLine("incorrect national code.");
        }
    }

    public static int GetValidInt(string prompt, int minValue)
    {
        while (true)
        {
            Console.Write(prompt);
            if (int.TryParse(Console.ReadLine(), out int value) && value >= minValue)
                return value;

            Console.WriteLine($"Please enter a valid data (≥ {minValue}).");
        }
    }

    public static double GetValidDouble(string prompt, double minValue, double maxValue)
    {
        while (true)
        {
            Console.Write(prompt);
            if (double.TryParse(Console.ReadLine(), out double value) && value >= minValue && value <= maxValue)
                return value;

            Console.WriteLine($"Please enter a valid data ({minValue} - {maxValue}).");
        }
    }
}
