
using System;
using System.Collections.Generic;

class Graph
{

    public static void Main(String[] args)
    {
        var greatBarrierReef = new List<string> {
            "1100", // person 1 
            "1110", // person 2
            "0110", // person 3
            "0001"  // person 4
        };
        /*
         * (1,2) 
         * (2,1) (2,3)
         * (3,2) 
         * 
         *
         */
        Console.WriteLine(numGroups(greatBarrierReef));
    }

    static int numGroups(List<String> greatBarrierReef)
    {
        int n = greatBarrierReef.Count;
        bool[,] matrix = new bool[n, n];

        for (int i = 0; i < n; i++)
        {
            var str = greatBarrierReef[i];
            for (int j = 0; j < n; j++)
            {
                if (str[j] == '1')
                {
                    matrix[i, j] = true;
                }
                else
                {
                    matrix[i, j] = false;
                }
            }
        }

        return countGroups(matrix, n);
    }

    static void DFS(bool[,] matrix, int n, bool[] visited, int v)
    {
        for (int i = 0; i < n; ++i)
        {
            if (matrix[v, i] == true && !visited[i] && i != v)
            {
                visited[i] = true;
                DFS(matrix, n, visited, i);
            }
        }
    }

    static int countGroups(bool[,] matrix, int n)
    {
        if (n == 0)
        {
            return 0;
        }

        int numGroups = 0;

        bool[] visited = new bool[n];

        for (int i = 0; i < n; i++)
        {
            visited[i] = false;
        }


        for (int i = n-1; i >= 0; i--)
        {
            if (!visited[i])
            {
                visited[i] = true;
                DFS(matrix, n, visited, i);
                numGroups = numGroups + 1;
            }
        }

        return numGroups;
    }
}

