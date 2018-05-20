using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public static class PalindromePermuation
    {
        public static void PalindromePermuationMain()
        {
            var words = new[] { "civic", "ivicc", "civil", "livci" };

            foreach (var word in words)
            {
                Console.WriteLine($"word: {word} is Palindromic? {IsPalindromicPerm(word)}");
            }
        }

        static bool IsPalindromicPerm(string word)
        {
            var dict = new Dictionary<char, int>();

            foreach (var c in word)
            {
                if (dict.ContainsKey(c))
                {
                    dict[c] += 1;
                }
                else
                {
                    dict.Add(c, 1);
                }
            }

            if (dict.Count == 1)
            {
                return true;
            }

            var hasOne = false;

            foreach(var i in dict)
            {
                if (i.Value == 1)
                {
                    if (hasOne)
                    {
                        return false;
                    }
                    else
                    {
                        hasOne = true;
                    }
                }
                else if (i.Value % 2 == 1)
                {
                    return false;
                }                
            }

            return true;
        }
    }
}
