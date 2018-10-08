using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Labb_3_AI
{
    class GA
    {
        Random rnd;
        private static double mutationRate = 0.015;
        private static int tournamentSize = 5;
        public GA(Random rnd)
        {
            this.rnd = rnd;
        }
        public Population evolve(Population pop)
        {
            Tour parent1, parent2, cross;
            int i;
            Population newPopulation = new Population(rnd);
            newPopulation.population.Add(pop.getFittest());     //elitism
            for(i = 1; i < pop.population.Count(); i++)     
            {
                parent1 = tournamentSelect(pop);                //tournament selection of 2 parents for crossover
                parent2 = tournamentSelect(pop);
                cross = crossover(parent1, parent2);


                newPopulation.population.Add(cross);
            }

            for (i = 1; i < pop.population.Count(); i++)
                mutate(newPopulation.population[i]);


            return newPopulation;
        }
        public Tour crossover(Tour parent1, Tour parent2)
        {
            List<Destination> parent1Yes = new List<Destination>();
            Tour offspring = new Tour();
            int tourSize = parent1.route.Count();

            int startPos = rnd.Next(tourSize);
            int endPos = rnd.Next(startPos + 1, tourSize + 1);
            int i;

            for (i = startPos; i < endPos; i++)
            {
                parent1Yes.Add(parent1.route[i]);
            }
            for (i = 0; i < tourSize; i++)
            {
                if (i == startPos)
                    offspring.route.AddRange(parent1Yes);

                if (!parent1Yes.Exists(element => element.ID == parent2.route[i].ID))
                {
                        offspring.route.Add(parent2.route[i]);
                }
            }
            return offspring;
        }
        public Tour tournamentSelect(Population pop)
        {
            Population tournament = new Population(rnd);
            int randomID;
            for(int i = 0; i < tournamentSize; i++)
            {
                randomID = rnd.Next(pop.population.Count());
                tournament.population.Add(pop.population[randomID]);
            }
            Tour temp = tournament.getFittest(), bestTour = new Tour();
            foreach(Destination d in temp.route)
            {
                bestTour.route.Add(new Destination(d.ID, d.X, d.Y));
            }
            return bestTour;// tournament.getFittest();
        }
        public void mutate(Tour mutate)
        {
            Destination d1 = new Destination(0,0,0), d2 = new Destination(0, 0, 0);
            int randomPos;
            for(int i = 0; i < mutate.route.Count(); i++)
            if(rnd.NextDouble() < mutationRate)
            {
                d1.ID = mutate.route[i].ID;
                d1.X = mutate.route[i].X;
                d1.Y = mutate.route[i].Y;
                randomPos = rnd.Next(52);
                d2.ID = mutate.route[randomPos].ID;
                d2.X = mutate.route[randomPos].X;
                d2.Y = mutate.route[randomPos].Y;

                mutate.route[i].ID = d2.ID;
                mutate.route[i].X = d2.X;
                mutate.route[i].Y = d2.Y;
                mutate.route[randomPos].ID = d1.ID;
                mutate.route[randomPos].X = d1.X;
                mutate.route[randomPos].Y = d1.Y;
            }
        }
    }
}
