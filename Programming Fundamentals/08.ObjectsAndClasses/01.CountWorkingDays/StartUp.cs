using System;
using System.Globalization;

public class StartUp
{
    public static void Main()
    {
        var firstDate = Console.ReadLine();
        var secondDate = Console.ReadLine();

        var freeDays = new DateTime[]
        {
            new DateTime(2016,1,1),
            new DateTime(2016,3,3),
            new DateTime(2016,5,1),
            new DateTime(2016,5,6),
            new DateTime(2016,5,24),
            new DateTime(2016,9,6),
            new DateTime(2016,9,22),
            new DateTime(2016,11,1),
            new DateTime(2016,12,24),
            new DateTime(2016,12,25),
            new DateTime(2016,12,26),
        };

        var startDateTime = DateTime.ParseExact(firstDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);
        var endDateTime = DateTime.ParseExact(secondDate, "dd-MM-yyyy", CultureInfo.InvariantCulture);

        int count = 0;

        for (var dateTime = startDateTime; dateTime <= endDateTime; dateTime = dateTime.AddDays(1))
        {
            var isFree = false;

            if (dateTime.DayOfWeek.ToString() == "Saturday" || dateTime.DayOfWeek.ToString() == "Sunday")
            {
                continue;
            }

            for (int i = 0; i < freeDays.Length; i++)
            {
                if (freeDays[i].Day == dateTime.Day && freeDays[i].Month == dateTime.Month)
                {
                    isFree = true;
                    break;
                }
            }

            if (isFree)
            {
                continue;
            }

            count++;
        }

        Console.WriteLine(count);
    }
}