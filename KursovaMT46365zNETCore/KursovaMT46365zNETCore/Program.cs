using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace KursovaMT46365zNETCore
{
    class Program
    {
        static void Main(string[] args)
        {
            string entry = "";
            //string? entry = "";
            //string[] arrSplitter = { };
            //string[] objName = { };
            string[] arrSplitter = new string[] { };
            string[] objName = new string[] { };
            //string[]? arrSplitter = new string[] { };
            //string[]? objName = new string[0];
            int galaxyCounter = 0;
            int starCounter = 0;
            int planetCounter = 0;
            int moonCounter = 0;
            int moonChecker = 1;

            List<Galaxy> galaxyList = new List<Galaxy>();
            List<Star> starList = new List<Star>();
            List<Planet> planetList = new List<Planet>();
            List<Moon> moonList = new List<Moon>();

            while (entry != "exit")
            {
                entry = Console.ReadLine();
                //Console.WriteLine(entry);
                //Console.WriteLine(objName);
                objName = entry.Split('[', ']');
                arrSplitter = entry.Split(' ');

                if (arrSplitter[0] == "add")
                {
                    if (arrSplitter[1] == "galaxy")
                    {
                        string arrName;
                        string arrType;
                        float arrAge;
                        string ageAll;
                        char ageCharOnly;

                        arrName = objName[1];
                        arrType = arrSplitter[arrSplitter.Length - 2];
                        ageAll = arrSplitter[arrSplitter.Length - 1];
                        ageCharOnly = ageAll[ageAll.Length - 1];
                        ageAll = ageAll.Remove(ageAll.Length - 1);
                        arrAge = float.Parse(ageAll);

                        galaxyCounter++;

                        Galaxy g1 = new Galaxy(arrName, arrType, arrAge, ageCharOnly);

                        galaxyList.Add(new Galaxy { Name = g1.Name, Type = g1.Type, Age = g1.Age, AgeChar = g1.AgeChar });

                        /*foreach(Galaxy gal in galaxyList)
                        {
                            Console.WriteLine($"{gal.Name}, {gal.Type}, {gal.Age}");
                        }*/

                        // add galaxy [Milky way] elliptical 12.2
                    }
                    if (arrSplitter[1] == "star")
                    {
                        string parentGalaxy;
                        string arrName;
                        float arrMass;
                        float arrSize;
                        int arrTemp;
                        float arrLuminosity;
                        string starClassCalculator;

                        parentGalaxy = objName[1];
                        arrName = objName[3];
                        arrMass = float.Parse(arrSplitter[arrSplitter.Length - 4]);
                        arrSize = float.Parse(arrSplitter[arrSplitter.Length - 3]);
                        arrSize /= 2;
                        arrTemp = int.Parse(arrSplitter[arrSplitter.Length - 2]);
                        arrLuminosity = float.Parse(arrSplitter[arrSplitter.Length - 1]);

                        starCounter++;

                        Star s1 = new Star(arrName, arrMass, arrSize, arrTemp, arrLuminosity);

                        starClassCalculator = s1.classCalculator();

                        starList.Add(new Star { Name = s1.Name, Mass = s1.Mass, Size = s1.Size, Temp = s1.Temp, Luminosity = s1.Luminosity, ParentGalaxy = parentGalaxy, StarClassCalculator = starClassCalculator });

                        // add star [Milky way] [Sun] 0.99 0.99 5778 1.00
                    }
                    if (arrSplitter[1] == "planet")
                    {
                        string parentStar;
                        string arrName;
                        string arrType;
                        string arrSupportLife;

                        parentStar = objName[1];
                        arrName = objName[3];
                        arrType = arrSplitter[arrSplitter.Length - 2];
                        arrSupportLife = arrSplitter[arrSplitter.Length - 1];

                        planetCounter++;

                        Planet p1 = new Planet(arrName, arrType, arrSupportLife);

                        planetList.Add(new Planet { Name = p1.Name, Type = p1.Type, SupportLife = p1.SupportLife, ParentStar = parentStar });

                        // add planet [Sun] [Earth] terrestrial yes
                    }
                    if (arrSplitter[1] == "moon")
                    {
                        string parentPlanet;
                        string arrName;

                        parentPlanet = objName[1];
                        arrName = objName[3];

                        moonCounter++;

                        Moon m1 = new Moon(arrName);

                        moonList.Add(new Moon { Name = m1.Name, ParentPlanet = parentPlanet });

                        // add moon [Earth] [Moon]
                    }

                }
                else if (arrSplitter[0] == "print")
                {
                    foreach (Galaxy gal in galaxyList)
                    {
                        if (objName[1] == gal.Name)
                        {
                            Console.WriteLine($"--- Data for {gal.Name} galaxy --- \nType: {gal.Type} \nAge: {gal.Age}{gal.AgeChar} \nStars:");

                            foreach (Star sta in starList)
                            {
                                if (gal.Name == sta.ParentGalaxy)
                                {
                                    Console.WriteLine($" Name: {sta.Name} \n Class: {sta.StarClassCalculator} ({sta.Mass}, {sta.Size}, {sta.Temp}, {sta.Luminosity}) \n Planets:");

                                    foreach (Planet pla in planetList)
                                    {
                                        if (sta.Name == pla.ParentStar)
                                        {
                                            Console.WriteLine($"   Name: {pla.Name} \n   Type: {pla.Type} \n   Support life: {pla.SupportLife} \n   Moons:");

                                            foreach (Moon moo in moonList)
                                            {
                                                if (pla.Name == moo.ParentPlanet)
                                                {
                                                    Console.WriteLine($"     {moo.Name}");
                                                    moonChecker = 0;
                                                }
                                                else
                                                {
                                                    if (moonChecker == 1)
                                                    {
                                                        Console.WriteLine($"     There are no moons linked with {pla.Name} planet!");
                                                    }
                                                    moonChecker = 0;
                                                }
                                            }
                                            moonChecker = 1;
                                        }
                                    }
                                }

                            }
                            Console.WriteLine($"--- End of data for {gal.Name} galaxy ---");
                        }
                        else { Console.WriteLine("There is no such a galaxy in the database"); }
                    }
                    // print [Milky way]
                }
                else if (arrSplitter[0] == "stats")
                {
                    Console.WriteLine("--- Stats ---");
                    Console.WriteLine($"Galaxies: {galaxyCounter} \nStars: {starCounter} \nPlanets: {planetCounter} \nMoons: {moonCounter}");
                    Console.WriteLine("--- End of stats ---");
                }
                else if (arrSplitter[0] == "list")
                {
                    if (arrSplitter[1] == "galaxies")
                    {
                        Console.WriteLine("--- List of all researched galaxies ---");
                        foreach (Galaxy gal in galaxyList)
                        {
                            Console.WriteLine(gal.Name);
                        }
                        Console.WriteLine("--- End of galaxies list ---");
                    }
                    if (arrSplitter[1] == "stars")
                    {
                        string listStringContainer = "";
                        Console.WriteLine("--- List of all researched stars ---");
                        foreach (Star sta in starList)
                        {
                            listStringContainer += sta.Name + ", ";
                        }
                        Console.WriteLine(listStringContainer.Remove(listStringContainer.Length - 2));
                        Console.WriteLine("--- End of stars list ---");
                    }
                    if (arrSplitter[1] == "planets")
                    {
                        string listStringContainer = "";
                        Console.WriteLine("--- List of all researched planets ---");
                        foreach (Planet pla in planetList)
                        {
                            listStringContainer += pla.Name + ", ";
                        }
                        Console.WriteLine(listStringContainer.Remove(listStringContainer.Length - 2));
                        Console.WriteLine("--- End of planets list ---");
                    }
                    if (arrSplitter[1] == "moons")
                    {
                        string listStringContainer = "";
                        Console.WriteLine("--- List of all researched moons ---");
                        foreach (Moon moo in moonList)
                        {
                            listStringContainer += moo.Name + ", ";
                        }
                        Console.WriteLine(listStringContainer.Remove(listStringContainer.Length - 2));
                        Console.WriteLine("--- End of moons list ---");
                    }
                }
                else if (entry == "exit")
                {
                    entry = "exit";
                }
                else
                {
                    Console.WriteLine("Wrongly put commands!");
                }
            }
        }
    }
}