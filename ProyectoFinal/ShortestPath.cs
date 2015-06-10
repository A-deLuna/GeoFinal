using System;
using System.Collections.Generic;
namespace ProyectoFinal{
    public class ShortestPath{
        static int INF = 1000000;
        //static int [,] parents;
        /*public static List<Tuple<int,int> > shortestPath(int [,] AdjMat, int begin, int end){
            int L = AdjMat.Length;
            parents = new int[L,L];
            for(int i = 0; i < L; i ++)
                for(int j = 0 ; j <L; j ++)
                    parents[i,j] = AdjMat[i,j] != INF?i:0;
            FloydWarshall(AdjMat,parents);
            List<int,int> path =  buildPath();
            return path;
        }
        */
        private static void create_path(int i, int j, int [] parent, List<Tuple<int, int > > path){
            if(i == j){
                return;
            }
            create_path(i,parent[j],parent,path);
            path.Add(new Tuple<int,int>(parent[j],j));
        }
        private static void print_path(int i, int j,int [] parent){
            if(i == j){
                Console.Write(i + " ");
                return;
            }
            print_path(i,parent[j],parent);
            Console.Write(j + " ");

        }
        public static List<Tuple<int, int> > Dijkstra(int S, int F, int[,] Adj){
			
            int n = Adj.GetLength(0);
			for (int i = 0; i < n; i++) {
				for (int j = 0; j < n; j++) {
					Console.Write (Adj [i, j] + " ");
				}
				Console.WriteLine ();
			}

			int [] dist = new int[n];
            bool [] vis = new bool[n];
            int [] parent = new int[n];

            for(int i = 0; i < n; i++){
                dist[i] = INF;
                parent[i] = -1;
            }
            dist[S] = 0;
            parent[S] = S;
            for(int i = 0; i < n; i ++){
                int curr = -1;
                for(int j =0; j <n; j++){
                    if(vis[j]) continue;
                    if(curr == -1 || dist[j] < dist[curr]){
                        curr = j;
                    }
                }
                vis[curr] = true;
                for(int j = 0; j < n; j++){
                    int newdist = dist[curr] + Adj[curr,j];
                    if(newdist < dist[j]){
                        dist[j] = newdist;
                        parent[j] = curr;
                    }
                }
            }
            if(parent[F] == -1) return null;
            print_path(S,F,parent);
            List<Tuple<int, int> > path = new List<Tuple<int,int> >();
            create_path(S,F,parent,path);
            return path;
            
        }
        public static List<Tuple<int, int> > OtherPath(int S, int F, int[,] Adj){
            List<Tuple<int, int> > originalPath = Dijkstra(S,F,Adj);
            List<Tuple<int, int> > other = null;
            for(int i = 0; i <originalPath.Count; i ++){
                Tuple<int, int> edge = originalPath[i];
                int savedCost = Adj[edge.Item1,edge.Item2];
                Adj[edge.Item1,edge.Item2] = INF;
                other = Dijkstra(S,F,Adj);
                Adj[edge.Item1,edge.Item2] = savedCost;
                if(other != null) break;
            }
            return other;
        }
   /*     public static void Main(){
            INF = 1000000;
            int [,] AdjMat = new int[,] {
                // A   B   C   D   E   F
                {  0,  7,  2,INF,INF,INF},//A
                {INF,  0,INF,INF,  5,INF},//B
                {INF,  1,  0,  1,INF,INF},//C
                {  3,INF,INF,  0,  4,INF},//D
                {INF,INF,  9,INF,  0,INF},//E
                {INF,INF,INF,  8,  6,  0} //F
            };
            List<Tuple<int,int> > path = Dijkstra(4,1, AdjMat);
            foreach(var x in path){
                Console.WriteLine(x.Item1 + " " + x.Item2);
            }
            Console.WriteLine();
            path = OtherPath(4,1, AdjMat);
            if(path != null)
            foreach(var x in path){
                Console.WriteLine(x.Item1 + " " + x.Item2);
            }
            Console.WriteLine();
        }
	*/
    }
}
