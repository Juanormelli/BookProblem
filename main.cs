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

      if(bookValues.First() > newBookValue) return (decimal)bookValues.First();
      if(bookValues.Last() < newBookValue) return (decimal)bookValues.Last();

        decimal nearestDecimal;
        int count = bookValues.Count();
        int mid = count / 2;
        var BookByPrice = bookValues[mid];

        if (newBookValue < BookByPrice)
        {
            nearestDecimal = (decimal)bookValues[mid];
            decimal difference = (decimal)bookValues[mid] - newBookValue;
            for (int i = mid - 1; i >= 0; i--)
            {
                decimal newDifference = (decimal)bookValues[i] - newBookValue;

                if (newDifference < difference && bookValues[i] < newBookValue)
                {
                    nearestDecimal = (decimal)bookValues[i];
                    difference = newDifference;
                }
            }

        }
        else
        {
            nearestDecimal = (decimal)bookValues[mid];
            decimal difference = Math.Abs((decimal)bookValues[mid] - newBookValue);
            for (int i = mid + 1; i <= count - 1; i++)
            {
                decimal newDifference = Math.Abs((decimal)bookValues[i] - newBookValue);
                if (newDifference < difference && bookValues[i] < newBookValue)
                {
                    nearestDecimal = (decimal)bookValues[i];
                    difference = newDifference;
                }
            }
        }

        return nearestDecimal;
    }


}