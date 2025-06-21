
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
}
