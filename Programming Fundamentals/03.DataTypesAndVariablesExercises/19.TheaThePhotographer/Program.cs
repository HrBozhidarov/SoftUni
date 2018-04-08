namespace P19_TheaThePhotographer
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var countOfPics = long.Parse(Console.ReadLine());
            var filterTimeOnePic = long.Parse(Console.ReadLine());
            var percentGoodPics = long.Parse(Console.ReadLine());
            var timeToUploadPic = long.Parse(Console.ReadLine());

            var filterTimeAll = countOfPics * filterTimeOnePic;
            var choosenPics = Math.Ceiling((percentGoodPics / 100d) * countOfPics);
            timeToUploadPic *= (long)choosenPics;
            var totalTime = filterTimeAll + timeToUploadPic;

            TimeSpan clock = TimeSpan.FromSeconds(totalTime);
            Console.WriteLine("{0:d\\:hh\\:mm\\:ss}", clock);
        }
    }
}
