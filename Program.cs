using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_AI
{
    class Program
    {
        static void Main(string[] args)
        {
            Random rnd = new Random();
            List<Destination> destinations = new List<Destination>();
            Initialize init = new Initialize(destinations);
            Population pop = new Population(50, destinations, rnd);
            GA ga = new Labb_3_AI.GA(rnd);
            Console.WriteLine("Distance before: "+pop.getFittest().getDistance());
            var timer = System.Diagnostics.Stopwatch.StartNew();

            for (int i = 0; i < 10000; i++)
            {
                pop = ga.evolve(pop);

                if (i % 1000 == 0)
                    Console.WriteLine("Distance in the middle: " + pop.getFittest().getDistance());

                if (pop.getFittest().getDistance() < 9000)
                {
                    timer.Stop();
                    Console.WriteLine("BFS: {0} ms", timer.ElapsedMilliseconds);
                    break;
                }
            }
            timer.Stop();
            Console.WriteLine("BFS: {0} ms", timer.ElapsedMilliseconds);

            Console.WriteLine("Distance After: " + pop.getFittest().getDistance());

            Console.WriteLine();
        }
    }
}
