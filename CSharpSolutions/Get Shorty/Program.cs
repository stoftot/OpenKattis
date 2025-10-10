using System;
using System.Collections.Generic;

namespace Get_Shorty;

class Program
{
    static void Main(string[] args)
    {
        while (true)
        {
            var dimensions = Console.ReadLine().Split(" ");
            int n = int.Parse(dimensions[0]);
            int m = int.Parse(dimensions[1]);
            if(m == 0 && n == 0) break;

            var dijkstras = new Dijkstra(n);
            
            for (int i = 0; i < m; i++)
            {
                var corridor = Console.ReadLine().Split(" ");
                var x = int.Parse(corridor[0]);
                var y = int.Parse(corridor[1]);
                var f = float.Parse(corridor[2]);
                
                dijkstras.AddUndirectedEdge(x, y, f);
            }
            
            Console.WriteLine(dijkstras.Run().ToString("0.0000"));
        }
    }

    private record Corridor(int Y, float F);

    private class Dijkstra
    {
        List<Corridor>[] adjacencyList;
        float[] dist;

        public Dijkstra(int n)
        {
            adjacencyList = new List<Corridor>[n];
            dist = new float[n];
            for (int i = 0; i < n; i++)
            {
                adjacencyList[i] = [];
                dist[i] = 0;
            }
        }
        private record path(int X, float Mikael);
        
        public void AddUndirectedEdge(int x, int y, float f)
        {
            adjacencyList[x].Add(new Corridor(y,f));
            adjacencyList[y].Add(new Corridor(x,f));
        }

        public float Run()
        {
            int start = 0;
            int end = dist.Length - 1;
            dist[start] = 1;
            
            var compare = Comparer<float>.Create((x, y) => y.CompareTo(x));
            var q = new PriorityQueue<path, float>(compare);
            q.Enqueue(new path(start, dist[start]),dist[start]);

            while (q.Count > 0)
            {
                var current = q.Dequeue();
                if (current.Mikael < dist[current.X]) continue;
                if (current.X == end) break;
                
                foreach (var adjacent in adjacencyList[current.X])
                {
                    var cand = dist[current.X] * adjacent.F;
                    if (cand <= dist[adjacent.Y]) continue;
                    dist[adjacent.Y] = cand;
                    q.Enqueue(new path(adjacent.Y, dist[adjacent.Y]), dist[adjacent.Y]);
                }
            }

            return dist[end];
        }
    }
}