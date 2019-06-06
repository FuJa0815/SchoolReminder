using System;
using System.Threading.Tasks;

namespace SchoolReminder
{
    class Program
    {
        static void Main(string[] args)
        {
            Task.Run(() => AsyncMain(args)).Wait();
        }

        static async void AsyncMain(string[] args)
        {
            await foreach (var l in WebUntisExtractor.GetLessons())
            {
                Console.WriteLine(l.ID);
            }
        }
    }
}
