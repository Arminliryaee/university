while (true)
{
    try
    {

        EmployeeType employeeType = EmployeeHelper.GetEmployeeType();
        string firstName = EmployeeHelper.GetStringInput("First Name :");
        string lastName = EmployeeHelper.GetStringInput("Last Name :");
        string nationalCode = EmployeeHelper.GetValidNationalCode();
        int level = EmployeeHelper.GetValidInt($"Enter {employeeType} Level (>=1): ", 1);
        double totalHours = EmployeeHelper.GetValidDouble("Enter Total Monthly Hours: ", 1, 300);
        double extraHours = EmployeeHelper.GetValidDouble("Enter Extra Hours (0 - 40): ", 0, 40);
        int Bime = EmployeeHelper.GetValidInt("Enter bime Duration (months): ", 0);
        double baseSalary = 10;

        IEmployee employee = EmployeeFactory.CreateEmployee(
            employeeType, firstName, lastName, nationalCode,
            level, baseSalary, totalHours, extraHours, Bime);

        Console.WriteLine(employee.ToString());

        Console.Write("\nFinished? (y/n): ");
        if (Console.ReadLine()?.Trim().ToLower() != "y")
            break;
    }
    catch (ArgumentException ex)
    {
        Console.WriteLine($"{ex.Message}");
        Console.WriteLine("Please enter the data again.\n");
    }
}
