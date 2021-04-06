using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace VinhNguyen_AdventureGame
{
    class GridMap
    {
        string[,] Map;
        int Row;
        int Colum;

        public GridMap(string[,] aquatank)
        {
            Map = aquatank;
            Row = aquatank.GetLength(0);
            Colum = aquatank.GetLength(1);
        }

        //Draws the map
        public void Draw()
        {
            for (int y = 0; y < Row; y++)
            {
                for (int x = 0; x < Colum; x++)
                {
                    //takes the current data for the map and draws it
                    string location = Map[y, x];
                    SetCursorPosition(x, y);
                    //Checks if the detail is this specific character in the map to be colored differently
                    if (location == "█")
                    {
                        ForegroundColor = ConsoleColor.Green;
                    }
                    else
                    {
                        ForegroundColor = ConsoleColor.DarkGreen;
                    }
                    BackgroundColor = ConsoleColor.DarkBlue;
                    Write(location);
                    BackgroundColor = ConsoleColor.Blue;
                }
            }
            ForegroundColor = ConsoleColor.Black;
            Write("\nMove \"O\"(Your Submarine) around with the Arrow Keys\nHead to one of the Area of Interest (");
            ForegroundColor = ConsoleColor.Green;
            Write("█");
            ForegroundColor = ConsoleColor.Black;
            WriteLine(") to enter the area and leave this grid map. \nAlternatively, you can leave the gridmap by pressing the Escape Key (esc).\nYou need to explore an area multiple times to find an item. Each Area has only 1 in total. \nYou may come across additional items as you move around the map. \n All maps carry only one note each. Be sure to check your inventory if you have atleast all 3 notes wtih (!).");
        }
        public string GetGridMapLocation(int x, int y)
        {
            return Map[y, x];
        }
        //Checks if the Player's assigned Character is occupying the space that they can move in to and call in something else like a statement
        public bool CanMoveTo(int x, int y)
        {
            if (x < 0 || y < 0 || x >= Colum || y >= Row)
            {
                return false;
            }

            return Map[y, x] == " " || Map[y, x] == "█" || Map[y, x] == "+";
        }

    }
}
