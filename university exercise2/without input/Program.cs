try
{
    Console.WriteLine("Enter employee type");
    Console.Write("Simple:'1'\nSenior:'2'\nDepartment Manager:'3'\nDepartment Head:'4'\nDeputy:'5'\nCEO:'6'\n");

    string input = Console.ReadLine();
    EmployeeType employeeType = GetType(input);
    IEmployee employee = EmployeeFactory.CreateEmployee(
        employeeType,
        "armin",
        "liryaee",
        "0110530780",
        2,
        10,
        160,
        10,
        24);

    Console.WriteLine(employee.ToString());

}
catch (ArgumentException ex)
{
    Console.WriteLine($"Error creating employee: {ex.Message}");
}
static EmployeeType GetType(string input)
{

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