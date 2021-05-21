using System;
using System.Collections.Generic;
using System.Text;
using textAdventure;

namespace backpack
{
    public class Backpack
    {
        public Backpack()
        {
            backPack.Add(Item.WheelofCheese);
        }
        public List<Item> backPack = new List<Item>();
        public void ShowBackpack()
        {
            Console.Clear();
            if (backPack.Count < 1)
            {
                Console.WriteLine("Your backpack is empty.\nPress Enter to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You open your backpack.");
                for (int i = 0; i < backPack.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{backPack[i]}");
                }
                Console.Write("\nSelect item by number:> ");
                string str = Console.ReadLine().ToUpper();
                                                                //(!Char.IsDigit(str[0]) &&
                                                                //!(Int32.Parse(str) < backpack.Count) &&
                                                                //!(str == "EXIT") && !(str == "E"))
                                                                //(!(Char.IsDigit(str[0]) || str == "EXIT" || str == "E"))
                while (true)
                {
                    if (str.Length < 1)
                    {

                    }
                    else if (Char.IsDigit(str[0]))
                    {
                        if (Int32.Parse(str) <= backPack.Count)
                        {
                            UseItem(Int32.Parse(str) - 1);
                            break;
                        }
                    }
                    else if (str == "EXIT" || str == "E")
                    {
                        Console.WriteLine("You close the backpack\nPress Enter to continue.");
                        Console.ReadLine();
                        break;
                    }
                    Console.Write("Incorrect input, select item [#] or EXIT[E]:> ");
                    str = Console.ReadLine().ToUpper();
                }
            }
                
        }
        public void UseItem(int slot)
        {
            switch (backPack[slot])
            {
                case Item.SteelMace:
                    Program.player.Atk+=2;
                    backPack.RemoveAt(slot);
                    Console.WriteLine("You equip the Steel Mace. Your Attack increase by 2.");
                    Console.ReadLine();
                    break;
                case Item.OakShield:
                    Program.player.Def+=2;
                    backPack.RemoveAt(slot);
                    Console.WriteLine("You equip the Oak Shield. Your Defense increase by 2.");
                    Console.ReadLine();
                    break;
                case Item.HPpotion:
                    Program.player.HP+=10;
                    backPack.RemoveAt(slot);
                    Console.WriteLine("You chug the health potion. You heal 10 HP.");
                    Console.ReadLine();
                    break;
                case Item.WheelofCheese:
                    Program.player.HP++;
                    backPack.RemoveAt(slot);
                    Console.WriteLine("You eat a whole wheel of cheese. You heal 1 HP.");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
    }
    public enum Item
    {
        SteelMace,
        OakShield,
        HPpotion,
        WheelofCheese
    }
}


/* create list of items picked up
on command [B]ackpack show list
subcommand [U]se:
if Weapon or Shield - [U]se modifies Stats.<attack or defense> "You equip <item>"
if >0 HP potion - [U]se modifies Stats.<Base HP>, set HP potion-- "you heal XX HP"
*/

//[B]
//1. Mace
//2. shield
//3. hp potion

//select item:> 1
//    you equip Mace, your attack increase by 2.


//                foreach (Item item in backpack)
//            {
//    Console.WriteLine("Contents:");
//    Console.WriteLine(item);
//}