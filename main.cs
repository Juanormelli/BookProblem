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

      if((decimal)bookValues.First() > newBookValue) return 0;
      if((decimal)bookValues.Last() < newBookValue) return decimal.MaxValue;

        decimal nearestDecimal;
        int count = bookValues.Count();
        int mid = count  / 2;
        var BookByPrice = bookValues[mid];

        if (newBookValue < BookByPrice)
        {
            nearestDecimal = (decimal)bookValues[mid - 1];
            decimal difference = Math.Abs((decimal)bookValues[mid - 1] - newBookValue);
            for (int i = mid - 1; i >= 0; i--)
            {
                decimal newDifference = Math.Abs((decimal)bookValues[i] - newBookValue);
                Console.WriteLine(newDifference + "    " + difference);
                if (newDifference <= difference && bookValues[i] < newBookValue)
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
                if (newDifference <= difference && bookValues[i] < newBookValue)
                {
                    nearestDecimal = (decimal)bookValues[i];
                    difference = newDifference;
                }
            }
        }

        return nearestDecimal;
    }


}