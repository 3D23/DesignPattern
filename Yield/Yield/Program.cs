using System.Collections;

class Program
{
    static IEnumerator GetInts()
    {
        Console.WriteLine("first");
        yield return 1;

        Console.WriteLine("second");
        yield return 2;
    }

    static IEnumerator GetMultiplicationsInts(int maxValue)
    {
        for (int i = 0; i < 10; i++)
        {
            for (int  j = 0; j < 10; j++)
            {
                int result = i * j;

                if (result > maxValue)
                    yield break;

                yield return result;
            }
        }
    }

    static IEnumerable GetFibonacci(int maxValue)
    {
        int previous = 0;
        int current = 1;

        while (current < maxValue)
        {
            yield return current;

            int newCurrent = previous + current;
            previous = current;
            current = newCurrent;
        }
    }
    static void PrintFibonacci()
    {
        Console.WriteLine("Fibonacci numbers: ");

        foreach (int number in GetFibonacci(100))
        {
            Console.WriteLine(number);
        }
    }

    static void Main(string[] args)
    {
        /*IEnumerator enumerator = GetInts();
        Console.WriteLine("---");
        enumerator.MoveNext();
        Console.WriteLine(enumerator.Current);*/
      
        /*IEnumerator enumerator = GetMultiplicationsInts(75);
        while (enumerator.MoveNext())
        {
            Console.WriteLine(enumerator.Current);
        }*/

        /*PrintFibonacci();*/

    }
}
