using System;

namespace textAdventure
{
    class Program
    {
        private static string move;
        private static int guardQuarterKey = 1;
        private static int guardQuarterKeyUsed = 0;

        static void controls()
        {
            Console.WriteLine("\n\nCommands: FORWARD[W] LEFT[A] BACK[S] RIGHT[D] \n");
            Console.Write("Input: ");
            move = Console.ReadLine();
            move = move.ToUpper();
        }
        static void Main(string[] args)
        {
            Console.Write("Enter your name: ");
            string userName = Console.ReadLine();

            Console.WriteLine($"Welcome {userName}, we are about to embark on an adventure together.");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();
            Entrance();
        }
        static void Entrance()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"\n\nYou stand in front of a large wooden gate.\nIt is surrounded by water on both sides.\nBehind you is the boat you arrived on. \n\nEnter which direction you wish to go in.");
                controls();

                if (move == "LEFT" || move == "A" || move == "RIGHT" || move == "D" || move == "BACK" || move == "S")
                {
                    Console.WriteLine("You cannot go there.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                }
                else if (move == "FORWARD" || move == "W")
                {
                    Console.WriteLine("You open the gate.");
                    Hallway();
                }

            }
        }
        static void Hallway()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You enter a large hallway. The light is dim and the pillars and furniture is covered in dust and spiderwebs.\nThis place must have been abandoned a long time ago.\nYou see two doors a few feet apart at the end of the hallway.");
                Console.WriteLine("\n\nWhich door do you wish to inspect?");
                controls();

                if (move == "FORWARD" || move == "W")
                {
                    Console.WriteLine("You bonk your head into a wall.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                }
                else if (move == "RIGHT" || move == "D")
                {
                    if (guardQuarterKey == 0)
                    {
                        Console.WriteLine("The door is locked, you try the key you found in the Guards Quarter.\nThe door is unlocked, you step inside.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        HallwayDoorRight();
                        guardQuarterKeyUsed = 1;
                    }
                    else if (guardQuarterKeyUsed == 1)
                    {
                        Console.WriteLine("You open the door.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        HallwayDoorRight();
                    }
                    else
                    {
                        Console.WriteLine("The door is locked.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }
                }
                else if (move == "BACK" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You decide against exploring this place and go back out.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    Entrance();
                }
                else if (move == "LEFT" || move == "A")
                {
                    Console.WriteLine("The door creaks open.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    GuardsQuarter();
                }
            }
        }

        static void GuardsQuarter()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("As you step into the room, you see what looks like a small guards quarters. \nThere are weapons along the side of the right wall, and an empty fireplace straight ahead.\nTo the left you see a wooden table with something shiny on top of it.");
                controls();

                if (move == "FORWARD" || move == "W")
                {
                    Console.WriteLine("There is nothing of interest in the fireplace.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                }
                else if (move == "RIGHT" || move == "D")
                {
                    Console.WriteLine("You glance over the weaponry on the wall, they have degraded beyond repair.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                }
                else if (move == "BACK" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You leave the guards quarters and return to the hallway.");
                    Console.WriteLine("Press any key to continue.");
                    Console.ReadLine();
                    break;
                }
                else if (move == "LEFT" || move == "A")
                {
                    if (guardQuarterKey == 1)
                    {
                        Console.WriteLine("The shiny object on the table is a small silver key, you pocket it.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                        guardQuarterKey--;
                    }
                    else if (guardQuarterKey == 0)
                    {
                        Console.WriteLine("There is nothing else of value on the table.");
                        Console.WriteLine("Press any key to continue.");
                        Console.ReadLine();
                    }
                }
            }
        }

        static void HallwayDoorRight()
        {
            while (true)
            {
            Console.WriteLine("Test");
            Console.WriteLine("Press any key to continue.");
            Console.ReadLine();

            }
        }

    }
}
