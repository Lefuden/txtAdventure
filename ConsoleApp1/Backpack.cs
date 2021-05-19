using System;
using System.Collections.Generic;
using System.Text;

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
            for (int i = 0; i<backpack.Count; i++)
            {
                Console.WriteLine($"{i+1}.{backpack[i]}");
            }
            string str = Console.ReadLine().ToUpper();
            while (!Char.IsDigit(str[0]) && !(str == "EXIT") && !(str == "E")) //(!(Char.IsDigit(str[0]) || str == "EXIT" || str == "E"))
            {
                Console.Write("Incorrect input, select item [#] or EXIT[E]:> ");
                str = Console.ReadLine();
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