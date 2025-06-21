using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;

class Program
{
    public static void Main(string[] args)
    {
        var BookByPrice = new SortedDictionary<decimal?, int>();

        BookByPrice.Add(10, 3);
        BookByPrice.Add(10.5m, 4);
        BookByPrice.Add(10.51m, 5);
        BookByPrice.Add(10.529m, 7);
        BookByPrice.Add(10.541m, 10);

        var book = new BindingList<int>();

        foreach (var b in BookByPrice.Keys)
        {
            book.Add(BookByPrice[b]);
        }

        var valueToAddOnBook = 10.54m;

        var teste = NearestSmallDecimal(BookByPrice.Keys.ToList(), valueToAddOnBook);

        var index = book.IndexOf(BookByPrice[teste]);


        book.Insert(index + 1, 1);

        book.ToList().ForEach(x =>
        {
            Console.WriteLine(x);
        });

        Console.WriteLine("\n" + new string('=', 50));
        Tests.RunAllTests();

    }

    public static decimal NearestSmallDecimal(List<decimal?> bookValues, decimal newBookValue)
    {

        decimal nearestDecimal;
        int count = bookValues.Count();
        int mid = count / 2;
        var BookByPrice = bookValues[mid];

        if (newBookValue < BookByPrice)
        {
            nearestDecimal = (decimal)bookValues[mid];
            decimal difference = Math.Abs((decimal)bookValues[mid] - newBookValue);
            for (int i = mid - 1; i >= 0; i--)
            {
                decimal newDifference = Math.Abs((decimal)bookValues[i] - newBookValue);
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