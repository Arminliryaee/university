public class SeniorEmployee(string firstName, string lastName, string nationalCode,
    int level, double baseSalary, double totalHours, double extraHours, int Bime) :
    AbstractEmployee(firstName, lastName, nationalCode, level, baseSalary, totalHours, extraHours, Bime)
{
    protected override double EmployeeRatio => 1.2;
}
