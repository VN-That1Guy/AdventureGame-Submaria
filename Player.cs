using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace VinhNguyen_AdventureGame
{
    class Player
    {
        public string CharacterName { get; set; }
        public List<Item> Inventory { get; set; }

        public int x { get; set; }
        public int y { get; set; }
        private string PlayerSubmarine;
        public ConsoleColor SubmarineColor;
        public ConsoleColor PlayerBackgroundColor;
        public Player(int initialX, int initialY)
        {
            x = initialX;
            y = initialY;
            PlayerSubmarine = "O";
            Inventory = new List<Item>();
            SubmarineColor = ConsoleColor.Yellow;
            PlayerBackgroundColor = ConsoleColor.DarkBlue;
        }
        //Draws the Player's assigned Character in the Exploration Map
        public void Draw()
        {
            ForegroundColor = SubmarineColor;
            BackgroundColor = PlayerBackgroundColor;
            SetCursorPosition(x, y);
            Write(PlayerSubmarine);
            ResetColor();
        }
        public void PickUpItem(Item item)
        {
            //Checks if the player does not have the item
            if (!Inventory.Contains(item))
            {
                //Add it to the inventory
                Inventory.Add(item);
            }
        }
        public void ShowInventory()
        {
            ForegroundColor = ConsoleColor.Black;
            Clear();
            WriteLine("To read or check your item, type in a number from the list and press enter! \nThey may have valuable information.");
            WriteLine("This is what you have:");
            int index = 0;
            //Create a local string list to hold items names
            List<string> namesOfItems = new List<string>();
            List<string> descriptionOfItems = new List<string>();
            if (Inventory.Count >= 1)
            {
                foreach (Item item in Inventory)
                {
                    namesOfItems.Add(item.Name);
                    descriptionOfItems.Add(item.Description);
                }
                foreach (string item in namesOfItems)
                {
                    WriteLine($"{index + 1}) {namesOfItems[index]}");
                    index++;
                }
                index++;
                WriteLine($"{index}) Go back to menu");
                int userInputIndex = Utility.GetANumberFromUser(index);

                if (userInputIndex == index)
                {
                }
                else
                {
                    WriteLine("\n" + descriptionOfItems[userInputIndex - 1]);
                    WriteLine("Press Any Key to Go back to the menu");
                    ReadKey();
                }
            }
            else
            {
                WriteLine("You do not have anything at the moment.\nPress Any Key to Go Back.");
                ReadKey();
            }
        }
    }
}
