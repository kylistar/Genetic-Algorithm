using System;
using System.IO;
using System.Collections.Generic;

namespace Labb_3_AI
{
    class Initialize
    {
        public Initialize(List<Destination> destinations)
        {
            ReadFromFile(destinations);
        }
        public void ReadFromFile(List<Destination> destinations)
        {
            StreamReader reader = new StreamReader("C:/Users/Emil/Dropbox/Labb 3 AI/Assignment 3 berlin52.tsp");
            string line;
            string[] parameters, intParameter1, intParameter2;
            line = reader.ReadLine();
            while (line != "EOF")
            {
                parameters = line.Split();
                intParameter1 = parameters[1].Split('.');
                intParameter2 = parameters[2].Split('.');

                destinations.Add(new Destination(
                    Convert.ToInt32(parameters[0]),
                    Convert.ToInt32(intParameter1[0]),
                    Convert.ToInt32(intParameter2[0])
                    ));
                line = reader.ReadLine();
            }
        }
    }
}
