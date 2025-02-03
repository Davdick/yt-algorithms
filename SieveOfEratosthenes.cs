bool[] isPrime;

void sieveOfEratosthenes(int n)
{
    isPrime = new bool[n+1];
    for(int i = 2; i<=n; i++)
        isPrime[i] = true;

    for(int i = 2; i*i <= n; i++)
        if (isPrime[i] == true)
            for(int j = i*i; j<=n; j+=i)
                isPrime[j] = false;
}

int n = 997;

sieveOfEratosthenes(n);
for (int i = 2; i <= n; i++)
    if (isPrime[i] == true)
        Console.WriteLine(i +" ");
