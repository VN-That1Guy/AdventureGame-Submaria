using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace VinhNguyen_AdventureGame
{
    class AreaOfInterest
    {
        public string Name { get; set; }
        public List<Item> AvailableItems { get; set; }

        public List<Item> RequiredItems { get; set; }
        public List<string> Dialogue { get; set; }

        public AreaOfInterest()
        {
            Name = Name;
            AvailableItems = new List<Item>();
            RequiredItems = new List<Item>();
            Dialogue = new List<string>();
        }
    }
}
