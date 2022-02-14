using System;
using System.Linq;
using System.Collections.Generic;

namespace Assignment_2
{
    class Program
    {
        static void Main(string[] args)
        {
            //Question1:
            Console.WriteLine("Question 1:");
            int[] nums1 = { 0, 1, 2, 3, 12 };
            Console.WriteLine("Enter the target number:");
            int target = Int32.Parse(Console.ReadLine());
            int pos = SearchInsert(nums1, target);
            Console.WriteLine("Insert Position of the target is : {0}", pos);
            Console.WriteLine("");


            //Question2:
            Console.WriteLine("Question 2");
            string paragraph = "Bob hit a ball, the hit BALL flew far after it was hit.";
            string[] banned = { "hit" };
            string commonWord = MostCommonWord(paragraph, banned);
            Console.WriteLine("Most frequent word is {0}:", commonWord);
            Console.WriteLine();


            //Question 3:
            Console.WriteLine("Question 3");
            int[] arr1 = { 2, 2, 3, 4 };
            int lucky_number = FindLucky(arr1);
            Console.WriteLine("The Lucky number in the given array is {0}", lucky_number);
            Console.WriteLine();


            //Question 4:
            Console.WriteLine("Question 4");
            string secret = "1807";
            string guess = "7810";
            string hint = GetHint(secret, guess);
            Console.WriteLine("Hint for the guess is :{0}", hint);
            Console.WriteLine();


            //Question 6:
            Console.WriteLine("Question 6");
            int[] widths = new int[] { 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10, 10 };
            string bulls_string9 = "abcdefghijklmnopqrstuvwxyz";
            List<int> lines = NumberOfLines(widths, bulls_string9);
            Console.WriteLine("Lines Required to print:");
            for (int i = 0; i < lines.Count; i++)
            {
                Console.Write(lines[i] + "\t");
            }
            Console.WriteLine();
            Console.WriteLine();


            //Question 7:
            Console.WriteLine("Question 7:");
            string bulls_string10 = "()[]{}";
            bool isvalid = IsValid(bulls_string10);
            if (isvalid)
                Console.WriteLine("Valid String");
            else
                Console.WriteLine("String is not Valid");

            Console.WriteLine();
            Console.WriteLine();


            //Question 8:
            Console.WriteLine("Question 8");
            string[] bulls_string13 = { "gin", "zen", "gig", "msg" };
            int diffwords = UniqueMorseRepresentations(bulls_string13);
            Console.WriteLine("Number of with unique code are: {0}", diffwords);
            Console.WriteLine();
            Console.WriteLine();

            //Question 5:
            Console.WriteLine("Question 5");
            string s = "ababcbacadefegdehijhklij";
            List<int> part = PartitionLabels(s);
            Console.WriteLine("Partation lengths are:");
            for (int i = 0; i < part.Count; i++)
            {
                Console.Write(part[i] + "\t");
            }
            Console.WriteLine();


        }


        public static int SearchInsert(int[] nums, int target)
        {
            try
            {

                int min= 0;
                int mid = 0;
                bool flag = false;
                int indexvalue = 0;
                int max = nums.Length - 1;
                while (min <= max)
                {
                    mid = (max + min) / 2;

                    if (nums[mid] == target)
                    {
                        indexvalue = mid;
                        min = max + 1;
                        flag = true;
                    }
                    else if (nums[mid] > target)
                    {
                        max = mid - 1;
                    }
                    else
                    {
                        min = mid + 1;
                    }
                }
                if (flag)
                {
                    return (indexvalue);
                }
                else
                {
                    return (min);
                }
            }
            catch (Exception)
            {
                throw;
            }
        }






        public static string MostCommonWord(string paragraph, string[] banned)
        {
            try
            {
                List<char> charsToRemove = new List<char>() { '@', '!', ',', '.', '?' };


                foreach (char val in charsToRemove)
                {
                    paragraph = paragraph.Replace(val.ToString(), "");
                }

                paragraph = paragraph.Replace("'", "").ToLower();

                string[] newstr = paragraph.Split(" ");
                int var = 0;
                int[] countarray = new int[newstr.Length];
                for (int i = 0; i < newstr.Length; i++)
                {

                    if (!banned.Any(newstr[i].Contains))
                    {
                        var = newstr.Count(s => s == newstr[i].ToString());
                    }
                    else
                    {
                        var = 0;
                    }

                    countarray[i] = var;
                }

                int max = countarray.Max();
                int indexmax = countarray.ToList().IndexOf(max);
                return newstr[indexmax];


            }
            catch (Exception)
            {

                throw;
            }
        }



        public static int FindLucky(int[] arr)
        {
            try
            {
                int max1 = 0;
                List<int> numberlist = new List<int>();
                Dictionary<int, int> countdict = new Dictionary<int, int>();
                int var = 0;
                for (int i = 0; i < arr.Length; i++)
                {
                    var = arr.Count(s => s == arr[i]);
                    countdict.TryAdd(arr[i], var);
                }
                int[] keyarray = countdict.Keys.ToArray<int>();

                foreach (int val in keyarray)
                {
                    if (val == countdict[val])
                    {
                        numberlist.Add(val);
                    };
                }
                if (numberlist.Count == 0)
                {
                    max1 = -1;
                }
                else
                {
                    max1 = numberlist.Max();
                }
                return max1;
            }
            catch (Exception)
            {

                throw;
            }

        }


        public static string GetHint(string secret, string guess)
        {
            try
            {

                int[] s = new int[secret.Length];
                int[] g = new int[guess.Length];
                List<int> numberlist = new List<int>();
                List<int> numberlist2 = new List<int>();
                int bulls = 0;
                int cows = 0;
                int count = 0;
                bool flag = true;
                for (int i = 0; i < secret.Length; i++)
                {
                    s[i] = secret[i];
                    g[i] = guess[i];
                }

                for (int i = 0; i < s.Length; i++)
                {
                    if (s[i] == g[i])
                    {
                        bulls += 1;
                    }
                    else
                    {
                        numberlist.Add(s[i]);
                        numberlist2.Add(g[i]);
                    }
                }
                int len = numberlist.Count;
                while (flag)
                {
                    int i = 0;
                    count += 1;
                    for (int j = 0; j < numberlist2.Count; j++)
                    {
                        if (numberlist2[j] == numberlist[i])
                        {
                            cows += 1;
                            numberlist2.Remove(numberlist2[j]);
                            break;
                        }
                    }
                    numberlist.Remove(numberlist[i]);
                    if (count == len) { flag = false; }
                }
                string b = Convert.ToString(bulls);
                string c = Convert.ToString(cows);
                string final = bulls + "A" + cows + "B";
                return final;
            }
            catch (Exception)
            {

                throw;
            }
        }




        public static List<int> NumberOfLines(int[] widths, string s)
        {
            try
            {

                char[] ch2 = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                    'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                char[] ch = new char[s.Length];
                int index = 0;
                int sum = 0;
                int previoussum = 0;
                int result = 0;
                List<int> output = new List<int>();
                List<int> resultarray = new List<int>();
                for (int i = 0; i < s.Length; i++)
                {
                    ch[i] = s[i];
                }
                for (int i = 0; i < ch.Length; i++)
                {
                    index = Array.IndexOf(ch2, ch[i]);

                    previoussum = sum;
                    sum = widths[index] + sum;
                    if (sum <= 100)
                    {
                        result = sum;
                    }
                    else
                    {
                        sum -= previoussum;
                        resultarray.Add(result);
                        result = 0;
                    }
                }
                if (sum != 0)
                {
                    output.Add(resultarray.Count + 1);
                    output.Add(sum);

                }
                else
                {
                    output.Add(resultarray.Count);
                    output.Add(0);
                }

                return output;
            }
            catch (Exception)
            {
                throw;
            }
        }










        public static bool IsValid(string bulls_string10)
        {
            try
            {
                List<char> even = new List<char>();
                List<char> odd = new List<char>();
                bool flag = true;
                for (int i = 0; i < bulls_string10.Length; i++)
                {
                    if (i % 2 == 0)
                    {
                        even.Add(bulls_string10[i]);
                    }
                    else
                    {
                        odd.Add(bulls_string10[i]);
                    }
                }
                if (even.Count != odd.Count)
                {
                    flag = false;
                }
                else
                {
                    for (int i = 0; i < even.Count; i++)
                    {
                        if (even[i] == '(' && odd[i] == ')')
                        {

                        }
                        else if (even[i] == '[' && odd[i] == ']')
                        {

                        }
                        else if (even[i] == '{' && odd[i] == '}')
                        {

                        }
                        else
                        {
                            flag = false;
                        }
                    }
                }


                return flag;
            }
            catch (Exception)
            {
                throw;
            }


        }








        public static int UniqueMorseRepresentations(string[] words)
        {
            try
            {
                char[] ch = { 'a', 'b', 'c', 'd', 'e', 'f', 'g', 'h', 'i', 'j', 'k',
                    'l', 'm', 'n', 'o', 'p', 'q', 'r', 's', 't', 'u', 'v', 'w', 'x', 'y', 'z' };
                string[] str = { ".-", "-...", "-.-.", "-..", ".", "..-.", "--.", "....", "..", ".---",
                "-.-", ".-..", "--", "-.", "---",
                ".--.", "--.-", ".-.", "...", "-", "..-", "...-", ".--", "-..-", "-.--", "--.." };
                int index = 0;
                string value = "";
                Dictionary<string, string> worddict = new Dictionary<string, string>();
                foreach (string word in words)
                {
                    for (int i = 0; i < word.Length; i++)
                    {
                        index = Array.IndexOf(ch, word[i]);
                        value = value + str[index];
                    }
                    worddict.TryAdd(value, value);
                    value = "";
                }


                return worddict.Count;
            }
            catch (Exception)
            {
                throw;
            }

        }




        public static List<int> PartitionLabels(string s)
        {
            try
            {
                var result1 = new List<int>();

                int ii = 0;
                int n = s.Length;
                while (ii < n)
                {
                    int lIndex = s.LastIndexOf(s[ii]);

                    for (int j = ii + 1; j < lIndex; j++)
                    {
                        int index = s.LastIndexOf(s[j]);
                        if (index > lIndex)
                            lIndex = index;
                    }
                    result1.Add(lIndex + 1 - ii);
                    ii = lIndex + 1;
                }

                return result1;
            }
            catch (Exception)
            {
                throw;
            }
        }





    }
}
