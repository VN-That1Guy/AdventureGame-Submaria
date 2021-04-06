using System;
using System.Collections.Generic;
using System.Text;

namespace VinhNguyen_AdventureGame
{
    class Item
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public string ItemGetText { get; set; }

        public Item(string name, string description, string itemgettext)
        {
            Name = name;
            Description = description;
            ItemGetText = itemgettext;
        }
    }
}
