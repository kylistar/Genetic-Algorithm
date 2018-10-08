using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_AI
{
    class Tour
    {
        private List<Destination> rout;
        private double fitness = 0;
        private double distance = 0;
        public List<Destination> route { get => rout; set => rout = value; }

        public Tour()
        {
            rout = new List<Destination>();
        }
        public double getDistance()
        {
            if (distance == 0)
            {
                for (int i = 0; i < (rout.Count() - 1); i++)
                {
                    distance += rout[i + 1].distanceFrom(rout[i]);
                }
                distance += rout[0].distanceFrom(rout[51]);
            }
            return distance;
        }
        public double getFitness()
        {
            if (fitness == 0)
            {
                fitness = 1 / getDistance();
            }
            return fitness;
        }

        public List<Destination> Shuffle(Random rnd)
        {
            int n = rout.Count;
            while (n > 1)
            {
                n--;
                int k = rnd.Next(n + 1);
                Destination value = rout[k];
                rout[k] = rout[n];
                rout[n] = value;
            }
            return rout;
        }
    }
}
