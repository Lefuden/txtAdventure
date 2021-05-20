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
            backpack.Add(Item.WheelofCheese);
        }
        public List<Item> backpack = new List<Item>();
        public void ShowBackpack()
        {
            Console.Clear();
            if (backpack.Count < 1)
            {
                Console.WriteLine("Your backpack is empty.\nPress Enter to continue");
                Console.ReadLine();
            }
            else
            {
                Console.WriteLine("You open your backpack.");
                for (int i = 0; i < backpack.Count; i++)
                {
                    Console.WriteLine($"{i + 1}.{backpack[i]}");
                }
                Console.Write("Select item by number:> ");
                string str = Console.ReadLine().ToUpper();
                //(!Char.IsDigit(str[0]) &&
                //!(Int32.Parse(str) < backpack.Count) &&
                //!(str == "EXIT") && !(str == "E"))
                //(!(Char.IsDigit(str[0]) || str == "EXIT" || str == "E"))
                while (true)
                {
                    Console.WriteLine(Program.player.HP);
                    if (str.Length < 1)
                    {

                    }
                    else if (Char.IsDigit(str[0]))
                    {
                        if (Int32.Parse(str) <= backpack.Count)
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
                    str = Console.ReadLine();
                }
            }
                
        }
        public void UseItem(int slot)
        {
            switch (backpack[slot])
            {
                case Item.Mace:
                    Program.player.Atk+=2;
                    backpack.RemoveAt(slot);
                    Console.WriteLine("You equip the Steel Mace. Your Attack increase by 2.");
                    Console.ReadLine();
                    break;
                case Item.Shield:
                    Program.player.Def+=2;
                    backpack.RemoveAt(slot);
                    Console.WriteLine("You equip the Oak Shield. Your Defense increase by 2.");
                    Console.ReadLine();
                    break;
                case Item.HPpotion:
                    Program.player.HP+=10;
                    backpack.RemoveAt(slot);
                    Console.WriteLine("You chug the health potion. You heal 10HP.");
                    Console.ReadLine();
                    break;
                case Item.WheelofCheese:
                    Program.player.HP++;
                    backpack.RemoveAt(slot);
                    Console.WriteLine("You eat a whole wheel of cheese. You heal 1HP.");
                    Console.ReadLine();
                    break;
                default:
                    break;
            }
        }
    }
    public enum Item
    {
        Mace,
        Shield,
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