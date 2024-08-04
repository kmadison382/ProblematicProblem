using System;
using System.Collections.Generic;
using System.Net;
using System.Runtime.InteropServices;
using System.Threading;

namespace ProblematicProblem
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.Write("Hello, welcome to the random activity generator! \nWould you like to generate a random activity? Yes/No: ");
            cont = Console.ReadLine().ToLower() == "yes";
            if (cont)
            {
                Console.WriteLine();
                Console.Write("We are going to need your information first! What is your name? ");
                string userName = Console.ReadLine();
                Console.WriteLine();
                Console.Write("What is your age? ");
                var age = Console.ReadLine();
                while (!int.TryParse(age, out userAge))
                {
                    Console.WriteLine("Please enter a valid number.");
                    age = Console.ReadLine();
                }
                Console.WriteLine();
                Console.Write("Would you like to see the current list of activities? Sure/No thanks: ");
                bool seeList = Console.ReadLine().ToLower() == "sure";
                if (seeList)
                {
                    foreach (string activity in activities)
                    {
                        Console.Write($"{activity}, ");
                        Thread.Sleep(250);
                    }
                    Console.WriteLine();
                    Console.Write("Would you like to add any activities before we generate one? Yes/No: ");
                    bool addToList = Console.ReadLine().ToLower() == "yes";
                    Console.WriteLine();
                    while (addToList)
                    {
                        Console.Write("What would you like to add? ");
                        string userAddition = Console.ReadLine();
                        activities.Add(userAddition);
                        foreach (string activity in activities)
                        {
                            Console.Write($"{activity} ");
                            Thread.Sleep(250);
                        }
                        Console.WriteLine();
                        Console.WriteLine("Would you like to add more? Yes/No: ");
                        addToList = Console.ReadLine().ToLower() == "yes";
                    }
                }
                while (cont)
                {
                    Console.Write("Connecting to the database");
                    for (int i = 0; i < 10; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    Console.Write("Choosing your random activity");
                    for (int i = 0; i < 9; i++)
                    {
                        Console.Write(". ");
                        Thread.Sleep(500);
                    }
                    Console.WriteLine();
                    int randomNumber = rng.Next(activities.Count - 1);
                    string randomActivity = activities[randomNumber];
                    if (userAge < 21 && randomActivity == "Wine Tasting")
                    {
                        Console.WriteLine($"Oh no! Looks like you are too young to do {randomActivity}");
                        Console.WriteLine("Let's pick something else!");
                        activities.Remove(randomActivity);
                        randomNumber = rng.Next(activities.Count);
                        randomActivity = activities[randomNumber];
                    }
                    Console.Write($"Ah, got it! {userName}, your random activity is: {randomActivity}! Is this ok or do you want to grab another activity? Keep/Redo: ");
                    Console.WriteLine();
                    cont = Console.ReadLine().ToLower() == "redo";
                }
            }
        }
        static bool cont = true;
        static int userAge;
        static Random rng = new();
        static List<string> activities = new() { "Movies", "Paintball", "Bowling", "Lazer Tag", "LAN Party", "Hiking", "Axe Throwing", "Wine Tasting" };
    }
}