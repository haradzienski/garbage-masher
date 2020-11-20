using System;
using MashingService;

namespace CLI
{
    class Program
    {
        static void Main(string[] args)
        {
            var masher = new MashingService();
            return masher.Mash(args[0] ?? "");
        }
    }
}
