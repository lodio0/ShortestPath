using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    public class Graph
    {
        public int V { get; private set; }
        public List<Arc>[] G;

        public Graph(int V)
        {
            this.V = V;
            Console.WriteLine(this.V);
            G = new List<Arc>[V];
            for(int i =0 ; i <V ; i++)
            {
                G[i] = new List<Arc>();
            }
        }
        public virtual void AddEdge(int u, int v, int cost)
        {
            G[u].Add(new Arc() { Vertex = v, Cost = cost });
            G[v].Add(new Arc() { Vertex = u, Cost = cost });
        }
    }

