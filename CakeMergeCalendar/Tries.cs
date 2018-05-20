using System;
using System.Collections.Generic;
using System.Linq;

namespace CakeMergeCalendar
{
    public static class Tries
    {
        public static void TriesMain()
        {
            var words = new[] { "hello", "help", "health", "here", "heresy", "helpful" };

            var root = new TrieNode('\\');

            foreach(var w in words)
            {
                root.Add(w, 0);
            }

            Console.WriteLine("start typing");

            var word = new List<char>();

            while (true)
            {
                var c = Console.ReadKey();

                word.Add(c.KeyChar);
                Console.WriteLine($"{Environment.NewLine} {new string(word.ToArray())}");
                //Console.WriteLine("hi");
                if (word.Count < 3)
                {
                    continue;
                }

                var suggestions = root.Suggestions(word.ToArray(), 0);

                foreach (var suggestion in suggestions)
                {
                    Console.WriteLine(suggestion);
                }
            }
        }
    }

    public class TrieNode
    {
        private Dictionary<char, TrieNode> _others = new Dictionary<char, TrieNode>();
        private static readonly TrieNode _endNode = new TrieNode('*');
        public char Value { get; set; }

        public TrieNode(char c)
        {
            Value = c;
        }

        public void Add(string word, int index) // h.e.l.l.o
        {
            if (index >= word.Length)
            {
                _others.Add(_endNode.Value, _endNode);
                return;
            }

            var current = word[index];

            TrieNode nextNode;

            if (_others.ContainsKey(current))
            {
                nextNode = _others[current];
            }
            else
            {
                nextNode = new TrieNode(current);
                _others.Add(nextNode.Value, nextNode);
            }

            nextNode.Add(word, index + 1);
        }


        public static TrieNode Create(TrieNode previous, string word, int index)
        {
            if (index >= word.Length)
            {
                return _endNode;
            }

            var current = word[index];

            if (previous.Value == current)
            {
                //var next
            }
            else
            {

            }

            var node = new TrieNode(current);

            previous.Add(node);

            return Create(node, word, index + 1);
        }

        private void Add(TrieNode node)
        {
            if (!_others.ContainsKey(node.Value))
            {
                _others.Add(node.Value, node);
            }

        }

        private TrieNode FindPrefix(char[] prefix, int index)
        {
            if (index >= prefix.Length)
            {
                return null;
            }

            var current = prefix[index];

            //if (index == prefix.Length - 1)
            //{
            //    return Value == current ? this : null;
            //}

            //if (index + 1 < prefix.Length)
            //{
            //    var 

            //    if (_others.ContainsKey)

            //    var nextNode = _others[prefix[index]];

            //    return nextNode.FindPrefix(prefix, index + 1);
            //}

            return null;
        }

        public List<List<string>> Suggestions(char[] word, int index)
        {
            List<List<string>> suggestions = new List<List<string>>();

            if (index >= word.Length)
            {
                return suggestions;
            }

            var prefixEnd = FindPrefix(word, index);

            if (prefixEnd == null)
            {
                return suggestions;
            }

            foreach(var key in prefixEnd._others.Keys)
            {

            }

            return suggestions;
        }
    }
}
