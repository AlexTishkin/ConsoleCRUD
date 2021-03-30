using System;
using System.IO;
using System.Threading.Tasks;

namespace ConsoleApp
{
    class Program
    {
        public static async Task Main(string[] args)
        {
            try
            {
                await new Application().RunAsync();
            }
            catch (Exception e)
            {
                File.AppendAllText($"log{DateTime.Now:yyyy-MM-ddTHH.mm}.txt", e.ToString());
                Console.WriteLine(Resources.Resources.Program_Main_Error);
                Console.ReadLine();
            }

        }
    }
}
