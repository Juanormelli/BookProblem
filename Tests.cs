using System;
using System.Collections.Generic;

public static class Tests
{
    public static void RunAllTests()
    {
        Console.WriteLine("Running NearestSmallDecimal Tests...\n");

        TestCase1_NewValueSmallerThanAllItems();
        TestCase2_NewValueLargerThanAllItems();
        TestCase3_NewValueInMiddleRange();
        TestCase4_NewValueBetweenFirstTwoItems();
        TestCase5_NewValueBetweenLastTwoItems();
        TestCase6_SingleItemList();
        TestCase7_TwoItemList();
        TestCase8_LargeList();
        TestCase9_VerySmallDifferences();
        TestCase10_EdgeCaseWithLargeNumbers();
        TestCase11_EmptyList();
        TestCase12_NullValuesInList();
        TestCase13_DuplicateValues();
        TestCase14_VeryCloseValues();
        TestCase15_DecimalPrecision();
        TestCase16_ZeroInList();
        TestCase17_NewValueCloseToExisting();
        TestCase18_LargeGapsBetweenValues();
        TestCase19_AllSameValueExceptOne();
        TestCase20_ExtremelyLargeList();
        TestCase21_10KItems();
        TestCase22_100KItems();
        TestCase23_1MillionItems();

        Console.WriteLine("All tests completed!\n");
    }

    // Test when new value is smaller than all items in list
    private static void TestCase1_NewValueSmallerThanAllItems()
    {
        var bookValues = new List<decimal?> { 5.00m, 10.00m, 15.00m, 20.00m };
        decimal newBookValue = 2.50m;
        decimal expected = 0;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 1 - New value smaller than all: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test when new value is larger than all items in list
    private static void TestCase2_NewValueLargerThanAllItems()
    {
        var bookValues = new List<decimal?> { 5.00m, 10.00m, 15.00m, 20.00m };
        decimal newBookValue = 25.00m;
        decimal expected = decimal.MaxValue;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 2 - New value larger than all: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test when new value is in middle range
    private static void TestCase3_NewValueInMiddleRange()
    {
        var bookValues = new List<decimal?> { 1.00m, 5.00m, 10.00m, 15.00m, 20.00m };
        decimal newBookValue = 12.00m;
        decimal expected = 10.00m; // Nearest smaller value
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 3 - New value in middle range: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test when new value is between first two items
    private static void TestCase4_NewValueBetweenFirstTwoItems()
    {
        var bookValues = new List<decimal?> { 2.00m, 8.00m, 15.00m, 25.00m };
        decimal newBookValue = 5.00m;
        decimal expected = 2.00m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 4 - New value between first two: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test when new value is between last two items
    private static void TestCase5_NewValueBetweenLastTwoItems()
    {
        var bookValues = new List<decimal?> { 3.00m, 7.00m, 12.00m, 18.00m };
        decimal newBookValue = 16.00m;
        decimal expected = 12.00m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 5 - New value between last two: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with single item list
    private static void TestCase6_SingleItemList()
    {
        var bookValues = new List<decimal?> { 10.00m };
        decimal newBookValue = 15.00m;
        decimal expected = decimal.MaxValue;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 6 - Single item list (new value larger): Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");

        // Test single item with new value smaller
        newBookValue = 5.00m;
        expected = 0;
        result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 6b - Single item list (new value smaller): Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with two item list
    private static void TestCase7_TwoItemList()
    {
        var bookValues = new List<decimal?> { 5.00m, 15.00m };
        decimal newBookValue = 10.00m;
        decimal expected = 5.00m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 7 - Two item list: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with larger list
    private static void TestCase8_LargeList()
    {
        var bookValues = new List<decimal?> { 1.00m, 3.50m, 7.25m, 12.75m, 18.90m, 25.60m, 32.40m, 41.20m };
        decimal newBookValue = 20.00m;
        decimal expected = 18.90m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 8 - Large list: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with very small differences
    private static void TestCase9_VerySmallDifferences()
    {
        var bookValues = new List<decimal?> { 10.01m, 10.05m, 10.10m, 10.15m };
        decimal newBookValue = 10.12m;
        decimal expected = 10.10m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 9 - Very small differences: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with large numbers
    private static void TestCase10_EdgeCaseWithLargeNumbers()
    {
        var bookValues = new List<decimal?> { 100.00m, 500.00m, 1000.00m, 2500.00m };
        decimal newBookValue = 750.00m;
        decimal expected = 500.00m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 10 - Large numbers: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with empty list (edge case)
    private static void TestCase11_EmptyList()
    {
        var bookValues = new List<decimal?>();
        decimal newBookValue = 10.00m;

        try
        {
            decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);
            Console.WriteLine($"Test 11 - Empty list: Method should handle gracefully - UNEXPECTED RESULT: {result}");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Test 11 - Empty list: Expected exception caught - PASS ({ex.GetType().Name})");
        }
    }

    // Test with null values in list
    private static void TestCase12_NullValuesInList()
    {
        var bookValues = new List<decimal?> { 5.00m, null, 15.00m, 20.00m };
        decimal newBookValue = 12.00m;

        try
        {
            decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);
            Console.WriteLine($"Test 12 - Null values in list: Result {result} - Check if method handles nulls properly");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Test 12 - Null values: Exception caught - {ex.GetType().Name}");
        }
    }

    // Test with duplicate values in sorted list
    private static void TestCase13_DuplicateValues()
    {
        var bookValues = new List<decimal?> { 5.00m, 10.00m, 10.00m, 15.00m, 20.00m };
        decimal newBookValue = 12.00m;
        decimal expected = 10.00m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 13 - Duplicate values: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with very close values
    private static void TestCase14_VeryCloseValues()
    {
        var bookValues = new List<decimal?> { 10.001m, 10.002m, 10.003m, 10.004m };
        decimal newBookValue = 10.0025m;
        decimal expected = 10.002m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 14 - Very close values: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test decimal precision
    private static void TestCase15_DecimalPrecision()
    {
        var bookValues = new List<decimal?> { 1.123456789m, 2.987654321m, 4.555555555m };
        decimal newBookValue = 3.333333333m;
        decimal expected = 2.987654321m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 15 - Decimal precision: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with zero in list
    private static void TestCase16_ZeroInList()
    {
        var bookValues = new List<decimal?> { 0.00m, 5.00m, 10.00m, 15.00m };
        decimal newBookValue = 7.50m;
        decimal expected = 5.00m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 16 - Zero in list: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");

        // Test new value close to zero
        newBookValue = 0.50m;
        expected = 0.00m;
        result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 16b - New value close to zero: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test new value very close to existing value but not equal
    private static void TestCase17_NewValueCloseToExisting()
    {
        var bookValues = new List<decimal?> { 5.00m, 10.00m, 15.00m, 20.00m };
        decimal newBookValue = 14.99m;
        decimal expected = 10.00m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 17 - New value close to existing: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with large gaps between values
    private static void TestCase18_LargeGapsBetweenValues()
    {
        var bookValues = new List<decimal?> { 1.00m, 100.00m, 1000.00m, 10000.00m };
        decimal newBookValue = 500.00m;
        decimal expected = 100.00m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 18 - Large gaps: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with mostly same values except one
    private static void TestCase19_AllSameValueExceptOne()
    {
        var bookValues = new List<decimal?> { 10.00m, 10.00m, 10.00m, 25.00m };
        decimal newBookValue = 20.00m;
        decimal expected = 10.00m;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);

        Console.WriteLine($"Test 19 - Mostly same values: Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")}");
    }

    // Test with extremely large list (performance test)
    private static void TestCase20_ExtremelyLargeList()
    {
        var bookValues = new List<decimal?>();
        for (int i = 1; i <= 1000; i++)
        {
            bookValues.Add(i * 1.5m);
        }

        decimal newBookValue = 750.75m; // Should find 750.0
        decimal expected = 750.0m;

        var startTime = DateTime.Now;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);
        var endTime = DateTime.Now;
        var duration = endTime - startTime;

        Console.WriteLine($"Test 20 - Large list (1000 items): Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")} (Time: {duration.TotalMilliseconds}ms)");
    }

    private static void TestCase21_10KItems()
    {
        var bookValues = new List<decimal?>();
        for (int i = 1; i <= 10000; i++)
        {
            bookValues.Add(i * 3.7m);
        }

        decimal newBookValue = 18500.5m; // Should find value around item 5000
        decimal expected = 18500.0m; // 5000 * 3.7

        var startTime = DateTime.Now;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);
        var endTime = DateTime.Now;
        var duration = endTime - startTime;

        Console.WriteLine($"Test 21 - Large list (10K items): Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")} (Time: {duration.TotalMilliseconds}ms)");
    }

    private static void TestCase22_100KItems()
    {
        var bookValues = new List<decimal?>();
        for (int i = 1; i <= 100000; i++)
        {
            bookValues.Add(i * 3.7m);
        }

        // Test with value in first quarter
        decimal newBookValue = 92500.5m; // Around item 25000
        decimal expected = 92500.0m; // 25000 * 3.7

        var startTime = DateTime.Now;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);
        var endTime = DateTime.Now;
        var duration = endTime - startTime;

        Console.WriteLine($"Test 22a - Large list (100K items - 1st Quarter): Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")} (Time: {duration.TotalMilliseconds}ms)");

        decimal newBookValue2 = 185000.5m; // Should find value around item 50000
        decimal expected2 = 185000.0m; // 50000 * 3.7

        startTime = DateTime.Now;
        decimal result2 = Program.NearestSmallDecimal(bookValues, newBookValue2);
        endTime = DateTime.Now;
        duration = endTime - startTime;

        Console.WriteLine($"Test 22b - Large list (100K items - Mid): Expected {expected2}, Got {result2} - {(result2 == expected2 ? "PASS" : "FAIL")} (Time: {duration.TotalMilliseconds}ms)");

        // Test with value in last quarter
        decimal newBookValue3 = 277500.5m; // Around item 75000
        decimal expected3 = 277500.0m; // 75000 * 3.7

        startTime = DateTime.Now;
        decimal result3 = Program.NearestSmallDecimal(bookValues, newBookValue3);
        endTime = DateTime.Now;
        duration = endTime - startTime;

        Console.WriteLine($"Test 22c - Large list (100K items - Last Quarter): Expected {expected3}, Got {result3} - {(result3 == expected3 ? "PASS" : "FAIL")} (Time: {duration.TotalMilliseconds}ms)");


    }

    private static void TestCase23_1MillionItems()
    {
        var bookValues = new List<decimal?>();
        for (int i = 1; i <= 1000000; i++)
        {
            bookValues.Add(i * 4.2m);
        }

        decimal newBookValue = 2100000.5m; // Should find value around item 500000
        decimal expected = 2100000.0m; // 500000 * 4.2

        var startTime = DateTime.Now;
        decimal result = Program.NearestSmallDecimal(bookValues, newBookValue);
        var endTime = DateTime.Now;
        var duration = endTime - startTime;

        Console.WriteLine($"Test 23a - Large list (1 Million items - Mid): Expected {expected}, Got {result} - {(result == expected ? "PASS" : "FAIL")} (Time: {duration.TotalMilliseconds}ms)");

        // Test with value near beginning (first 10%)
        decimal newBookValue2 = 420000.5m; // Around item 100000
        decimal expected2 = 420000.0m; // 100000 * 4.2

        startTime = DateTime.Now;
        decimal result2 = Program.NearestSmallDecimal(bookValues, newBookValue2);
        endTime = DateTime.Now;
        duration = endTime - startTime;

        Console.WriteLine($"Test 23b - Large list (1 Million items - 10%): Expected {expected2}, Got {result2} - {(result2 == expected2 ? "PASS" : "FAIL")} (Time: {duration.TotalMilliseconds}ms)");

        // Test with value near end (last 10%)
        decimal newBookValue3 = 3780000.5m; // Around item 900000
        decimal expected3 = 3780000.0m; // 900000 * 4.2

        startTime = DateTime.Now;
        decimal result3 = Program.NearestSmallDecimal(bookValues, newBookValue3);
        endTime = DateTime.Now;
        duration = endTime - startTime;

        Console.WriteLine($"Test 23c - Large list (1 Million items - 90%): Expected {expected3}, Got {result3} - {(result3 == expected3 ? "PASS" : "FAIL")} (Time: {duration.TotalMilliseconds}ms)");
    }
}