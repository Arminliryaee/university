public abstract class AbstractEmployee : IEmployee
{
    public string FirstName { get; }
    public string LastName { get; }
    public string NationalCode { get; }
    public int Level { get; }
    public double BaseSalary { get; } = 10;
    public double TotalHoursInMonth { get; }
    public double ExtraHours { get; }
    public int Bime { get; }

    protected AbstractEmployee(string firstName, string lastName, string nationalCode,
        int level, double baseSalary, double totalHours, double extraHours, int Bime)
    {
        if (extraHours < 0 || extraHours > 40)
            throw new ArgumentException("Overtime limit has been reached!");
        FirstName = firstName;
        LastName = lastName;
        NationalCode = nationalCode;
        Level = level;
        BaseSalary = baseSalary;
        TotalHoursInMonth = totalHours;
        ExtraHours = extraHours;
        Bime = Bime;
    }

    protected virtual double EmployeeRatio { get; }

    public override string ToString()
    {
        return $"{FirstName} {LastName} ,{NationalCode} \n  Salary: ${CalculateSalary()}";
    }

    public virtual double CalculateSalary()
    {
        double basePart = BaseSalary * Level * EmployeeRatio * TotalHoursInMonth;
        double overtimePart = BaseSalary * ExtraHours * Level * EmployeeRatio * 1.2;
        return basePart + overtimePart;
    }
}
