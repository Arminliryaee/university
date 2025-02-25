public static class NationalCodeValidator
{
    public static bool IsValid(string Ncode)
    {
        if (string.IsNullOrWhiteSpace(Ncode) || Ncode.Length != 10 || !Ncode.All(char.IsDigit))
            return false;

        if (Ncode.All(c => c == '0'))
            return false;

        int sum = 0;
        for (int i = 0; i < 9; i++)
        {
            sum += (Ncode[i] - '0') * (10 - i);
        }

        int remainder = sum % 11;
        int checksum = Ncode[9] - '0';

        return (remainder < 2 && checksum == remainder) ||
               (remainder >= 2 && checksum == (11 - remainder));
    }
}
