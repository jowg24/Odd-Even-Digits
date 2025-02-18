using System;
using System.Collections.Generic;
using System.IO;

class Solution
{
    public int solution(string S)
    {
        List<int> oddDigits = new List<int>();
        List<int> evenDigits = new List<int>();

        // Separate odd and even digits from the string
        foreach (char c in S)
        {
            // Ensure we are processing only digit characters
            if (!Char.IsDigit(c))
                continue;

            int digit = c - '0';
            if (digit % 2 == 1) // Odd
                oddDigits.Add(digit);
            else // Even
                evenDigits.Add(digit);
        }

        // Compute the maximum number of two-digit odd numbers:
        // - One common interpretation: use one even digit for tens and one odd digit for ones.
        //   This is limited by the smaller count of even or odd digits.
        int count = Math.Min(evenDigits.Count, oddDigits.Count);

        // Additionally, if the file contains only odd digits (like "77"),
        // we allow pairing two odd digits to form a valid two-digit odd number.
        if (oddDigits.Count >= 2)
        {
            count = Math.Max(count, oddDigits.Count / 2);
        }

        return count;
    }

    static void Main()
    {
        // Prompt the user for the file path
        Console.Write("Enter the file path containing a string of numbers: ");
        string filePath = Console.ReadLine();

        string fileContent = "";
        try
        {
            // Read the entire content of the file
            fileContent = File.ReadAllText(filePath);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error reading the file: " + ex.Message);
            return;
        }

        // Process the string from the file
        Solution sol = new Solution();
        int result = sol.solution(fileContent);

        // Display the result
        Console.WriteLine("The maximum number of two-digit odd numbers that can be formed is: " + result);
    }
}
