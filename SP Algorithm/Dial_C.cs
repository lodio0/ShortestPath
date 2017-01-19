using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Dial_C : ShortestPath
{
    public Dial_C(Graph V)
        : base(V)
    {

    }

    private void FindNoEmptyBucket(ref int idx, ref int lvl, LinkedList<int>[] bucket, int[] bucket_max, int[] bucket_min)
    {
        int V = Gr.V;
        while (lvl < V + 1 && bucket[idx].Count == 0 && idx <= (bucket_max[lvl] + 1))
        {
            if (idx > bucket_max[lvl])
            {

                lvl++;
                if (lvl < V + 1)
                    idx = bucket_min[lvl];
                continue;
            }
            idx++;
        }
    }

    private void FindMinInBucket(ref int u , ref LinkedList<int>[] bucket,int lvl,int V,int idx)
    {
        LinkedListNode<int> node = bucket[idx].First;
        while (node != null)
        {
            u = node.Value;
            if (dist[u] / V != lvl)
            {
                u = -1;
                node = node.Next;
                continue;
            }
            bucket[idx].Remove(node);
            break;

        }

    }
    public override int[] CountShortestPathToAll(int Src, int C)
    {
        int V = Gr.V;
        int lvl = 0;
        int[] bucket_min = new int[V + 1];
        int[] bucket_max = new int[V + 1];
        LinkedList<int>[] bucket = new LinkedList<int>[C + 1];
        LinkedListNode<int>[] vertexInBucket = new LinkedListNode<int>[V];
        for (int i = 0; i < C + 1; i++)
        {
            bucket[i] = new LinkedList<int>();
        }
        for (int i = 0; i < V; i++)
        {
            bucket_max[i] = V;
            bucket_min[i] = V;
            dist[i] = Int32.MaxValue;
        }
        bucket[0].AddLast(Src);
        dist[Src] = 0;
        int idx = 0;
        while (true)
        {
            FindNoEmptyBucket(ref idx, ref lvl, bucket, bucket_max, bucket_min);

            if (lvl == V + 1)
                break;

            int u = -1;

            FindMinInBucket(ref u,ref bucket, lvl, V, idx);

            if (u == -1)
            {
                idx++;
                continue;
            }

            foreach (Arc arc in Gr.G[u])
            {
                int cost = arc.Cost;
                int v = arc.Vertex;
                int du = dist[u];
                if (dist[v] > du + cost)
                {
                    if (bucket_max[(du + cost) / V] < (du + cost) % V)
                        bucket_max[(du + cost) / V] = (du + cost) % V;
                    if (bucket_min[(du + cost) / V] > (du + cost) % V)
                    {
                        bucket_min[(du + cost) / V] = (du + cost) % V;

                    }
                    if (dist[v] != Int32.MaxValue)
                        bucket[dist[v]%V].Remove(vertexInBucket[v]);
                    dist[v] = dist[u] + cost;
                    bucket[dist[v]%V].AddFirst(v);
                    vertexInBucket[v] = bucket[dist[v]%V].First;
                }
            }
        }

        return dist;
    }

    public override int[] CountShortestPathToAll(int Src)
    {
        int max = 0;
        foreach (var arcArray in Gr.G)
        {
            foreach (Arc arc in arcArray)
            {
                if (max < arc.Cost)
                    max = arc.Cost;
            }
        }
        return CountShortestPathToAll(Src, max);
    }
}
