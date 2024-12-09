using System;

class MagicSquareChecker
{
    static void Main()
    {
        Console.Write("Enter the size of the matrix (n x n):for example for (3 x 3) enter \'3 ");
        int n = int.Parse(Console.ReadLine());

        int[,] matrix = new int[n, n];

        Console.WriteLine("Enter the elements of the matrix: ()");
        for (int i = 0; i < n; i++)
        {
            for (int j = 0; j < n; j++)
            {
                matrix[i, j] = int.Parse(Console.ReadLine());
            }
        }

        if (IsMagicSquare(matrix, n))
        {
            Console.WriteLine("The matrix is a magic square.");
        }
        else
        {
            Console.WriteLine("The matrix is not a magic square.");
        }
    }

    static bool IsMagicSquare(int[,] matrix, int n)
    {
        int magicSum = 0;

         
        for (int j = 0; j < n; j++)
        {
            magicSum += matrix[0, j];
        }

        for (int i = 0; i < n; i++)
        {
            int rowSum = 0;
            for (int j = 0; j < n; j++)
            {
                rowSum += matrix[i, j];
            }
            if (rowSum != magicSum)
                return false;
        }

        for (int j = 0; j < n; j++)
        {
            int colSum = 0;
            for (int i = 0; i < n; i++)
            {
                colSum += matrix[i, j];
            }
            if (colSum != magicSum)
                return false;
        }

        int mainDiagonalSum = 0;
        for (int i = 0; i < n; i++)
        {
            mainDiagonalSum += matrix[i, i];
        }
        if (mainDiagonalSum != magicSum)
            return false;

        int secondaryDiagonalSum = 0;
        for (int i = 0; i < n; i++)
        {
            secondaryDiagonalSum += matrix[i, n - 1 - i];
        }
        if (secondaryDiagonalSum != magicSum)
            return false;

        return true; 
    }
}