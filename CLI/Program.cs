using System;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var masher = new MashingService.MashingService();
            Console.WriteLine(masher.Mash(args[0] ?? ""));
        }
    }
}
