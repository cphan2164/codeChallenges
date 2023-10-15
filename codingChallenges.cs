using System.Runtime.InteropServices;

namespace codingChalleneges
{
    public class codingChallenge
    {
        public static void Main(string[] args)
        {
            
            int[] arr1 = { 1, 2, 3, 4, 5 };
            bool result1 = AreAllElementsUnique(arr1); // Should return true
            Console.WriteLine(result1);

            int[] arr2 = { 1, 2, 2, 4, 5 };
            bool result2 = AreAllElementsUnique(arr2); // Should return false
            Console.WriteLine(result2);
            

            string input1 = "([{((({{{[[[()]]]}}})))}])";
            string input2 = "((()){{{{[[[[(())]]]}}}}))";
            string input3 = "{[(([[{{(())}}]]))]}";
            string input4 = "[{({[]})}({[]})]";
            string input5 = "([{]})";
            string input6 = "{{({)}[()]}}";

            result1 = Parentheses(input1); // Should return true
            result2 = Parentheses(input2); // Should return false
            bool result3 = Parentheses(input3); // Should return true
            bool result4 = Parentheses(input4); // Should return true
            bool result5 = Parentheses(input5); // Should return false
            bool result6 = Parentheses(input6); // Should return false

            Console.WriteLine("Result 1: " + result1);
            Console.WriteLine("Result 2: " + result2);
            Console.WriteLine("Result 3: " + result3);
            Console.WriteLine("Result 4: " + result4);
            Console.WriteLine("Result 5: " + result5);
            Console.WriteLine("Result 6: " + result6);


        }
        // The coding challenge is to see if an array contains all unique elements
        // The constraint is the solution must be better than O(n^2), but other data structures are allowed
        public static bool AreAllElementsUnique(int[] arr)
        {
            List<int> list = new List<int>();   
            for(int i = 0; i < arr.Length; i++)
            {
                if (!list.Contains(arr[i]))
                {
                    list.Add(arr[i]);
                }
                else
                {
                    return false;
                }
            }


            return true;
        }

        public static bool Parentheses(string s)
        {
            Stack<char> chars = new Stack<char>();
            for (int i = 0; i < s.Length; i++)
            {
                if (s[i] == '(' || s[i] == '{' || s[i] =='['){
                    chars.Push(s[i]);
                }
                else if (s[i] == ')' || s[i] == '}' || s[i] == ']')
                {
                    char match = chars.Pop();
                    if(!((match == '(' && s[i] == ')')|| (match == '{' && s[i] == '}')|| (match == '[' && s[i] == ']')))
                    {
                        return false;
                    }
                }
            } 

            if(chars.Count > 0)
            {
                return false;
            }

            return true;
        }

    }
}