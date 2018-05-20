using System;

namespace CakeMergeCalendar
{
    public class SearchRotationPointOfDictionary
    {
        public static void SearchRotationPointOfDictionaryMain()
        {
            var words = new string[]
            {
                "ptolemaic",
                "retrograde",
                "supplant",
                "undulate",
                "xenoepist",
                "asymptote",  // <-- rotates here!
                "babka",
                "banoffee",
                "engender",
                "karpatka",
                "othellolagkage",
            };

            var index = FindRotation(words);
            Console.WriteLine(index);
        }

        private static int FindRotation(string[] words)
        {
            return FindRotationImpl(words, 0, words.Length - 1);
        }

        private static int FindRotationImpl(string[] words, int start, int end)
        {
            string firstWord = words[0];

            int floorIndex = 0;
            int ceilingIndex = words.Length - 1;

            while (floorIndex < ceilingIndex)
            {
                // Guess a point halfway between floor and ceiling
                int guessIndex = floorIndex + ((ceilingIndex - floorIndex) / 2);

                // If guess comes after first word or is the first word
                if (string.Compare(words[guessIndex], firstWord, StringComparison.Ordinal) >= 0)
                {
                    // Go right
                    floorIndex = guessIndex;
                }
                else
                {
                    // Go left
                    ceilingIndex = guessIndex;
                }

                // If floor and ceiling have converged
                if (floorIndex + 1 == ceilingIndex)
                {
                    // Between floor and ceiling is where we flipped to the beginning,
                    // so ceiling is alphabetically first
                    break;
                }
            }

            return ceilingIndex;

        }
    }
}
