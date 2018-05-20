using System;
using System.Collections.Generic;
using System.Text;

namespace CakeMergeCalendar
{
    public class Graph
    {
        private HashSet<int>[] _adj;

        public Graph(int vCount)
        {
            _adj = new HashSet<int>[vCount];
        }

        public void AddEdge(int v, int w)
        {
            if (_adj[v] == null)
            {
                _adj[v] = new HashSet<int>();
            }

            _adj[v].Add(w);
        }

        public void AddListEntry(int v, params int [] vs)
        {
            if (_adj[v] == null)
            {
                _adj[v] = new HashSet<int>(vs);
            }
        }
    }

    public static class GraphAdjacency
    {
        public static void GraphAdjacencyMain()
        {
            /*
            0 - 1, 2, 5, 6
            1 - 0
            2 - 0
            3, - 5, 4
            4 - 5, 3
            5 - 3, 4
            6 - 0, 4
            7 - 6, 8
            8 - 7, 10
            9 - 10, 11, 12
            10 - 8, 9
            11 - 9, 12
            12 - 9, 11
            */

            var g = new Graph(13);
            g.AddListEntry(0, 1, 2, 5, 6);
            g.AddListEntry(1, 0);
            g.AddListEntry(2, 0);
            g.AddListEntry(3, 5, 4);
            g.AddListEntry(4, 5, 3);
            g.AddListEntry(5, 3, 4);
            g.AddListEntry(6, 0, 4);
            g.AddListEntry(7, 6, 8);
            g.AddListEntry(8, 7, 10);
            g.AddListEntry(9, 10, 11, 12);
            g.AddListEntry(10, 8, 9);
            g.AddListEntry(11, 9, 12);
            g.AddListEntry(12, 9, 11);
        }
    }
}
