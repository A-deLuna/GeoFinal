using Console;
namespace ProyectoFinal{
    public class ShortestPath{
        int INF = 1000000;
        int [,] parents;
        public static List<int,int> shortestPath(int [,] AdjMat, int begin, int end){
            int L = AdjMat.Length;
            parents - new int[L,L];
            for(int i = 0; i < L; i ++)
                for(int j = 0 ; j <L; j ++)
                    parents[i,j] = AdjMat[i,j] != INF?i:0;
            FloydWarshall(AdjMat,parents);
            List<int,int> path =  buildPath();
            return path;
        }
        public static void FloydWarshall(int [,] AdjMat,int [,] parents){
            int L = AdjMat.Length;
            for(int k = 0; k < L; k++){
                for(int i = 0; i < L; i ++){
                    for(int j = 0; j < L; j ++){
                        if(AdjMat[i,j] > AdjMat[i,k] + AdjMat[k,j]){
                            AdjMat[i,j] = AdjMat[i,k] + AdjMat[k,j];
                            parents[i,j] = parents[k,j];
                        }

                    }
                }
            }
        }
        public static void Main(){
            int [,] AdjMat = new int[,] {
                // A   B   C   D   E   F
                {  0,  7,  2,INF,INF,INF},//A
                {INF,  0,  2,INF,INF,INF},//B
                {INF,INF,  0,  1,INF,INF},//C
                {  3,INF,INF,  0,  4,INF},//D
                {INF,INF,  9,INF,  0,INF},//E
                {INF,INF,INF,  8,  6,  0} //E
            }
            parents - new int[L,L];
            for(int i = 0; i < L; i ++)
                for(int j = 0 ; j <L; j ++)
                    parents[i,j] = AdjMat[i,j] != INF?i:0;
            FloydWarshall(AdjMat, parents);
            PrintPath(parents,0,4);
            Console.WriteLine();
        }
        public static void PrintPath(int [,] parents,int  i, int j){
            if(i != j){
                PrintPath(parents,i,parents[i,j]);
            }
            Console.Write(j + " ");
        }


    }
}
