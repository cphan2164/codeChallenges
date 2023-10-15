using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TwoSum
{
    public class TwoSum
    {
        public static void Main(string[] args)
        {
            Console.WriteLine("Type in the size of the array");
            int size = Convert.ToInt32(Console.ReadLine());
            int[] digits = new int[size];
            for(int i = 0; i < size; i++)
            {
                Console.WriteLine("Type in the digit at {0} in the array", i);
                digits[i] = Convert.ToInt32(Console.ReadLine());
            }
            Console.WriteLine("Write the target number");
            int target = Convert.ToInt32(Console.ReadLine());
            int[] solution = TwoSums(digits, target);
            Console.WriteLine("The solution is {0} and {1}.", solution[0], solution[1]);
        }

        public static int[] TwoSums(int[] nums, int target) {
            int[] result = new int[2];
            int flagFound = 0;
            for(int i = 0; i < nums.Length; i++)
            {
                for(int j = 1; j < nums.Length - i; j++)
                {
                    if (nums[i] + nums[j] == target)
                    {
                        result[0] = nums[i];
                        result[1] = nums[j];
                        flagFound++;
                        break;
                    }
                }
                if(flagFound == 1)
                {
                    break;
                }
            }


            return result;
        
        }
    }
}
