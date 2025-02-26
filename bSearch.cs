List<int> a = new List<int>();
int n, target, steps = 0;

void initData()
{
    n = 1000000;

    for (int i = 0; i<n; i=i+5)
    {
        a.Add(i);
    }
    Console.WriteLine("Objetivo: ");
    target = int.Parse(Console.ReadLine());
}

int bSearch(List<int> a, int l, int target)
{
    l = a.Count();
    int Left = 0, Right = l-1, Mid;

    while (Left <= Right)
    {
        steps++;
        Mid = (Left + Right) / 2;
        if (a[Mid] == target)
        {
            return Mid;
        }
        if (a[Mid]<target)
        {
            Left = Mid + 1;
        }
        else
        {
            Right = Mid-1;
        }
    }
    return -1;
}

initData();
Console.WriteLine("Objetivo en el índice: " + bSearch(a, n, target));
Console.WriteLine("Pasos: " + steps);
