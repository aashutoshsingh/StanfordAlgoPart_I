using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StanfordAlgoPart_I.Graph
{
    class Graph
    {
        List<int> vertices = new List<int>();
        List<KeyValuePair<int,int>> edges = new List<KeyValuePair<int, int>>();
        Dictionary<int, List<int>> edgeHeadToTail = new Dictionary<int, List<int>>();
        Dictionary<int, List<int>> edgeTailToHead = new Dictionary<int, List<int>>();

        public void AddEdge(int head, int tail)
        {
            //We are assuming that graph will be connected graph and 
            //we will add graph using only add edge
            var edge = new KeyValuePair<int,int>(head, tail);
            if (!edges.Contains(edge))
            {
                edges.Add(edge);
                AddVertex(head);
                AddVertex(tail);
                if (edgeHeadToTail.ContainsKey(head))
                    edgeHeadToTail[head].Add(tail);
                else
                    edgeHeadToTail.Add(head, new List<int>() { tail });

                if (edgeTailToHead.ContainsKey(tail))
                    edgeTailToHead[tail].Add(head);
                else
                    edgeTailToHead.Add(tail, new List<int>() { head });
            }
        }

        private void AddVertex(int vertex)
        {
            if (!vertices.Contains(vertex))
                vertices.Add(vertex);
        }
    }
}
