using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public static class Parenthesis
    {
        public static void ParenthesisMain()
        {
            var parenOpenCount = 0;
            var parenStart = -1;
            var parenEnd = -1;

            var input = "Sometimes (when I nest them (my parentheticals) too much (like this (and this))) they get confusing.";

            for(var i = 0; i < input.Length; i++)
            {
                var c = input[i];
                if (c == '(')
                {
                    if (parenStart == -1)
                    {
                        parenStart = i;
                    }
                    parenOpenCount += 1;
                }

                if (c == ')')
                {                    
                    parenOpenCount -= 1;

                    if (parenStart >= 0 && parenOpenCount == 0)
                    {
                        parenEnd = i;
                    }
                }
            }

            Console.WriteLine($"start:{parenStart}; end:{parenEnd}");
        }
    }
}
