
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
        
        // Test case 6: Target equals an existing value
        var bookValues6 = new List<decimal?> { 10m, 10.5m, 10.51m };
        var result6 = Program.NearestSmallDecimal(bookValues6, 10.5m);
        AssertEqual(10m, result6, "Test 6: Should find next smaller value when target equals existing");
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
