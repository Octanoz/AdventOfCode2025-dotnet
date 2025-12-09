namespace Day08;


public class CircuitNetwork(int n)
{
    private readonly int[] parent = [.. Enumerable.Range(0, n)];
    private readonly int[] size = [.. Enumerable.Repeat(1, n)];

    public int FindParent(int x)
    {
        if (parent[x] != x)
            parent[x] = FindParent(parent[x]);

        return parent[x];
    }

    public void Connect(int a, int b)
    {
        var (rootA, rootB) = (FindParent(a), FindParent(b));
        if (rootA == rootB)
            return;

        if (size[rootA] < size[rootB])
        {
            var temp = rootA;
            rootA = rootB;
            rootB = temp;
        }

        parent[rootB] = rootA;
        size[rootA] += size[rootB];
    }

    public int[] GetSizes()
    {
        Dictionary<int, int> rootSizes = [];
        for (int i = 0; i < parent.Length; i++)
        {
            int root = FindParent(i);
            rootSizes[root] = size[root];
        }

        return [.. rootSizes.Values];
    }
}
