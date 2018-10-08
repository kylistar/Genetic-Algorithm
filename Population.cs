using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_AI
{
    class Population
    {
        Random rnd;
        private List<Tour> population_;
        public List<Tour> population { get => population_; set => population_ = value; }
        public Population(Random rnd)
        {
            this.rnd = rnd;
            population_ = new List<Tour>();
        }
        public Population(int size, List<Destination> destinations, Random rnd)
        {
            this.rnd = rnd;
            population_ = new List<Tour>();
            initPopulation(size, destinations);
        }

        public void initPopulation(int size, List<Destination> destinations)
        {
            for(int i = 0; i < size; i++)
            {
                population_.Add(new Tour());
                population_[i].route.AddRange(destinations);
                population_[i].Shuffle(rnd);
            }
        }

        public Tour getFittest()
        {
            Tour fittest = population_[0];
            for(int i = 1; i < population_.Count; i++)
            {
                if (fittest.getFitness() < population_[i].getFitness())
                    fittest = population_[i];
            }
            return fittest;
        }
    }
}
