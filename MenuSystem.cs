using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace VinhNguyen_AdventureGame
{
    class MenuSystem
    {
        private int SelectedOption;
        private string[] Options;
        private string Prompt;

        public MenuSystem(string messageprompt, string[] promptoptions)
        {
            Prompt = messageprompt;
            Options = promptoptions;
            SelectedOption = 0;
        }

        public void DisplayOptions(string color)
        {
            if (color == "white")
            {
                ForegroundColor = ConsoleColor.White;
                BackgroundColor = ConsoleColor.Black;
            }
            else if (color == "black")
            {
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.Blue;
            }
            WriteLine(Prompt);
            for (int i = 0; i < Options.Length; i++)
            {
                string currentOption = Options[i];
                string prefix;
                //Highlights a specific line and adds a set prefix to the Option when it is selected.
                if (i == SelectedOption)
                {
                    prefix = ">";
                    if (color == "white")
                    {
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.White;
                    }
                    else if (color == "black")
                    {
                        ForegroundColor = ConsoleColor.White;
                        BackgroundColor = ConsoleColor.Black;
                    }    
                }
                else
                {
                    prefix = " ";
                    if (color == "white")
                    {
                        ForegroundColor = ConsoleColor.White;
                        BackgroundColor = ConsoleColor.Black;
                    }
                    else if (color == "black")
                    {
                        ForegroundColor = ConsoleColor.Black;
                        BackgroundColor = ConsoleColor.White;
                    }
                }
                WriteLine($"{prefix} [{currentOption}]");
            }
            if(color == "white")
            {
                ForegroundColor = ConsoleColor.Gray;
                BackgroundColor = ConsoleColor.Black;
            }
            else if(color == "black")
            {
                ForegroundColor = ConsoleColor.Black;
                BackgroundColor = ConsoleColor.Blue;
            }
            WriteLine("Use arrow keys up and down to cycle through options and press enter to select an option.");

        }
        //Starts the Menu process when called, uses same string as Display Options because the DisplayOptions is called in this method.
        public int Run(string color)
        {
            ConsoleKey PressedKey;
            do
            {
                Clear();
                DisplayOptions(color);
                ConsoleKeyInfo keyInfo = ReadKey(true);
                PressedKey = keyInfo.Key;
                if (PressedKey == ConsoleKey.UpArrow)
                {
                    SelectedOption--;
                    if (SelectedOption == -1)
                    {
                        SelectedOption = Options.Length - 1;
                    }
                }
                else if (PressedKey == ConsoleKey.DownArrow)
                {
                    SelectedOption++;
                    if (SelectedOption == Options.Length)
                    {
                        SelectedOption = 0;
                    }
                }
            }
            while (PressedKey != ConsoleKey.Enter);

            return SelectedOption;
        }
    }
}
