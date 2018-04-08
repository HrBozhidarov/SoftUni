namespace P04_VariableInHexFormat
{
    using System;

    public class Program
    {
        public static void Main()
        {
            var inHexaFormat = Console.ReadLine();
            var HexaToDecFormat = Convert.ToInt32(inHexaFormat, 16);

            Console.WriteLine(HexaToDecFormat);   
        }
    }
}
