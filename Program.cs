using System;
using static System.Console;
/* Vinh Nguyen
 * Introduction to Programming SP21
 * Adventure Game Project
 * Play Testers: Tyler Campo, Long Nguyen
 * Title generated in ascii.today
 * ASCII Font Art (Poison) by Vinney Thai
 * Other drawn ASCII art is made by using https://asciiflow.com/
 * 
 * For a Game to be this Simple and Short, I can't say that it was able to use all three pillars of programing that much.
 * Inheritance is when Classes have a relationship between each other, where Class is original and the other is based off of that class, therfore being a child class parented to the original class.
 * As much as I wanted flesh out the Areas a lot more, I need this solution to be as minimal as possible to reach under five minutes. I was planning for a few subclasses for Areas where there'd be more text entries depending on what type of area it is, like generic entries that explain that the player is moving around whatever this is exclusive to those kind of environments and such.
 * Polymorphism is basically how flexible you can make your method.
 * For this as one of my examples, I wrote a method for displaying text with color and for a certain amount of time to basically save time in writing code. I started out with Text(string message) and Wait(int miliseconds). I later then wanted to do color and also try not to type Wait() alot, so I overloaded Text and added a Writeline version of Text called TextLine to have string color as well. So there is a Text and TextLine for writing normal text and a copy of them for writing colored text.
 * Encapsulation is grouping code together which you can use to organize and or hide bits and pieces of code that makes up your program.
 * Honestly the most basic example for me is the GridMap system that's in this solution, the Menu System, and the Player. They all have Methods that can be called by the Game class but are not present in the Game class's coding. Like the Player's Inventory, How the Map and player gets drawn seperately, How the Menu is able to cycle between options, etc. While the Game Class does most of the work, it's still made up of other classes that support it's coding.
 */

namespace VinhNguyen_AdventureGame
{
    class Program
    {
        static void Main()
        {
            Title = "Submaria";

            new Game();
            Console.ReadKey();
        }
    }
}
