using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

    class Dial : ShortestPath
    {
        public Dial(Graph V) : base(V)
        {

        }

        private void FindNoEmptyBucket(ref int idx, LinkedList<int>[] bucket, int C)
        {
            while (bucket[idx].Count == 0 && idx < C * Gr.V)
            {
                idx++;
            }
        }

        public override int[] CountShortestPathToAll(int Src, int C)
        {
            int V=Gr.V;
            LinkedList<int>[] bucket = new LinkedList<int>[C *V + 1];
            LinkedListNode<int>[] vertexInBucket = new LinkedListNode<int>[V ];
            for (int i = 0; i < C * V + 1;i++ )
            {
                bucket[i] = new LinkedList<int>();
            }
            for (int i = 0; i < V; i++ )
            {
                dist[i] = Int32.MaxValue;
            }
            bucket[0].AddLast(Src);
            dist[Src] = 0;
            int idx=0;
            while(true)
            {

                FindNoEmptyBucket(ref idx, bucket, C);

                if (idx == C * V)
                    break;

                int u = bucket[idx].First.Value;
                bucket[idx].RemoveFirst();

                foreach(Arc arc in Gr.G[u])
                {
                    int cost = arc.Cost;
                    int v = arc.Vertex;
                    if(dist[v] > dist[u]+cost)
                    {
                        if (dist[v] != Int32.MaxValue)
                            bucket[dist[v]].Remove(vertexInBucket[v]);
                        dist[v] = dist[u] + cost;
                        bucket[dist[v]].AddFirst(v);
                        vertexInBucket[v] = bucket[dist[v]].First;
                    }
                }
            }

                return dist;
        }
             
        public override int[] CountShortestPathToAll(int Src)
       {
        int max=0;
        foreach(var arcArray in Gr.G)
        {
            foreach(Arc arc in arcArray)
            {
                if (max < arc.Cost)
                    max = arc.Cost;
            }
        }
        return CountShortestPathToAll(Src, max);
       }
    }
