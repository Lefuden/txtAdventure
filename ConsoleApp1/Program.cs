using BattleSystem;
using System;

namespace textAdventure
{
    public class Program
    {
        public static string move;
        public static int guardQuarterKey = 1;
        public static int guardQuarterKeyUsed = 0;
        public static int hallOfTorchesKey = 1;
        public static int hallOfTorchesKeyUsed = 0;
        public static int treasuryKey = 1;
        public static int treasuryKeyUsed = 0;
        public static Player player;

        public static void controls()
        {
            Console.WriteLine($"\n\nCommands: NORTH[N] WEST[W] SOUTH[S] EAST[E] FIGHT[F] BACKPACK[B]\nPlayer: {player.name}\nCurrent HP: {player.HP} / 20");
            Console.Write("Input:> ");
            move = Console.ReadLine();
            move = move.ToUpper();
        }
        //public static void fightControls(Enemy enemy)
        //{
        //    Console.WriteLine($"\n\nCommands: FIGHT[F] BACKPACK[B] RETREAT[R]\nPlayer: {player.name}\nCurrent HP: {player.HP} / 20\n" +
        //                      $"Enemy HP: {enemy.HP} /??");
        //    Console.Write("Input:> ");
        //    move = Console.ReadLine();
        //    move = move.ToUpper();
        //}

        static void Main(string[] args)
        {
            Console.WriteLine(" _______   _______ ___ ______ _   _ _____ _   _ _____ _   _______ _____ ");
            Console.WriteLine("|_   _\\ \\ / /_   _/ _ \\|  _  \\ | | |  ___| \\ | |_   _| | | | ___ \\  ___|");
            Console.WriteLine("  | |  \\ V /  | |/ /_\\ \\ | | | | | | |__ |  \\| | | | | | | | |_/ / |__  ");
            Console.WriteLine("  | |  /   \\  | ||  _  | | | | | | |  __|| . ` | | | | | | |    /|  __| ");
            Console.WriteLine("  | | / /^\\ \\ | || | | | |/ /\\ \\_/ / |___| |\\  | | | | |_| | |\\ \\| |___ ");
            Console.WriteLine("  \\_/ \\/   \\/ \\_/\\_| |_/___/  \\___/\\____/\\_| \\_/ \\_/  \\___/\\_| \\_\\____/ \n\n\n");
            Console.Write("Enter your name:> ");
            player = new Player(Console.ReadLine());

            Console.WriteLine($"Welcome {player.name}, we are about to embark on an adventure together.");
            Console.WriteLine("Press Enter to continue.");
            Console.ReadLine();
            Entrance();
        }
        static void Entrance()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"You stand in front of a large wooden gate.\nIt is surrounded by water on both sides.\nBehind you is the boat you arrived on.");
                controls();

                if (move == "WEST" || move == "W" || move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("You gaze out over the dark, foreboding water. You cannot hear any sounds of animals nor wind.\n" +
                        "Weird -you think to yourself- I could hear the screeching seagulls up until I set foot on this island.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }

                else if (move == "BACKPACK" || move == "B")
                {
                    Console.Clear();
                    Console.WriteLine("You open your backpack.");
                    player.backpack.ShowBackpack();
                    Console.WriteLine("Would you like to use an item?");
                    Selection(Console.ReadLine());
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("You stand in front of a big, black gate, thinking back to the previous night in the Tavern.\nYou know why you are here.\n\n" +
                                      "The stories about a cursed fort on a small island, and the people sailing there to investigate never to return.\n" +
                                      "The large sum of gold that will be yours once you've successfully investigated this godforsaken place.\n" +
                                      "Who knows what sort of riches you'll find inside?\n\n" +
                                      "You muster your courage and steel yourself for whatever is to come.\n\n" +
                                      "You open the gate and step inside.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    Hallway();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You turn south to your boat, do you really wish to abandon this adventure and return home to safety?");
                    Console.Write("[Y]ES / [N]O:> ");
                    string decide = Console.ReadLine().ToUpper();
                    if (decide == "YES" || decide == "Y")
                    {
                        Console.Clear();
                        Console.WriteLine("You thought being an adventurer was what you wanted to be, but a sudden realisation convinces you\n" +
                                          "that your real calling is sheep herding. You step on to the boat and raise the sail.\n\nGAME OVER!");
                        Console.WriteLine("Press Enter to exit.");
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("You decide against leaving. You shake your head as to say: I've come this far, there's no point in turning back now!");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        Entrance();
                    }
                }

            }
        }
        static void Hallway() //NEED G-KEY
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You enter a large hallway. The light is dim and the pillars and broken furniture is covered in dust and spiderwebs.\n" +
                                  "The air is cold and feels heavy, like before a thunderstorm.\n" +
                                  "This place must have been abandoned a long time ago.\nYou see two doors a few feet apart at the end of the hallway.");
                controls();

                if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("A lone torch fitted to a sconce in between the two doors barely lights up the area enough for you to not stumble blindly.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    if (guardQuarterKey == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You try the key you found in the Guards Quarter.\nWith a gentle click the door is unlocked. You step inside.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SouthWingStairwell();
                        guardQuarterKeyUsed = 1;
                    }
                    else if (guardQuarterKeyUsed == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You open the door.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SouthWingStairwell();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The door is locked. Perhaps there's a key somewhere.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You decide against exploring this dreary place and go back out.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    Entrance();
                }
                else if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("The door creaks open.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    GuardsQuarter();
                }
            }
        }
        static void GuardsQuarter() //ITEM G-KEY
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("As you step into the room, you see what looks like a small guards quarters. \nThere are weapons along the side of the east wall," +
                                  " and an empty fireplace straight ahead.\nTo the west you see a wooden table with something shiny on top of it.");
                controls();

                if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("There is nothing of interest in the fireplace.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("You glance over the weaponry on the wall, they have degraded beyond repair.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You leave the guards quarters and return to the hallway.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    Hallway();
                }
                else if (move == "WEST" || move == "W")
                {
                    if (guardQuarterKey == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("The shiny object on the table is a small silver key, you pocket it.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        guardQuarterKey--;
                    }
                    else if (guardQuarterKey == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There is nothing else of value on the table.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
            }
        }
        static void SouthWingStairwell() //ADD IN SKELETON COMBAT!
        {
            int Skeleton = 1;
            while (true)
            {
                if (Skeleton == 1)
                {
                    Console.Clear();
                    Console.WriteLine("You find yourself in a short corridor, but before you have time to look around you notice a Skeleton in front of you.\n" +
                                      "The skull cap on its head is rusted. It has an axe and a wooden shield in its hands. " +
                                      "It turns around and looks at you through empty eye sockets.\n" +
                                      "Suddenly it starts moving towards you - Prepare for battle!");
                    controls();
                    CombatSystem.Combat(player, new Enemy(EnemyType.Skeleton));
                }
                else if (Skeleton == 0)
                {
                    Console.Clear();
                    Console.WriteLine("You stand in a short corridor. There are sconces on the walls, lighting up the area. " +
                                      "A moldy red carpet leads between the two doors.\n" +
                                      "The remains of the Skeleton you fought lie in a pile on the floor. There is an eerie calm in this room now.");
                    controls();
                    if (move == "NORTH" || move == "N")
                    {
                        Console.Clear();
                        Console.WriteLine("There is nothing of interest.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                    else if (move == "WEST" || move == "W")
                    {
                        Console.Clear();
                        Console.WriteLine("You inspect the sturdy wall. This is some fine stone masonry.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                    else if (move == "SOUTH" || move == "S")
                    {
                        Console.Clear();
                        Console.WriteLine("You leave the short corridor and enter the hallway.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        Hallway();
                    }
                    else if (move == "EAST" || move == "E")
                    {
                        Console.Clear();
                        Console.WriteLine("You see an open door, leading to a stairwell going up.\nYou ascend.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SouthWingLanding();
                    }
                }

            }
        }
        static void SouthWingLanding()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Having climbed the windy staircase, you arrive in a large square room. This area is a lot more open, there's no need for any lit torches here.\n" +
                                  "You can feel a chill breeze coming in from the north archway, flowing through the room and out the south arch.\nThere are four stone pillars in a square shape, " +
                                  "a few meters apart in the middle of the room.\nThe stairwell is behind you, and there's another door to the east.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("You descend the stairs.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingStairwell();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("You move towards the breeze and step through the archway.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthBrokenBridge();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You decide to explore the south archway.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingBalcony();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("You try the east door, it isn't locked. It creaks open.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingCorridor();
                }
            }
        }
        static void SouthWingBalcony() //ITEM HP POTION
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You arrive on a balcony. The fresh air fill your lungs as you stand there, leaning against the railing for a while.\n" +
                                  "");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingStairwell();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Go to SouthWingLanding.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingLanding();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Pick up item HP Potion.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void SouthBrokenBridge() //ITEM OLD MACE
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter SouthBrokenbridge.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Pick up Old Mace.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingStairwell();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Bridge is broken.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Go to SouthWingLanding.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingLanding();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void SouthWingCorridor()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter SouthWingCorridor.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Go to SouthWingLanding.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingLanding();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Go to SouthWing3WayRoom.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWing3WayRoom();
                }
            }
        }
        static void SouthWing3WayRoom()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter SouthWing3WayRoom.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Return to SouthWingCorridor.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingStairwell();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Go to EastStairwell.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Go to DampCellar.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void DampCellar() //ADD IN SKELETON COMBAT!
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("DampCellar + Skeleton.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Return to SouthWing3WayRoom.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWing3WayRoom();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Enter HallofTorches.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    HallOfTorches();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void HallOfTorches() //TORCH PUZZLE, ITEM P-KEY
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter HallofTorches.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Return to DampCellar.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    DampCellar();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Enter Treasury if puzzle is solved.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    Treasury(); //NEED TO BEAT PUZZLE
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Torch Puzzle.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void Treasury() //ITEM O-KEY, ITEM OAK SHIELD
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter treasury.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Return to HallOfTorches");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    HallOfTorches();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    if (treasuryKey == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Pick up O-KEY");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        treasuryKey--;
                    }
                    else if (treasuryKey == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("There is nothing else of value.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Pick up OAK SHIELD.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void EastStairwell() //NEED P-KEY
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter EastStairwell.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "NORTH" || move == "N")
                {
                    if (hallOfTorchesKey == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You try the key you found in the Hall of Torches.\nWith a gentle click the door is unlocked. You step inside.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SouthWingStairwell();
                        hallOfTorchesKeyUsed = 1;
                    }
                    else if (hallOfTorchesKeyUsed == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You open the door.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SouthWingStairwell();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The door is locked. Perhaps there's a key somewhere.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Go to SouthWing3WayRoom.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWing3WayRoom();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void EastWingLanding()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter EastWingLanding.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Go to NorthStairWell.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    NorthStairwell();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Go to EastStairWell.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    EastStairwell();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Go to EastWingBalcony.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    EastWingBalcony();
                }
            }
        }
        static void EastWingBalcony()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter EastWingBalcony.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Go to EastWingLanding.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    EastWingLanding();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void NorthStairwell() //ADD IN SKELETON COMBAT!
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("NorthStairwell, Skeleton.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Go to NorthWingLanding.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    NorthWingLanding();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Go to EastWingLanding.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    EastWingLanding();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void NorthWingLanding()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter NorthWingLanding.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Go to ExtravagantRoom.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    ExtravagantRoom();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Go to NorthStairwell.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    NorthStairwell();
                }
            }
        }
        static void ExtravagantRoom() //NEED O-KEY
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter ExtravagantRoom.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    if (treasuryKeyUsed == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You try the key you found in the Treasury.\nWith a gentle click the door is unlocked. You step inside.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SouthWingStairwell();
                        treasuryKeyUsed = 1;
                    }
                    else if (treasuryKeyUsed == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You open the door.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SouthWingStairwell();
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("The door is locked. Perhaps there's a key somewhere.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You step out on the broken bridge.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    NorthBrokenBridge();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("You return to the north wing landing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    NorthWingLanding();
                }
            }
        }
        static void NorthBrokenBridge()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter NorthBrokenBridge.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Go To ExtravagantRoom.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    ExtravagantRoom();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void ThroneRoom() //ADD IN BOSSFIGHT!
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter ThroneRoom, initiate Boss Fight.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("Nothing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Go to ExtravagantRoom.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    ExtravagantRoom();
                }
            }
        }
    }
}