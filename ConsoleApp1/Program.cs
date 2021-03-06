using BattleSystem;
using System;
using backpack;

namespace textAdventure
{
    public class Program
    {
        public static string move;
        public static int guardQuarterKey = 1;
        public static int guardQuarterKeyUnlocked = 0;
        public static int hallOfTorchesKey = 1;
        public static int hallOfTorchesKeyUnlocked = 0;
        public static int treasuryKey = 1;
        public static int treasuryKeyUnlocked = 0;
        public static Player player;
        public static int SWBhealthPotion = 1;
        public static int EWBhealthPotion = 1;
        public static int Mace = 1;
        public static int OakShield = 1;
        public static bool southwingskeleton =  true;
        public static bool dampcellarskeleton = true;
        public static bool northstairwellskeleton = true;

        public static void controls()
        {
            Console.WriteLine($"\n\n{player.name} stats:\nHP: {player.HP} | ATK: {player.Atk} | DEF: {player.Def}" +
                $"\nCommands:> NORTH[N] WEST[W] SOUTH[S] EAST[E] FIGHT[F] BACKPACK[B] [EXIT]");
            Console.Write("Input:> ");
            move = Console.ReadLine();
            move = move.ToUpper();
            if (move == "BACKPACK" || move == "B")
            {
                player.backpack.ShowBackpack();
            }
            if (move == "EXIT")
            {
                Console.Clear();
                Console.WriteLine($"Are you sure you want to stop playing, {player.name}? There is no save function. Sorry.");
                Console.Write("[Y]ES/[N]O:> ");
                string decide = Console.ReadLine().ToUpper();
                if (decide == "YES" || decide == "Y")
                {
                    Console.Clear();
                    Console.WriteLine($"Thank you for playing, {player.name}!");
                    Console.WriteLine("Press Enter to exit.");
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
                else
                {
                    Console.Clear();
                    Console.WriteLine($"{player.name} shakes off a moment of weakness and decides to return to the adventure at hand.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }

        }
        static void Main(string[] args)
        {
            Console.WriteLine(" _______   _______ ___ ______ _   _ _____ _   _ _____ _   _______ _____ ");
            Console.WriteLine("|_   _\\ \\ / /_   _/ _ \\|  _  \\ | | |  ___| \\ | |_   _| | | | ___ \\  ___|");
            Console.WriteLine("  | |  \\ V /  | |/ /_\\ \\ | | | | | | |__ |  \\| | | | | | | | |_/ / |__  ");
            Console.WriteLine("  | |  /   \\  | ||  _  | | | | | | |  __|| . ` | | | | | | |    /|  __| ");
            Console.WriteLine("  | | / /^\\ \\ | || | | | |/ /\\ \\_/ / |___| |\\  | | | | |_| | |\\ \\| |___ ");
            Console.WriteLine("  \\_/ \\/   \\/ \\_/\\_| |_/___/  \\___/\\____/\\_| \\_/ \\_/  \\___/\\_| \\_\\____/ \n\n\n");


            
            Console.WriteLine("1. New game");
            Console.WriteLine("2. Exit\n\n");
            Console.Write("Input:> ");
            move = Console.ReadLine();
                if (move == "1")
                {
                    Console.Write("Enter your name:> ");
                    player = new Player(Console.ReadLine());
                    Console.Clear();
                    Console.WriteLine($"This all started in a tavern in a sleepy hamlet, quite a few hours from where you now stand.\n" +
                                      $"After hearing stories of a 'haunted fort' on a remote island, and people never to be seen again,\n" +
                                      $"you -drunkenly- proclaimed that YOU - {player.name}, mighty adventurer - shall free these poor souls\n" +
                                      $"from whatever dangers hiding in this so called 'haunted fort'.\n\n" +
                                      $"And so, your adventure begins.\n");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    Entrance();
                }
                else if (move == "2")
                {
                    Environment.Exit(-1);
                }

        }
        static void Entrance()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine($"You stand in front of a large black gate.\nIt is surrounded by water on both sides.\nBehind you is the boat you arrived on.");
                controls();

                if (move == "WEST" || move == "W" || move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("You gaze out over the dark, foreboding water. You cannot hear any sounds of animals nor wind.\n" +
                                      "Weird -you think to yourself- I could hear the screeching seagulls up until I set foot on this island.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("As you step closer to the black gate, you see it has been reinforced with some form of metal,\nshaped in intricate designs." +
                                      "\nThinking back to the previous night in the Tavern, you know why you are here.\n\n" +
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
                    Console.Write("[Y]ES/[N]O:> ");
                    string decide = Console.ReadLine().ToUpper();
                    if (decide == "YES" || decide == "Y")
                    {
                        Console.Clear();
                        Console.WriteLine("You thought being an adventurer was what you wanted to be, but a sudden realisation convinces you\n" +
                                          "that your real calling is goat herding. \nYou step on to the boat and raise the sail.\n\nGAME OVER!");
                        Console.WriteLine("\nPress Enter to exit.");
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
        static void Hallway()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You enter a large Hallway. The light is dim and the pillars and broken furniture is covered in dust and spiderwebs.\n" +
                                  "The air is cold and feels heavy, like moments before a thunderstorm.\n" +
                                  "This place must have been abandoned a long time ago.\nYou see two doors a few feet apart at the end of the hallway.");
                controls();

                if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("A lone torch fitted to a sconce in between the two doors\nbarely lights up the area enough for you to not stumble blindly.");
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
                        guardQuarterKeyUnlocked = 1;
                    }
                    else if (guardQuarterKeyUnlocked == 1)
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
        static void GuardsQuarter()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("As you step into the room, you see what looks like a small Guards Quarters. \nThere are weapons along the side of the east wall," +
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
                    Console.WriteLine("You glance over the weaponry on the wall, what once probably was a rather impressive display\n" +
                                      "has with time been reduced to worthless trinkets. They have degraded beyond repair.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You leave the Guards Quarters and return to the Hallway.");
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
        static void SouthWingStairwell()
        {

            while (true)
            {
                if (southwingskeleton)
                {
                    Console.Clear();
                    Console.WriteLine("You find yourself in a short corridor, but before you have time to look around you notice a Skeleton in front of you.\n" +
                                      "The skull cap on its head is rusted. It has an axe and a wooden shield in its hands.\n" +
                                      "It turns around and looks at you through empty eye sockets.\n" +
                                      "Suddenly it starts moving towards you - Prepare for battle!");
                    CombatSystem.Combat(player, new Enemy(EnemyType.Skeleton));
                    southwingskeleton = false;
                    controls();
                }
                else if (!southwingskeleton)
                {
                    Console.Clear();
                    Console.WriteLine("You stand in a short corridor. There are sconces on the walls, lighting up the area.\n" +
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
                Console.WriteLine("Having climbed the windy staircase, you arrive in a large square room. This area is a lot more open,\n" +
                                  "there's no need for any lit torches here.\nYou can feel a chill breeze coming in from the north archway,\n" +
                                  "flowing through the room and out the south arch.\nThere are four stone pillars in a square shape, " +
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
                    Console.WriteLine("You try the east door, to your surprise -it isn't locked. It creaks open.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingCorridor();
                }
            }
        }
        static void SouthWingBalcony()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You arrive on a balcony. The fresh air fill your lungs as you stand there, leaning against the railing for a while.\n" +
                                  "Looking around this small space, you don't see much of value.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("You decide to lean over the railing a bit out of curiosity.\n" +
                                      "I could probably survive this fall - you think to yourself.\n" +
                                      "You step away from the railing, shaking your head.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("You turn back and step through the archway.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingLanding();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    if (SWBhealthPotion == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("As you put your hand on the cold stone railing, a part of it comes loose and falls into the water with a splash.\n" +
                                          "You push back with your other hand, and as you re-adjust you notice something in the corner of your eye.\n" +
                                          "There's a glass bottle with a red liquid inside laying on the ground.\n" +
                                          "You pocket it. (It's obviously a healing potion).");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SWBhealthPotion--;
                        player.backpack.backPack.Add(Item.HPpotion);
                    }
                    else if (SWBhealthPotion == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You take another careful look around, in case of other items scattered around.\n" +
                                          "There is nothing else of value.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                    else if (move == "EAST" || move == "E")
                    {
                        Console.Clear();
                        Console.WriteLine("You gaze out over the water, it's quiet. Too quiet. No birds, no fish.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
            }
        }
        static void SouthBrokenBridge()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You stand on what once was a rather impressive stone bridge. Heavy winds hit you from the west.\n" +
                                  "The middle part of the bridge has fallen apart and you see no way of getting to the other side.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("You face the heavy wind, the pressure makes it hard to breathe.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthBrokenBridge();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("Taking a quick look at the fallen bridge, you decide it's not worth risking your life trying to find a way over.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You shiver from the cold heavy winds as you turn back to the South Wing Landing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingLanding();
                }
                else if (move == "EAST" || move == "E")
                {
                    if (Mace == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("The dark towering stone walls of the fort fills you with an ominous feeling.\n" +
                                          "A fallen adventurer is slumped against the wall. The mace in his hand looks like it's made of high quality steel.\n" +
                                          "You carefully take it, trying to not anger any potential angry spirits hanging around.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        Mace--;
                        player.backpack.backPack.Add(Item.SteelMace);
                    }
                    else if (Mace == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("The dark towering stone walls of the fort fills you with an ominous feeling.\n" +
                                          "A fallen adventurer is slumped against the wall.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
            }
        }
        static void SouthWingCorridor()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You find yourself in a short and narrow corridor, a trickle of light emanates from a crack in the wall.\n" +
                                  "The sides are littered with rubble. You spot a door straight ahead.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("You decide to return to the South Wing Landing.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingLanding();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("You glance over the rubble, you find nothing of value.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("You stand in the sliver of light shining through the worn down wall.\n" +
                                      "Somehow you find a moment of respite. You stand tall and stretch for a bit.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("Another unlocked door, you leave the small corridor.");
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
                Console.WriteLine("Another dimly lit room, this area is also full of rubble.\n" +
                                  "There must've been some heavy fighting going on in this part of the fort.\n" +
                                  "There's an archway to the north. You spot a stairwell to the east.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("You return to the small corridor.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    SouthWingStairwell();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("You walk through the archway.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    EastStairwell();
                }
                else if (move == "SOUTH" || move == "S")
                {
                    Console.Clear();
                    Console.WriteLine("The southern wall has partly disintegrated, you can smell the salt of the ocean.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "EAST" || move == "E")
                {
                    Console.Clear();
                    Console.WriteLine("As you descend the stairwell, you feel the air getting colder and humid.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    DampCellar();
                }
            }
        }
        static void DampCellar()
        {
            while (true)
            {
                if (dampcellarskeleton)
                {
                    Console.Clear();
                    Console.WriteLine("As you take the last step of the stairwell and enter the damp cellar, you hear the rattling of bones.\n" +
                                      "A menacing Skeleton soldier stands in your way. It holds a large spiked club in its hands.\n" +
                                      "Before you get a chance to react it charges you. Prepare to fight!");
                    CombatSystem.Combat(player, new Enemy(EnemyType.Skeleton));
                    dampcellarskeleton = false;
                    controls();
                }
                else if (!dampcellarskeleton)
                {
                    Console.Clear();
                    Console.WriteLine("As you return to the damp cellar, you feel like leaving as soon as possible. The smell is horrendous.\n" +
                                      "You quickly dart your eyes around the room, you see nothing that stands out.");
                    controls();
                    if (move == "WEST" || move == "W")
                    {
                        Console.Clear();
                        Console.WriteLine("You ascend the stairwell. You instantly feel better.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SouthWing3WayRoom();
                    }
                    else if (move == "NORTH" || move == "N")
                    {
                        Console.Clear();
                        Console.WriteLine("You could swear you saw something moving in the corner of your eye.\n" +
                                          "The skittering of what you can only assume is rats silently echoes across the damp cellar.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                    else if (move == "SOUTH" || move == "S")
                    {
                        Console.Clear();
                        Console.WriteLine("Through the open door to the south, you see a very brightly lit room, you decide to investigate.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        HallOfTorches();
                    }
                    else if (move == "EAST" || move == "E")
                    {
                        Console.Clear();
                        Console.WriteLine("Pools of knee high water fills the east part of the cellar.\n" +
                                          "Your nose catches a whiff of what can only be described as putrid corpses.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
            }
        }
        static void HallOfTorches() //TORCH PUZZLE, ITEM P-KEY, ADD TEXT
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("You step into a large hall full of sconces along the walls.\n" +
                                  "There's a large, rather impressive reinforced door to the south.\n" +
                                  "You notice four unlit torches next to the door, curious..");
                controls();

                if (move == "WEST" || move == "W")
                {
                    Console.Clear();
                    Console.WriteLine("Looking over at the lit sconces, you appreciate the lack of darkness in this area.");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
                else if (move == "NORTH" || move == "N")
                {
                    Console.Clear();
                    Console.WriteLine("You brace yourself for the disgusting odor, as you return to the damp cellar.");
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
                    Console.WriteLine("Torch Puzzle."); //GAIN P-KEY IF SOLVED
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void Treasury() //ITEM O-KEY, ITEM OAK SHIELD, ADD TEXT
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
                    if (OakShield == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("Get shield.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        OakShield--;
                        player.backpack.backPack.Add(Item.OakShield);
                    }
                    else if (OakShield == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You take another careful look around, in case of other items scattered around.\n" +
                                          "There is nothing else of value.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                    Console.Clear();
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                }
            }
        }
        static void EastStairwell() //ADD TEXT
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
                        hallOfTorchesKeyUnlocked = 1;
                    }
                    else if (hallOfTorchesKeyUnlocked == 1)
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
        static void EastWingLanding() //ADD TEXT
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
        static void EastWingBalcony() //ADD TEXT
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
                if (move == "NORTH" || move == "N")
                {
                    if (EWBhealthPotion == 1)
                    {
                        Console.Clear();
                        Console.WriteLine("You pocket it. (It's obviously a healing potion).");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        EWBhealthPotion--;
                        player.backpack.backPack.Add(Item.HPpotion);
                    }
                    else if (EWBhealthPotion == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You take another careful look around, in case of other items scattered around.\n" +
                                          "There is nothing else of value.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
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
        static void NorthStairwell() //ADD TEXT
        {
            while (true)
            {
                if (northstairwellskeleton)
                {
                    Console.Clear();
                    Console.WriteLine("Prepare for battle!");
                    CombatSystem.Combat(player, new Enemy(EnemyType.Skeleton));
                    northstairwellskeleton = false;
                    controls();
                }
                else if (!northstairwellskeleton)
                {
                    Console.Clear();
                    Console.WriteLine("Room description.");
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
        }
        static void NorthWingLanding() //ADD TEXT
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
        static void ExtravagantRoom() //ADD TEXT
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Enter ExtravagantRoom.");
                controls();

                if (move == "WEST" || move == "W")
                {
                    if (treasuryKeyUnlocked == 0)
                    {
                        Console.Clear();
                        Console.WriteLine("You try the key you found in the Treasury.\nWith a gentle click the door is unlocked. You step inside.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                        SouthWingStairwell();
                        treasuryKeyUnlocked = 1;
                    }
                    else if (treasuryKeyUnlocked == 1)
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
        static void NorthBrokenBridge() //ADD TEXT
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
        static void ThroneRoom() //ADD IN BOSSFIGHT, ADD TEXT
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