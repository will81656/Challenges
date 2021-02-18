﻿using Chall2.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Chall2
{
    class OutingTest
    {
        static void Main(string[] args)
        {
            OutingRepo outingRepo = new OutingRepo();
            List<Outing> outingList = new List<Outing>();

            string response = null;
            while (response != "4")
            {
                Console.Clear();

                Console.WriteLine("What would you like to do? \n" +
                    "1. View all outings \n" +
                    "2. Create new outing \n" +
                    "3. Calculate costs \n" +
                    "4. Exit");
                response = Console.ReadLine();

                if (response == "1")
                {
                    Console.Clear();

                    if (outingList.Count == 0)
                    {
                        Console.WriteLine("There are currently no events recorded.");
                    }
                    else
                    {
                        foreach (Outing outing in outingList)
                        {
                            Console.WriteLine(outing);
                        }
                    }
                    Console.Read();
                }
                else if (response == "2")
                {
                    Console.Clear();

                    Console.WriteLine($"Create which new outing type? :\n" +
                        $"1. Amusement Park\n" +
                        $"2. Bowling\n" +
                        $"3. Concert\n" +
                        $"4. Golf");
                    string input = Console.ReadLine();
                    EventType newEvent = EventType.AmusementPark;
                    string typeHeader = null;
                    switch (input)
                    {
                        case "1":
                            newEvent = EventType.AmusementPark;
                            typeHeader = "Amusement Park Event";
                            break;
                        case "2":
                            newEvent = EventType.Bowling;
                            typeHeader = "Bowling Event";
                            break;
                        case "3":
                            newEvent = EventType.Concert;
                            typeHeader = "Concert Event";
                            break;
                        case "4":
                            newEvent = EventType.Golf;
                            typeHeader = "Golf Event";
                            break;
                        default:
                            Console.WriteLine("Invalid input");
                            break;
                    }
                    Console.Clear();
                    Console.WriteLine(typeHeader);
                    Console.Write("Enter the amount of attendees: ");
                    int attendance = Int32.Parse(Console.ReadLine());

                    Console.Write("Enter the Month, Day, and Year of the event: " +
                        $"\n Month (MM): ");
                    int newMonth = Int32.Parse(Console.ReadLine());
                    Console.Write(" Day (DD): ");
                    int newDay = Int32.Parse(Console.ReadLine());
                    Console.Write(" Year (YYYY): ");
                    int newYear = Int32.Parse(Console.ReadLine());
                    DateTime date = new DateTime(newYear, newMonth, newDay);

                    Console.Write("Enter the cost per person for the event: $");
                    decimal individualCost = Decimal.Parse(Console.ReadLine());

                    Console.Write("Enter the total cost for the event: $");
                    decimal totalEventCost = Decimal.Parse(Console.ReadLine());
                    
                    Console.WriteLine("New Outing Added");

                    outingRepo.AddOuting(newEvent, attendance, date, individualCost, totalEventCost);

                    Console.Read();
                }
                else if (response == "3")
                {
                    Console.Clear();
                    Console.WriteLine($"What calculations would you like to do? \n" +
                        $"1. Total cost for all outings \n" +
                        $"2. Total cost for outings of a specific type");

                    string calcResponse = Console.ReadLine();
                    if (calcResponse == "1")
                    {
                        Console.Clear();
                        Console.WriteLine($"Total cost for all outings: ${outingRepo.TotalCost()}");
                    }
                    else if (calcResponse == "2")
                    {
                        Console.Clear();
                        Console.WriteLine($"Enter the outing type would you like to sort by:" +
                            $"\n1. Amusement Park" +
                            $"\n2. Bowling" +
                            $"\n3. Concert" +
                            $"\n4. Golf");
                        var typeNum = Int32.Parse(Console.ReadLine());
                        EventType type = EventType.AmusementPark;
                        switch (typeNum)
                        {
                            case 1:
                                type = EventType.AmusementPark;
                                break;
                            case 2:
                                type = EventType.Bowling;
                                break;
                            case 3:
                                type = EventType.Concert;
                                break;
                            case 4:
                                type = EventType.Golf;
                                break;
                            default:
                                Console.WriteLine("Error");
                                break;
                        }
                        Console.Clear();
                        Console.WriteLine($"Total cost for {type}: ${outingRepo.GetCostByType(type)}");
                    }
                    Console.Read();
                }
                else if (response == "4")
                {
                    break;
                }
            }
        }
    }
}
