
using System;
using System.Collections.Generic;
using System.Linq;

public class Tests
{
    public static void RunAllTests()
    {
        Console.WriteLine("Running NearestSmallDecimal Tests...\n");
        
        TestBasicFunctionality();
        TestEdgeCases();
        TestPrecisionHandling();
        TestBoundaryConditions();
        TestManyValuesNonExisting();
        
        Console.WriteLine("All tests completed!");
    }
    
    private static void TestBasicFunctionality()
    {
        Console.WriteLine("=== Basic Functionality Tests ===");
        
        // Test case 1: Target value between existing values
        var bookValues1 = new List<decimal?> { 10m, 10.5m, 10.51m, 10.529m, 10.541m };
        var result1 = Program.NearestSmallDecimal(bookValues1, 10.54m);
        AssertEqual(10.529m, result1, "Test 1: Should find 10.529 as nearest smaller value to 10.54");
        
        // Test case 2: Target value larger than all values
        var result2 = Program.NearestSmallDecimal(bookValues1, 11m);
        AssertEqual(10.541m, result2, "Test 2: Should find largest value when target is bigger than all");
        
        // Test case 3: Target value smaller than middle value
        var result3 = Program.NearestSmallDecimal(bookValues1, 10.3m);
        AssertEqual(10m, result3, "Test 3: Should find 10 as nearest smaller value to 10.3");
    }
    
    private static void TestEdgeCases()
    {
        Console.WriteLine("\n=== Edge Cases Tests ===");
        
        // Test case 4: Single element list
        var bookValues4 = new List<decimal?> { 5m };
        var result4 = Program.NearestSmallDecimal(bookValues4, 10m);
        AssertEqual(5m, result4, "Test 4: Single element should be returned");
        
        // Test case 5: Two elements
        var bookValues5 = new List<decimal?> { 5m, 15m };
        var result5 = Program.NearestSmallDecimal(bookValues5, 12m);
        AssertEqual(5m, result5, "Test 5: Should find smaller value in two-element list");
        
    }
    
    private static void TestPrecisionHandling()
    {
        Console.WriteLine("\n=== Precision Handling Tests ===");
        
        // Test case 7: Very close decimal values
        var bookValues7 = new List<decimal?> { 1.001m, 1.002m, 1.003m, 1.004m, 1.005m };
        var result7 = Program.NearestSmallDecimal(bookValues7, 1.0035m);
        AssertEqual(1.003m, result7, "Test 7: Should handle precise decimal comparisons");

        
        // Test case 8: Large numbers with decimals
        var bookValues8 = new List<decimal?> { 1000.1m, 1000.2m, 1000.3m };
        var result8 = Program.NearestSmallDecimal(bookValues8, 1000.25m);
        AssertEqual(1000.2m, result8, "Test 8: Should work with larger decimal numbers");
    }
    
    private static void TestBoundaryConditions()
    {
        Console.WriteLine("\n=== Boundary Conditions Tests ===");
        
        // Test case 9: Target smaller than all values
        var bookValues9 = new List<decimal?> { 10m, 20m, 30m };
        var result9 = Program.NearestSmallDecimal(bookValues9, 5m);
        AssertEqual(10m, result9, "Test 9: Should return first value when target is smaller than all");
        
        // Test case 10: Multiple values with same distance
        var bookValues10 = new List<decimal?> { 10m, 12m, 14m, 16m };
        var result10 = Program.NearestSmallDecimal(bookValues10, 15m);
        AssertEqual(14m, result10, "Test 10: Should find nearest smaller when multiple equidistant options");
        
        // Test case 11: Very small differences
        var bookValues11 = new List<decimal?> { 0.001m, 0.002m, 0.003m };
        var result11 = Program.NearestSmallDecimal(bookValues11, 0.0025m);
        AssertEqual(0.002m, result11, "Test 11: Should handle very small decimal differences");
    }
    
    private static void TestManyValuesNonExisting()
    {
        Console.WriteLine("\n=== Many Values with Non-Existing Targets Tests ===");
        
        // Test case 12: Large list with many decimal places - target in middle range
        var bookValues12 = new List<decimal?> 
        { 
            1.111m, 2.222m, 3.333m, 4.444m, 5.555m, 6.666m, 7.777m, 8.888m, 9.999m, 
            11.111m, 12.222m, 13.333m, 14.444m, 15.555m, 16.666m, 17.777m, 18.888m, 19.999m 
        };
        var result12 = Program.NearestSmallDecimal(bookValues12, 10.5m);
        AssertEqual(9.999m, result12, "Test 12: Large list - should find nearest smaller to 10.5");
        
        // Test case 13: Same large list - target near beginning
        var result13 = Program.NearestSmallDecimal(bookValues12, 2.5m);
        AssertEqual(2.222m, result13, "Test 13: Large list - should find nearest smaller to 2.5");
        
        // Test case 14: Same large list - target near end
        var result14 = Program.NearestSmallDecimal(bookValues12, 18.5m);
        AssertEqual(17.777m, result14, "Test 14: Large list - should find nearest smaller to 18.5");
        
        // Test case 15: Very large list with close values
        var bookValues15 = new List<decimal?>();
        for (int i = 0; i < 50; i++)
        {
            bookValues15.Add(10m + (i * 0.1m)); // 10.0, 10.1, 10.2, ... 14.9
        }
        var result15 = Program.NearestSmallDecimal(bookValues15, 12.35m);
        AssertEqual(12.3m, result15, "Test 15: Very large list - should find 12.3 as nearest smaller to 12.35");
        
        // Test case 16: Random decimal values - target not in list
        var bookValues16 = new List<decimal?> 
        { 
            1.23m, 4.56m, 7.89m, 10.11m, 13.14m, 16.17m, 19.20m, 22.23m, 25.26m, 28.29m,
            31.32m, 34.35m, 37.38m, 40.41m, 43.44m, 46.47m, 49.50m, 52.53m, 55.56m, 58.59m
        };
        var result16 = Program.NearestSmallDecimal(bookValues16, 15.75m);
        AssertEqual(13.14m, result16, "Test 16: Random decimals - should find 13.14 as nearest smaller to 15.75");
        
        // Test case 17: Currency-like values with cents
        var bookValues17 = new List<decimal?>
        {
            9.99m, 19.99m, 29.99m, 39.99m, 49.99m, 59.99m, 69.99m, 79.99m, 89.99m, 99.99m,
            109.99m, 119.99m, 129.99m, 139.99m, 149.99m, 159.99m, 169.99m, 179.99m, 189.99m, 199.99m
        };
        var result17 = Program.NearestSmallDecimal(bookValues17, 75.50m);
        AssertEqual(69.99m, result17, "Test 17: Currency values - should find 69.99 as nearest smaller to 75.50");
        
        // Test case 18: Scientific precision values
        var bookValues18 = new List<decimal?>
        {
            0.00001m, 0.00005m, 0.0001m, 0.0005m, 0.001m, 0.005m, 0.01m, 0.05m, 0.1m, 0.5m,
            1.0m, 5.0m, 10.0m, 50.0m, 100.0m, 500.0m, 1000.0m, 5000.0m, 10000.0m, 50000.0m
        };
        var result18 = Program.NearestSmallDecimal(bookValues18, 2.5m);
        AssertEqual(1.0m, result18, "Test 18: Scientific precision - should find 1.0 as nearest smaller to 2.5");
        
        // Test case 19: Negative and positive mix - target positive
        var bookValues19 = new List<decimal?>
        {
            -50.5m, -25.25m, -10.1m, -5.05m, -1.01m, 1.01m, 5.05m, 10.1m, 25.25m, 50.5m,
            75.75m, 100.1m, 125.25m, 150.5m, 175.75m, 200.1m, 225.25m, 250.5m, 275.75m, 300.1m
        };
        var result19 = Program.NearestSmallDecimal(bookValues19, 12.5m);
        AssertEqual(10.1m, result19, "Test 19: Mixed negative/positive - should find 10.1 as nearest smaller to 12.5");
        
        // Test case 20: Very precise decimals with many places
        var bookValues20 = new List<decimal?>
        {
            1.123456m, 2.234567m, 3.345678m, 4.456789m, 5.567890m, 6.678901m, 7.789012m,
            8.890123m, 9.901234m, 10.012345m, 11.123456m, 12.234567m, 13.345678m, 14.456789m,
            15.567890m, 16.678901m, 17.789012m, 18.890123m, 19.901234m, 20.012345m
        };
        var result20 = Program.NearestSmallDecimal(bookValues20, 8.5m);
        AssertEqual(7.789012m, result20, "Test 20: High precision decimals - should find 7.789012 as nearest smaller to 8.5");
    }
    
    private static void AssertEqual(decimal expected, decimal actual, string testDescription)
    {
        if (expected == actual)
        {
            Console.WriteLine($"✓ PASS: {testDescription}");
        }
        else
        {
            Console.WriteLine($"✗ FAIL: {testDescription}");
            Console.WriteLine($"  Expected: {expected}, Actual: {actual}");
        }
    }
}
