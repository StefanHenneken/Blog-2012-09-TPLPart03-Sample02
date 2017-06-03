using System;
using System.Threading.Tasks;

namespace Sample02
{
    class Program
    {
        static void Main(string[] args)
        {
            new Program().Run();
        }
        public void Run()
        {
            int x = 0;
            // int x = 1;

            Task<int> taskRoot = new Task<int>((para) =>
            {
                Console.WriteLine("taskRoot x ist: {0}", (int)para);
                int y = 1 / (int)para;
                return y;
            }, x);

            taskRoot.ContinueWith((taskSuccess) =>
            {
                Console.WriteLine("taskSuccess");
            }, TaskContinuationOptions.NotOnFaulted);

            taskRoot.ContinueWith((taskError) =>
            {
                Console.WriteLine("taskError");
            }, TaskContinuationOptions.OnlyOnFaulted);

            taskRoot.Start();

            Console.ReadLine();
        }
    }
}
