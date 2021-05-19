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
            while (player.HP > 0 && enemy.HP > 0)
            {
                PlayerAccuracy(player, enemy);
                Console.WriteLine("Press Enter to continue.");
                Console.ReadLine();
                Program.controls();
                if (enemy.HP <= 0) break;
                EnemyAccuracy(player, enemy);
            }
        }
        static void PlayerAccuracy(Player player, Enemy enemy)
        {
            Random rand = new Random();
            int PlayerAccuracy = Convert.ToInt32(rand.Next(1, 100));
            int DamageToEnemy;
            int DamageToPlayer;

                if (PlayerAccuracy == 1)
                {
                    Console.WriteLine($"You somehow manage to throw yourself off balance and smash your face into the wall!\n" +
                                      $"you take {DamageToPlayer = player.Atk + 2} damage.");
                    player.HP = player.HP - DamageToPlayer;
                }
                else if (PlayerAccuracy > 1 && PlayerAccuracy <= 20)
                {
                    Console.WriteLine("You violently cut the air!");
                }
                else if (PlayerAccuracy > 20 && PlayerAccuracy <= 40)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} raises its guard! You deal {DamageToEnemy = player.Atk - enemy.Def - 2} damage.");
                    enemy.HP = enemy.HP - DamageToEnemy;
                }
                else if (PlayerAccuracy > 40 && PlayerAccuracy <= 55)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} swiftly steps to the side and dodges the attack!");
                }
                else if (PlayerAccuracy > 55 && PlayerAccuracy <= 99)
                {
                    Console.WriteLine($"You deal {DamageToEnemy = player.Atk - enemy.Def} damage!");
                    enemy.HP = enemy.HP - DamageToEnemy;
                }
                else
                {
                    Console.WriteLine($"Your aim is true and you hit a weakpoint on the {enemy.enemyType.ToString()}! " +
                                      $"You deal {DamageToEnemy = player.Atk * 2 + 2 - enemy.Def} critical damage!");
                    enemy.HP = enemy.HP - DamageToEnemy;
                }
        }
        static void EnemyAccuracy(Player player, Enemy enemy)
        {
            Random rand = new Random();
            int EnemyAccuracy = Convert.ToInt32(rand.Next(1, 100));
            int DamageToEnemy;
            int DamageToPlayer;
                if (EnemyAccuracy == 1)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} overshoots its swing, throws itself off balance and smashes its skull into the wall!\n" +
                                      $"The {enemy.enemyType.ToString()} takes {DamageToEnemy = enemy.Atk + 2} damage.");
                    enemy.HP = enemy.HP - DamageToEnemy;
                }
                else if (EnemyAccuracy > 1 && EnemyAccuracy <= 30)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} misses!");
                }
                else if (EnemyAccuracy > 30 && EnemyAccuracy <= 60)
                {
                    Console.WriteLine($"You raise your guard and deftly block the attack with your shield! You take {DamageToPlayer = enemy.Atk - player.Def - 2} damage.");
                    player.HP = player.HP - DamageToPlayer;
                }
                else if (EnemyAccuracy > 60 && EnemyAccuracy <= 70)
                {
                    Console.WriteLine("You quickly react to the incoming swing and dodge the attack!");
                }
                else if (EnemyAccuracy > 70 && EnemyAccuracy <= 99)
                {
                    Console.WriteLine($"The {enemy.enemyType.ToString()} deals {DamageToPlayer = enemy.Atk - player.Def} damage.");
                    player.HP = player.HP - DamageToPlayer;
                }
                else
                {
                    Console.WriteLine($"The fearsome mass of bones suddenly move with incredible speed and steps past your guard.\n" +
                                      $"The blow hits a weak point! You take {DamageToPlayer = enemy.Atk * 2 + 2 - player.Def} critical damage!");
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

///* ACCURACY: 1-100, =1 fumble || >2 && <=25 miss || >25 && <=50 block || >50 && <=65 dodge || >65  && <=99 hit || =100 crit

//if Attack
//hit     = (>65  && <=99)       X enemy/player damage minus X enemy/player defense
//miss    = (>2 && <=25)         0 damage
//dodge   = (>50 && <=65)        0 damage
//block   = (>25 && <=50)        X enemy/player damage minus X enemy/player block
//crit    = (=100) (X to X *2)   enemy/player damage minus X enemy/player defense
//fumble  = (=1)                 X self damage minus X self defense*/