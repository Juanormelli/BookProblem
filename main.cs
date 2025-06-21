using System;
using System.Collections.Generic;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        Console.WriteLine("\n" + new string('=', 50));

        Tests.RunAllTests();
        
    }

    public static decimal NearestSmallDecimal(List<decimal?> bookValues, decimal newBookValue)
    {
        var filtered = bookValues;

        if (bookValues.First() > newBookValue) return decimal.MinValue;
        if (bookValues.Last() < newBookValue) return decimal.MaxValue;

        int left = 0, right = bookValues.Count - 1;
        decimal result = decimal.MinValue;

        while (left <= right)
        {
            int mid = left + (right - left) / 2;
            if (filtered[mid] < newBookValue)
            {
                result = (decimal)bookValues[mid];
                left = mid + 1;
            }
            else
            {
                right = mid - 1;
            }
        }
        return result;
    }
}