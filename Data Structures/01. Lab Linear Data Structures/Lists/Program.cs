using System.Collections.Generic;

public class Program
{
    public static void Main(string[] args)
    {
        var a = new List<int>();

        a.Add(1);
        a.Add(2);
        a[1] = 1;
        foreach (var item in a)
        {
            System.Console.WriteLine(item);
        }
    }
}
