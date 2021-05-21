using System;
using System.Collections.Generic;
using System.Text;
using textAdventure;
using backpack;
namespace BattleSystem
{
    public enum EnemyType
    {
        Skeleton,
        Lich
    }
    public class Player
    {
        public Player(string name)
        {
            this.name = name; //name är parametern. this.name är objektets namn. "this" refererar till objektet som constructorn skapar.
            HP = 20;
            Def = 2;
            Atk = 5;
            backpack = new Backpack();
            
        }
        public Backpack backpack;
        public string name;
        public int HP { get; set; }  //hp20, def2, atk5
        public int Def { get; set; }
        public int Atk { get; set; }
    }

    public class Enemy
    {
        public Enemy(EnemyType enemyType)
        {
            this.enemyType = enemyType;
            HP = 10;
            Def = 2;
            Atk = 5;
        }
        public EnemyType enemyType {get; set;}
        public int HP { get; set; } //hp10, def2, atk5
        public int Def { get; set; }
        public int Atk { get; set; }
    }
    public class Lich
    {
        public Lich()
        {
            HP = 30;
            Def = 3;
            Atk = 7;
        }
        public int HP { get; set; } //hp30, def3, atk7
        public int Def { get; set; }
        public int Atk { get; set; }
    }
    public class CombatSystem
    {
        public static void Combat(Player player, Enemy enemy)
        {
            string fightMove;
            while (player.HP > 0 && enemy.HP > 0)
            {
                Console.WriteLine($"\n\n{player.name} stats:" +
                                  $" HP: {player.HP} | ATK: {player.Atk} | DEF: {player.Def}\n\n" +
                                  $"{enemy.enemyType.ToString()} stats:" +
                                  $" HP: {enemy.HP} | ATK: {enemy.Atk} | DEF: {enemy.Def}\n\n" +
                                  $"Commands:> FIGHT[F] BACKPACK[B] [EXIT]\n");
                Console.Write("Input:> ");
                fightMove = Console.ReadLine().ToUpper();
                if (fightMove == "BACKPACK" || fightMove == "B")
                {
                    player.backpack.ShowBackpack();
                }
                if (fightMove == "EXIT")
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
                Console.Clear();
                while (!(fightMove == "FIGHT" || fightMove == "F" || fightMove == "BACKPACK" || fightMove == "B" || fightMove == "EXIT"))
                {
                    Console.Clear();
                    Console.WriteLine("Invalid input!");
                    Console.WriteLine($"\n\n{player.name} stats:" +
                                      $" HP: {player.HP} | ATK: {player.Atk} | DEF: {player.Def}\n\n" +
                                      $"{enemy.enemyType.ToString()} stats:" +
                                      $" HP: {enemy.HP} | ATK: {enemy.Atk} | DEF: {enemy.Def}\n\n" +
                                      $"Commands:> FIGHT[F] BACKPACK[B] [EXIT]\n");
                    Console.Write("Input:> ");
                    fightMove = Console.ReadLine().ToUpper();
                }
                if (fightMove == "FIGHT" || fightMove == "F")
                {
                    PlayerAccuracy(player, enemy);
                }
                else if (fightMove == "BACKPACK" || fightMove == "B")
                {
                    player.backpack.ShowBackpack();
                }
                if (fightMove == "EXIT")
                {
                    Console.Clear();
                    Console.WriteLine($"Are you sure you want to stop playing, {player.name}? There is no save function. Sorry.");
                    Console.Write("[Y]ES/[N]O:> ");
                    string decide = Console.ReadLine().ToUpper();
                    if (decide == "YES" || decide == "Y")
                    {
                        Console.Clear();
                        Console.WriteLine($"Thank you for playing!");
                        Console.WriteLine("Press Enter to exit.");
                        Console.ReadLine();
                        Environment.Exit(-1);
                    }
                    else
                    {
                        Console.Clear();
                        Console.WriteLine("Lets resume this adventure.");
                        Console.WriteLine("Press Enter to continue.");
                        Console.ReadLine();
                    }
                }
                if (enemy.HP <= 0)
                {
                    Console.Clear();
                    Console.WriteLine($"As {player.name} lands a final blow, the {enemy.enemyType.ToString()} falls apart.\n\n" +
                                      $"You stand victorious!\n");
                    Console.WriteLine("Press Enter to continue.");
                    Console.ReadLine();
                    break;
                }
                EnemyAccuracy(player, enemy);
                if (player.HP <=0)
                {
                    Console.Clear();
                    Console.WriteLine($"The {enemy.enemyType.ToString()} emanates an ominous aura as it suddenly moves faster.\n" +
                                      $"You couldn't see what hit you as your vision fades to black. This is how your adventure ends.\n\n" +
                                      $"GAME OVER!\n");
                    Console.WriteLine("Press Enter to exit.");
                    Console.ReadLine();
                    Environment.Exit(-1);
                }
            }
        }
        static void PlayerAccuracy(Player player, Enemy enemy)
        {
            Random rand = new Random();
            int playerAccuracy = Convert.ToInt32(rand.Next(1, 100));
            int DamageToEnemy;
            int DamageToPlayer;
            Console.Write($"{player.name}:> ");

                if (playerAccuracy == 1)
                {
                    Console.WriteLine($"You somehow manage to throw yourself off balance and smash your face into the wall!\n" +
                                      $"you take {DamageToPlayer = player.Atk + 3} damage.");
                    player.HP = player.HP - DamageToPlayer;
                }
                else if (playerAccuracy > 1 && playerAccuracy <= 20)
                {
                    Console.WriteLine("You violently cut the air!");
                }
                else if (playerAccuracy > 20 && playerAccuracy <= 40)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} raises its guard! You deal {DamageToEnemy = player.Atk - enemy.Def - 2} damage.");
                    enemy.HP = enemy.HP - DamageToEnemy;
                }
                else if (playerAccuracy > 40 && playerAccuracy <= 55)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} swiftly steps to the side and dodges the attack!");
                }
                else if (playerAccuracy > 55 && playerAccuracy <= 99)
                {
                    Console.WriteLine($"You deal {DamageToEnemy = player.Atk - enemy.Def} damage!");
                    enemy.HP = enemy.HP - DamageToEnemy;
                }
                else
                {
                    Console.WriteLine($"Your aim is true and you hit a weakpoint on the {enemy.enemyType.ToString()}! " +
                                      $"You deal {DamageToEnemy = player.Atk * 2 + 3 - enemy.Def} critical damage!");
                    enemy.HP = enemy.HP - DamageToEnemy;
                }
        }
        static void EnemyAccuracy(Player player, Enemy enemy)
        {
            Random rand = new Random();
            int enemyAccuracy = Convert.ToInt32(rand.Next(1, 100));
            int DamageToEnemy;
            int DamageToPlayer;
            Console.Write($"{enemy.enemyType.ToString()}:> ");
            if (enemyAccuracy == 1)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} overshoots its swing, throws itself off balance and smashes its skull into the wall!\n" +
                                      $"The {enemy.enemyType.ToString()} takes {DamageToEnemy = enemy.Atk + 3} damage.");
                    enemy.HP = enemy.HP - DamageToEnemy;
                }
                else if (enemyAccuracy > 1 && enemyAccuracy <= 30)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} misses!");
                }
                else if (enemyAccuracy > 30 && enemyAccuracy <= 50)
                {
                    Console.WriteLine($"You raise your guard and deftly block the attack with your shield! You take {DamageToPlayer = enemy.Atk - player.Def - 2} damage.");
                    player.HP = player.HP - DamageToPlayer;
                }
                else if (enemyAccuracy > 50 && enemyAccuracy <= 60)
                {
                    Console.WriteLine("You quickly react to the incoming swing and dodge the attack!");
                }
                else if (enemyAccuracy > 60 && enemyAccuracy <= 99)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} deals {DamageToPlayer = enemy.Atk - player.Def} damage.");
                    player.HP = player.HP - DamageToPlayer;
                }
                else
                {
                    Console.WriteLine($"The fearsome mass of bones suddenly move with incredible speed and steps past your guard.\n" +
                                      $"The blow hits a weak point! You take {DamageToPlayer = enemy.Atk * 2 + 3 - player.Def} critical damage!");
                    player.HP = player.HP - DamageToPlayer;
                }
        }
        //static void BossAccuracy()
        //{
        //    Random rand = new Random();
        //    int BossAccuracy = Convert.ToInt32(rand.Next(1, 100));
        //    int DamageToBoss;
        //    int DamageToPlayer;
        //    while (BossHP > 0 || player.HP > 0)
        //    {
        //        if (BossAccuracy == 1)
        //        {
        //            Console.WriteLine($"The Lich entangles itself in its long robes, slips and hits itself in the face with its staff!\n" +
        //                $"The Lich takes {DamageToBoss = BossAtk + 2} damage.");
        //            BossHP = BossHP - DamageToBoss;
        //        }
        //        else if (BossAccuracy > 1 && BossAccuracy <= 25)
        //        {
        //            Console.WriteLine("The Lich misses!");
        //        }
        //        else if (BossAccuracy > 25 && BossAccuracy <= 50)
        //        {
        //            Console.WriteLine($"You raise your guard and block the attack with your shield! You take {DamageToPlayer = BossAtk - player.Def - 2} damage.");
        //            player.HP = player.HP - DamageToPlayer;
        //        }
        //        else if (BossAccuracy > 50 && BossAccuracy <= 65)
        //        {
        //            Console.WriteLine("You quickly react to the incoming swing and dodge the attack!");
        //        }
        //        else if (BossAccuracy > 65 && BossAccuracy <= 99)
        //        {
        //            Console.WriteLine($"The Lich deals {DamageToPlayer = BossAtk - player.Def} damage.");
        //            player.HP = player.HP - DamageToPlayer;
        //        }
        //        else
        //        {
        //            Console.WriteLine($"You hear the Lich utter what you assume is a curse. The staff in its hands starts glowing in an eerie red light!\n" +
        //                $"The staff finds a weak point in your armour. You take {DamageToPlayer = BossAtk * 2 + 2 - player.Def} critical damage!");
        //            player.HP = player.HP - DamageToPlayer;
        //        }
        //    }
        //}
    }
}

//* ACCURACY: 1-100, =1 fumble || >2 && <=25 miss || >25 && <=50 block || >50 && <=65 dodge || >65  && <=99 hit || =100 crit

//if Attack
//hit     = (>65  && <=99)       X enemy/player damage minus X enemy/player defense
//miss    = (>2 && <=25)         0 damage
//dodge   = (>50 && <=65)        0 damage
//block   = (>25 && <=50)        X enemy/player damage minus X enemy/player block
//crit    = (=100) (X to X *2)   enemy/player damage minus X enemy/player defense
//fumble  = (=1)                 X self damage minus X self defense*/