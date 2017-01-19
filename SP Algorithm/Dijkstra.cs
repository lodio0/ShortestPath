using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Dijkstra : ShortestPath
    {
        private List<int> tempVertex;
        protected bool[] isStatic;

        public Dijkstra(Graph Gr ) : base(Gr)
        {
            tempVertex = new List<int>();
            isStatic = new bool[Gr.V];
        }

        private int FindMaxDist(ref int u)
        {
            int maxDist=Int32.MaxValue;
            foreach (int v in tempVertex)
            {
                if (dist[v] < maxDist && !isStatic[v])
                {
                    maxDist = dist[v];
                    u = v;
                    continue;
                }
                if (isStatic[v])
                {
                    tempVertex.Remove(v);
                }
            }
            return maxDist;
        }

        public override int[] CountShortestPathToAll(int Src)
        {
            int u=Src;

            for (int i = 0; i < Gr.V; i++)
            {
                dist[i] = Int32.MaxValue;
                isStatic[i] = false;
            }

            tempVertex.Add(Src);
            dist[Src] = 0;
            while(true)
            {
                int maxDist = FindMaxDist(ref u);
                if (maxDist == Int32.MaxValue)
                    break;

                foreach (Arc arc in Gr.G[u])
                {
                    int cost = arc.Cost;
                    int v = arc.Vertex;

                    if(dist[v]>dist[u]+cost && !isStatic[v])
                    {
                        dist[v] = dist[u] + cost;
                        tempVertex.Add(v);
                    }
                }
                tempVertex.Remove(u);
                isStatic[u] = true;
            }
            return dist;
        }

    public override int[] CountShortestPathToAll(int v1, int v2)
    {
        return CountShortestPathToAll(v1);
    }
}

