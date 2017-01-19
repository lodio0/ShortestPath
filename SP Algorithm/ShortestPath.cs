
    public abstract class ShortestPath
    {
        protected Graph Gr;
        protected int[] dist;


        public ShortestPath(Graph Gr)
        {
            this.Gr = Gr;
            dist = new int[Gr.V];
        }
        public abstract int[] CountShortestPathToAll(int Src);
        public abstract int[] CountShortestPathToAll(int v1, int v2);
}
