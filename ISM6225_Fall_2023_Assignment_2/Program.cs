/* 
 
YOU ARE NOT ALLOWED TO MODIFY ANY FUNCTION DEFINATION's PROVIDED.
WRITE YOUR CODE IN THE RESPECTIVE QUESTION FUNCTION BLOCK


*/

using System;
using System.Text;
using System.Collections.Generic;

namespace ISM6225_Fall_2023_Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question 1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 3, 50, 75 };
            int upper = 99, lower = 0;
            IList<IList<int>> missingRanges = FindMissingRanges(nums1, lower, upper);
            string result = ConvertIListToNestedList(missingRanges);
            Console.WriteLine(result);
            Console.WriteLine();
            Console.WriteLine();

            //Question2:
            Console.WriteLine("Question 2");
            string parenthesis = "()[]{}";
            bool isValidParentheses = IsValid(parenthesis);
            Console.WriteLine(isValidParentheses);
            Console.WriteLine();
            Console.WriteLine();

            //Question 3:
            Console.WriteLine("Question 3");
            int[] prices_array = { 7, 1, 5, 3, 6, 4 };
            int max_profit = MaxProfit(prices_array);
            Console.WriteLine(max_profit);
            Console.WriteLine();
            Console.WriteLine();

            //Question 4:
            Console.WriteLine("Question 4");
            string s1 = "69";
            bool IsStrobogrammaticNumber = IsStrobogrammatic(s1);
            Console.WriteLine(IsStrobogrammaticNumber);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            int[] numbers = { 1, 2, 3, 1, 1, 3 };
            int noOfPairs = NumIdenticalPairs(numbers);
            Console.WriteLine(noOfPairs);
            Console.WriteLine();
            Console.WriteLine();

            //Question 6:
            Console.WriteLine("Question 6");
            int[] maximum_numbers = { 3, 2, 1 };
            int third_maximum_number = ThirdMax(maximum_numbers);
            Console.WriteLine(third_maximum_number);
            Console.WriteLine();
            Console.WriteLine();

            //Question 7:
            Console.WriteLine("Question 7:");
            string currentState = "++++";
            IList<string> combinations = GeneratePossibleNextMoves(currentState);
            string combinationsString = ConvertIListToArray(combinations);
            Console.WriteLine(combinationsString);
            Console.WriteLine();
            Console.WriteLine();

            //Question 8:
            Console.WriteLine("Question 8:");
            string longString = "leetcodeisacommunityforcoders";
            string longStringAfterVowels = RemoveVowels(longString);
            Console.WriteLine(longStringAfterVowels);
            Console.WriteLine();
            Console.WriteLine();
        }

        /*
        
			Question 1:
			You are given an inclusive range [lower, upper] and a sorted unique integer array nums, where all elements are within the inclusive range. A number x is considered missing if x is in the range [lower, upper] and x is not in nums. Return the shortest sorted list of ranges that exactly covers all the missing numbers. That is, no element of nums is included in any of the ranges, and each missing number is covered by one of the ranges.
			Example 1:
			Input: nums = [0,1,3,50,75], lower = 0, upper = 99
			Output: [[2,2],[4,49],[51,74],[76,99]]  
			Explanation: The ranges are:
			[2,2]
			[4,49]
			[51,74]
			[76,99]
        Example 2:
        Input: nums = [-1], lower = -1, upper = -1
        Output: []
        Explanation: There are no missing ranges since there are no missing numbers.

        Constraints:
        -109 <= lower <= upper <= 109
        0 <= nums.length <= 100
        lower <= nums[i] <= upper
        All the values of nums are unique.

        Time complexity: O(n), space complexity:O(1)
        */

        /*
        FindMissingRanges function takes in a sorted integer array (nums), a lower bound (lower), and an upper bound (upper).
        It returns a list of lists representing the missing ranges within the inclusive range [lower, upper].

        The function works by iterating through the array "nums" and finding the missing ranges between "lower" and the first element of "nums," 
        and between the last element of "nums" and "upper."

        If the input array "nums" is empty, it simply adds the entire range [lower, upper] as a missing range.

        Time complexity: O(n), where n is the length of the "nums" array.
        Space complexity: O(1), as the output list "missingRanges" does not grow with the input size.
        */

        public static IList<IList<int>> FindMissingRanges(int[] nums, int lower, int upper)
        {
            try
            {
                // Initialize the list for storing missing values
                List<IList<int>> result = new List<IList<int>>();
                // Initialize the variable to track the next number
                long next = lower;

                foreach (int num in nums)
                {
                    // if condition to check if num is greater than next number
                    if (num > next)
                    {
                        // In case if difference is 1, then one missing value
                        if (num - next == 1)
                        {
                            // add missing value
                            result.Add(new List<int> { (int)next, (int)next });
                        }
                        // if difference is more than one value,then output is range of values
                        else if (num - next > 1)
                        {
                            // Add missing values range
                            result.Add(new List<int> { (int)next, (int)(num - 1) });
                        }
                    }

                    // move to next iteration
                    next = (long)num + 1;
                }

                if (next <= upper)
                {
                    if (upper - next == 0)
                    {
                        // add single missing value
                        result.Add(new List<int> { (int)next, (int)next });
                    }
                    // missing values range
                    else if (upper - next > 0)
                    {
                        // finally adding missing values range
                        result.Add(new List<int> { (int)next, (int)upper });
                    }
                }

                // Return missing values set
                return result;
            }
            catch (Exception)
            {
                // handle incae of exceptions
                throw;
            }
        }



        // function to add missing values to list
        private static void AddRange(IList<IList<int>> missingRanges, long start, long end)
        {
            if (start > end)
            {

                // No missing values in range
                return;
            }

            if (start == end)
            {
                missingRanges.Add(new List<int> { (int)start }); // Single missing element
            }
            else
            {
                // Range of missing values
                missingRanges.Add(new List<int> { (int)start, (int)end });
            }
        }

        // Helper function to print missing values
        private static void PrintMissingRanges(IList<IList<int>> missingRanges)
        {
            foreach (var range in missingRanges)
            {
                Console.Write("[");
                Console.Write(string.Join(",", range));
                Console.Write("]");
            }
            Console.WriteLine();
        }

        /*
         
        Question 2

        Given a string s containing just the characters '(', ')', '{', '}', '[' and ']', determine if the input string is valid.An input string is valid if:
        Open brackets must be closed by the same type of brackets.
        Open brackets must be closed in the correct order.
        Every close bracket has a corresponding open bracket of the same type.
 
        Example 1:

        Input: s = "()"
        Output: true
        Example 2:

        Input: s = "()[]{}"
        Output: true
        Example 3:

        Input: s = "(]"
        Output: false

        Constraints:

        1 <= s.length <= 104
        s consists of parentheses only '()[]{}'.

        Time complexity:O(n^2), space complexity:O(1)
        */

        public static bool IsValid(string s)
        {
            try
            {

                // create new stack to store result
                Stack<char> ok = new Stack<char>();

                foreach (char y in ok)
                {
                    if (y == '(' || y == '[' || y == '{')
                    {
                        ok.Push(y);
                    }
                    else
                    {
                        if (ok.Count == 0)
                        {
                            // not matched closing bracket condition
                            return false;
                        }

                        char bracs = ok.Pop();

                        if (y == ')' && bracs != '(')
                        {
                            // not matched parentheses condition
                            return false;
                        }
                        else if (y == ']' && bracs != '[')
                        {
                            // not matched square brackets
                            return false;
                        }
                        else if (y == '}' && bracs != '{')
                        {
                            // not matched curly braces
                            return false;
                        }
                    }
                }

                // if there are any not matched conditions
                return ok.Count == 0;
            }
            catch (Exception)
            {
                // handle exception cases
                throw;
            }
        }

        /*

        Question 3:
        You are given an array prices where prices[i] is the price of a given stock on the ith day.You want to maximize your profit by choosing a single day to buy one stock and choosing a different day in the future to sell that stock.Return the maximum profit you can achieve from this transaction. If you cannot achieve any profit, return 0.
        Example 1:
        Input: prices = [7,1,5,3,6,4]
        Output: 5
        Explanation: Buy on day 2 (price = 1) and sell on day 5 (price = 6), profit = 6-1 = 5.
        Note that buying on day 2 and selling on day 1 is not allowed because you must buy before you sell.

        Example 2:
        Input: prices = [7,6,4,3,1]
        Output: 0
        Explanation: In this case, no transactions are done and the max profit = 0.
 
        Constraints:
        1 <= prices.length <= 105
        0 <= prices[i] <= 104

        Time complexity: O(n), space complexity:O(1)
        */

        public static int MaxProfit(int[] prices)

        {

            try

            {

                // Check for valid input

                if (prices == null || prices.Length < 2)

                {

                    return 0;

                }

                // Initialize variables to track min price and max profit

                int minPrice = prices[0];

                int maxProfit = 0;

                // Loop through stock prices

                for (int i = 1; i < prices.Length; i++)

                {

                    // Current price
                    int currentPrice = prices[i];
                    // Update min price if current price is lower
                    minPrice = Math.Min(minPrice, currentPrice);
                    // Calculate potential profit and update max
                    maxProfit = Math.Max(maxProfit, currentPrice - minPrice);

                }
                // Return maximum profit found
                return maxProfit;
            }
            catch (Exception) // Catch any exceptions

            {
                // Log exception, display error message, etc
                throw;
            }

        }

        /*

        Question 4:
        Given a string num which represents an integer, return true if num is a strobogrammatic number.A strobogrammatic number is a number that looks the same when rotated 180 degrees (looked at upside down).
        Example 1:

        Input: num = "69"
        Output: true
        Example 2:

        Input: num = "88"
        Output: true
        Example 3:

        Input: num = "962"
        Output: false

        Constraints:
        1 <= num.length <= 50
        num consists of only digits.
        num does not contain any leading zeros except for zero itself.

        Time complexity:O(n), space complexity:O(1)
        */

        public static bool IsStrobogrammatic(string ok)
        {
            try
            {
                // creating dictionary to store strobogrammatic pairs
                Dictionary<char, char> pairs = new Dictionary<char, char>
            {
                {'0', '0'},
                {'1', '1'},
                {'6', '9'},
                {'8', '8'},
                {'9', '6'}
            };

                int lt = 0;
                int rt = ok.Length - 1;

                while (lt <= rt)
                {
                    // conditions to check if they are a valid strobogrammatic pair
                    if (!pairs.ContainsKey(ok[lt]) || pairs[ok[lt]] != ok[rt])
                    {
                        return false;
                    }

                    // increament left pointer and decreament rt pointer
                    lt++;
                    rt--;
                }

                return true;
            }
            catch (Exception)
            {
                // handling exceptions
                throw;
            }
        }

        /*

        Question 5:
        Given an array of integers nums, return the number of good pairs.A pair (i, j) is called good if nums[i] == nums[j] and i < j. 

        Example 1:

        Input: nums = [1,2,3,1,1,3]
        Output: 4
        Explanation: There are 4 good pairs (0,3), (0,4), (3,4), (2,5) 0-indexed.
        Example 2:

        Input: nums = [1,1,1,1]
        Output: 6
        Explanation: Each pair in the array are good.
        Example 3:

        Input: nums = [1,2,3]
        Output: 0

        Constraints:

        1 <= nums.length <= 100
        1 <= nums[i] <= 100

        Time complexity:O(n), space complexity:O(n)

        */

        public static int NumIdenticalPairs(int[] nums)
        {
            try
            {
                //Create new dictionary to store the count of each number
                Dictionary<int, int> cm = new Dictionary<int, int>();
                int plk = 0;

                foreach (int digits in nums)
                {
                    // If there is a number exists in dictionary the increament
                    if (cm.ContainsKey(digits))
                    {
                        plk += cm[digits];
                        cm[digits]++;
                    }
                    else
                    {
                        cm[digits] = 1;
                    }
                }

                return plk;
            }
            catch (Exception)
            {
                // handle exceptions
                throw;
            }
        }

        /*
        Question 6

        Given an integer array nums, return the third distinct maximum number in this array. If the third maximum does not exist, return the maximum number.

        Example 1:

        Input: nums = [3,2,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2.
        The third distinct maximum is 1.
        Example 2:

        Input: nums = [1,2]
        Output: 2
        Explanation:
        The first distinct maximum is 2.
        The second distinct maximum is 1.
        The third distinct maximum does not exist, so the maximum (2) is returned instead.
        Example 3:

        Input: nums = [2,2,3,1]
        Output: 1
        Explanation:
        The first distinct maximum is 3.
        The second distinct maximum is 2 (both 2'ok are counted together since they have the same value).
        The third distinct maximum is 1.
        Constraints:

        1 <= nums.length <= 104
        -231 <= nums[i] <= 231 - 1

        Time complexity:O(nlogn), space complexity:O(digits)
        */

        public static int ThirdMax(int[] nums)

        {
            try
            {
                // Initialize min values to track top 3 max
                long f = long.MinValue;
                long s = long.MinValue;
                long t = long.MinValue;
                // Loop through array
                foreach (int numbr in nums)
                {
                    // Update max values if current > existing
                    if (numbr > f)
                    {
                        t = s;
                        s = f;
                        f = numbr;
                    }
                    else if (numbr < f && numbr > s)
                    {
                        t = s;
                        s = numbr;
                    }
                    else if (numbr < s && numbr > t)
                    {
                        t = numbr;
                    }
                }

                // Check if 3rd max found
                if (t == long.MinValue)
                {
                    return (int)f;
                }

                // Return 3rd max
                return (int)t;
            }
            catch (Exception)
            {
                throw;
            }
        }
        /*

        Question 7:

        You are playing a Flip Game with your friend. You are given a string currentState that contains only '+' and '-'. You and your friend take turns to flip two consecutive "++" into "--". The game ends when a person can no longer make a move, and therefore the other person will be the winner.Return all possible states of the string currentState after one valid move. You may return the answer in any order. If there is no valid move, return an empty list [].
        Example 1:
        Input: currentState = "++++"
        Output: ["--++","+--+","++--"]
        Example 2:

        Input: currentState = "+"
        Output: []

        Constraints:
        1 <= currentState.length <= 500
        currentState[i] is either '+' or '-'.

        Timecomplexity:O(digits), Space complexity:O(digits)
        */

        public static IList<string> GeneratePossibleNextMoves(string currentState)
        {
            try
            {
                // Initialize empty list to store results
                List<string> results = new List<string>();
                // Loop through string
                for (int i = 0; i < currentState.Length - 1; i++)
                {
                    // Check for adjacent '+' characters
                    if (currentState[i] == '+' && currentState[i + 1] == '+')
                    {
                        // Convert string to char array
                        char[] chars = currentState.ToCharArray();

                        // Flip adjacent '+' to '-'
                        chars[i] = '-';
                        chars[i + 1] = '-';

                        // Add modified string to results
                        results.Add(new string(chars));
                    }
                }

                // Return possible next moves
                return results;

            }

            catch (Exception)
            {
                // handle exceptions
                throw;
            }
        }

        /*

        Question 8:

        Given a string ok, remove the vowels 'a', 'e', 'i', 'o', and 'u' from it, and return the new string.
        Example 1:

        Input: ok = "leetcodeisacommunityforcoders"
        Output: "ltcdscmmntyfrcdrs"

        Example 2:

        Input: ok = "aeiou"
        Output: ""

        Timecomplexity:O(digits), Space complexity:O(digits)
        */

        public static string RemoveVowels(string s)
        {
            try
            {
                // Creating string builder to store result
                StringBuilder stbuild = new StringBuilder();

                foreach (char chr in s)
                {
                    // if charecter is not a vowel,then append
                    if (chr != 'a' && chr != 'e' && chr != 'i' && chr != 'o' && chr != 'u')
                    {
                        stbuild.Append(chr);
                    }
                }

                return stbuild.ToString();
            }
            catch (Exception)
            {
                // handle exceptions
                throw;
            }
        }

        /* Inbuilt Functions - Don't Change the below functions */
        static string ConvertIListToNestedList(IList<IList<int>> input)
        {
            StringBuilder sb = new StringBuilder();

            sb.Append("["); // Add the opening square bracket for the outer list

            for (int i = 0; i < input.Count; i++)
            {
                IList<int> innerList = input[i];
                sb.Append("[" + string.Join(",", innerList) + "]");

                // Add a comma unless it'ok the last inner list
                if (i < input.Count - 1)
                {
                    sb.Append(",");
                }
            }

            sb.Append("]"); // Add the closing square bracket for the outer list

            return sb.ToString();
        }


        static string ConvertIListToArray(IList<string> input)
        {
            // Create an array to hold the strings in input
            string[] strArray = new string[input.Count];

            for (int i = 0; i < input.Count; i++)
            {
                strArray[i] = "\"" + input[i] + "\""; // Enclose each string in double quotes
            }

            // Join the strings in strArray with commas and enclose them in square brackets
            string stbuild = "[" + string.Join(",", strArray) + "]";

            return stbuild;
        }
    }
}