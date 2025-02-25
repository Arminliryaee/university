public static class EmployeeFactory
{
    private const double MinimumBaseSalary = 10;
    private const double MaximumBaseSalary = 100;
    private const double MaxOvertime = 40;

    public static IEmployee CreateEmployee(
        EmployeeType type,
        string firstName,
        string lastName,
        string nationalCode,
        int level,
        double baseSalary,
        double totalHours,
        double extraHours,
        int Bime)
    {
        if (!NationalCodeValidator.IsValid(nationalCode))
            throw new ArgumentException("Invalid national code");

        if (baseSalary < MinimumBaseSalary || baseSalary > MaximumBaseSalary)
            throw new ArgumentException("Base salary out of range");

        if (extraHours < 0 || extraHours > MaxOvertime)
            throw new ArgumentException("Overtime hours exceed limit");

        if (level < 1)
            throw new ArgumentException("Invalid level");

        return type switch
        {
            EmployeeType.Simple => new SimpleEmployee(firstName, lastName, nationalCode, level, baseSalary, totalHours, extraHours, Bime),
            EmployeeType.Senior => new SeniorEmployee(firstName, lastName, nationalCode, level, baseSalary, totalHours, extraHours, Bime),
            EmployeeType.DepartmentManager => new DepartmentManager(firstName, lastName, nationalCode, level, baseSalary, totalHours, extraHours, Bime),
            EmployeeType.DepartmentHead => new DepartmentHead(firstName, lastName, nationalCode, level, baseSalary, totalHours, extraHours, Bime),
            EmployeeType.Deputy => new Deputy(firstName, lastName, nationalCode, level, baseSalary, totalHours, extraHours, Bime),
            EmployeeType.CEO => new CEO(firstName, lastName, nationalCode, level, baseSalary, totalHours, extraHours, Bime),
            _ => throw new ArgumentException("Invalid employee type")
        };
    }
}