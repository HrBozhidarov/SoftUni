namespace P08_MostFrequentNumber
{
    using System;
    using System.Linq;

    class StartUp
    {
        static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split().Select(long.Parse).ToArray();
                   
            var countHelper = 0;
            var digit=numbers[0];

            for (long i = 0; i < numbers.Length-1; i++)
            {
                var count = 0;

                for (long j =i+1 ; j < numbers.Length; j++)
                {
                    if (numbers[i]==numbers[j])
                    {
                        count++;
                    }
                }
                if (count>countHelper)
                {
                    digit = numbers[i];
                    countHelper = count;
                }            
            }

            Console.WriteLine(digit);
        }
    }
}
