using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class DirectedGraph : Graph
    {
        public DirectedGraph(int V)
            : base(V)
        {

        }
        public override void AddEdge(int u, int v, int cost)
        {
            G[u].Add(new Arc() { Vertex = v, Cost = cost });
        }
    }

