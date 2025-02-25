public interface IEmployee
{
    string FirstName { get; }
    string LastName { get; }
    string NationalCode { get; }
    int Level { get; }
    double BaseSalary { get; }
    double TotalHoursInMonth { get; }
    double ExtraHours { get; }
    int Bime { get; }
    double CalculateSalary();
}
