using System;
using System.Collections.Generic;
using System.Text;
using static System.Console;

namespace VinhNguyen_AdventureGame
{
    class Game
    {
        public Player Player { get; set; }
        public List<AreaOfInterest> Places { get; set; }
        GridMap TheAquaTank;
        bool Accessible = false;
        bool Win = false;
        int HowMuchYouMoved = 0;
        int HowMuchYouExplored = 0;
        int IntroEasterEggs = 0;
        int PlayerCommentsWhereIsEveryone = 0;
        public Game()
        {
            Setup();
            Start();
            NewGame();
        }
        Item note1 = new Item("(!)A Note", $"On this note it's written: \nDear Reader, if you are reading this then you must have survived the purge.\nWhat this means is that every one you might have known is now gone. However,\nnot all hope is gone. \nWhile most of us are gone, there are still a few of us left out there some where. We're always\n moving to find a safer place incase of the next purge. \nWe hope you can run into us and vice versa before it happens again. \nHope to see another face soon.", "You find a note on the ground and used your submarine's claw to get it as best as you can.\nYou failed to grab it. However, you got in your diving gear and grabbed it with your own hand.\nThank Goodness for water proof papers!");
        Item note2 = new Item("(!)Torn Journal Page", "On this note it's written: \nWhat happened? Where am I? Where is everyone?? Am I really alone??? \nIf that's the case, what am I supposed to do now?? No... There has to be some one out there!!!\nI don't wanna die alone! ...Only writing on this journal can calm me down... \nThe whole sea world has gone bad, most of what I call home is no longer there any more, \nand the sudden disappearance of every one? This is straight out of my nightmare!\n\nYou flip the note around and see more written on the back: \nOkay, Okay. I've found this freakin symbol marked on when I passed by one of the rocks around here. \nI'm so creeped out and I don't know what that means! But for some reason \nit gives me hope that some one is out there after all! But I'm also terrified \nabout who could be out there... it's so lonely here and I dread to find some one that isn't like me... \nThe rest of the page was taken by the drawing of the symbol that was mentioned. \nYou recognize this as you passed by it many times as it is scattered every where as you travel. \nYou thought they hold no significance so you forgot about it until you read this note.", "You wander around out side of your submarine to find a note stuck on one of the corals. \nMiraculously, it's mostly unscathed. \nYou take the note and head back to your submarine.");
        Item note3 = new Item("(!)Scratched Note", "The note is scribbled through out repeating two same numbers over and over again. \nMost of the page is also overlapped with one crudely written word, \"SECRET\" \n 1,1 1,1 1,1 1,1 1,1 1,1 1,1\n1,1 1,1 1,1 1,1 1,1 1,1 1,1\n  1,1 1,1 1,1 1,1 1,1 1,1 1,1 \n1,1 1,1 1,1 1,1 1,1 1,1 1,1\n  1,1 1,1 1,1 1,1 1,1 1,1 1,1\n 1,1 1,1 1,1 1,1 1,-\nYou think to yourself: Could those be the coordinates for a place on your radar?", "In the great throne room of the castle, you manage to find a particularly damaged note on a chest. \nLooking at it's content, You make your way back to your submarine as soon as possible.");
        Item slipkey = new Item("(!)The Slip Key", "A strange looking key for something.", "You have grabbed the Artifact");
        Item sidenote1 = new Item("A Note#2", "On the note: \nDear Reader, we think we have found a spot that will help you alot in surviving. \nBut we don't know where it is. We're holed up at the Great Whale's Pub at Great Whale's Castle. \nDon't sweat it if we're not there, we left supplies since we can't bring them all at \nonce. It also means we might have found another clue and are pursuing it.", "You have found a note!");
        Item sidenote2 = new Item("Journal Page#2", "On the page: \nMost of it is worn and torn harshly. What you could make out are: \"secret???\", \"problem\", \"Maybe this is wh-\", and \" I must\".", "You have found a torn page!");
        Item sidenote3 = new Item("An... Advertisement?", "On the flyer: \nAtlantis too crowded for you? Are the other places too lowly for an individual such as yourself?? \nCome on down to our next establishment: ATLANTIS 2 (name pending) \nAs we've decided enough is enough with our social problems with such limited space \nfor such a great population and knowing how much people like you love our city, \ntake it from our founder, Alan P. Ahde'tale- \nMost of content of this paper is markered out with black and the image of the place has been drawn over by \nthe symbol you have seen through out your venture. You don't recognize the place but where it is looks familiar \n\nOn the back there's writing: SEAGATE = FREEDOM\nLOCKED??\nTHE KEY ->\n\nYou see a drawing of a strange object that bares little resemblance of a key \nbut more to those symbols you have passed by.", "You have found a.. flyer?");
        Item gatenote = new Item("(?)Gate Note", "This is the note you found from the Sea Gate: \nSo it seems that this place has a giant gate that may get us out of this Aquarium. \nOne problem though. It's not powered up. Old man says there must be something to power this, \nlike a key of some kind. Some of us went crazy and he's the last person I'd think to become as crazy \nbut I'm starting to think he's getting crazy. He calls this the Sea Gate. \nI'd thought he'd give it a more clever name or something but whatever. \nI'd rather search for another option, for all we know, this quote unquote \"Key\" could be ANYWHERE or \nit could be NOWHERE out there. Push is going to come to shove and we'll all be gone before we know it, \nlike every one else. \n\nAs you finish reading, you think to yourself if this key could be anywhere at all? \nThere's more behind the note: \nWe searched every nook and cranny of each place. Atlantis, Great Whale's Castle, and even Sting Coral Reef. \nSo the Key really is out there. I think me and what's left of my group will spend the rest of our time looking \n for another way out. ", "As you arrive, you instantly find a note laying on the ground behind what looks like the control panel. \nAs always, there's completely no sign of life around here.");
            List<Item> RandomNotes = new List<Item>();
        private void Setup()
        {
            //Resets the Booleans and Intergers to 0 so that it doesn't count the players previous game if they restart after finishing the game
            Accessible = false;
            Win = false;
            HowMuchYouMoved = 0;
            HowMuchYouExplored = 0;
            IntroEasterEggs = 0;
            PlayerCommentsWhereIsEveryone = 0;
            Places = new List<AreaOfInterest>();
            
            RandomNotes.Add(sidenote1);
            RandomNotes.Add(sidenote2);
            RandomNotes.Add(sidenote3);


            AreaOfInterest area1 = new AreaOfInterest
            {
                Name = "Atlantis",
                AvailableItems = new List<Item>() { note1 },
                RequiredItems = null,
                Dialogue =
                {
                    "You come across the sign that welcomes you to Atlantis. Below the welcome title \nyou read: \"100% more man and free than Rapture City\". \"Huh\", you go to yourself.",
                    "Because of how sophisticated this place was designed, you can infer that people could live here \nwith out a diving suit and a submarine the best out of the other places you've seen so far.",
                    "You searched deep inside the interiors of the once technologically advanced themed city \nto only find supplies and tools to take care of your submarine and yourself.",
                    "As you tour each room in the city in your diving suit, you only find remnants of civilization and belongings. \nYou imagine how horrifying it is to be a resident here with out a submarine or a diving suit. \nWhat ever happened to this ocean world must have been that bad.",
                    "You look around the remains of Atlantis in your Submarine."
                }
            };

            Places.Add(area1);

            AreaOfInterest area2 = new AreaOfInterest
            {
                Name = "Sting Coral Reef",
                AvailableItems = new List<Item>() { note2 },
                RequiredItems = null,
                Dialogue =
                {
                    "You find a trashed and thrashed Stink Roll stand. You read the logo on it \nand suddenly questioned why this place was called Sting Coral Reef.",
                    "There are other food stands, the ones standing out the most being Tootles, Hot Buns, and Feed Mix.\nWhy does this place exist again?",
                    "As you search into the Corals, you see evidence of people who once lived here. \nTheir belongings scattered scarcely but no hint of remain to be found.",
                    "This place is dominated by food stands, making the whole place a food court. \nAs great as that sound, the whole place was ransacked. \nLeaving you little supplies.",
                    "The most prominent competitor of this place must've been Stink Roll judging by \nhow common you've seen the logo and branding through out the reef. \nBillboards, papers, and signs hammered into the sand all have the Stink Roll Logo and Brand.",
                    "You continue patrolling around the reefs."
                }
            };

            Places.Add(area2);

            AreaOfInterest area3 = new AreaOfInterest
            {
                Name = "The Great Whales Castle",
                AvailableItems = new List<Item>() { note3 },
                RequiredItems = null,
                Dialogue =
                {
                    "You wonder around in this big place, the town would be a maze if you were in there.",
                    "You find some perfect condition supplies at a good ol' pub. If only there were other people to party with",
                    "You find a teasure chest some where under the castle. To your disappointment, \nit's just plastic gold and bubbles.",
                    "As you explore the town even further inside the castle, you ask yourself how do these people \nlive as the whole place is medieval themed down to a T.",
                    "You check all the knight quarters in the castle. All the armors are scattered around and the weapons \nare all badly damage to being useless. As cool as those armors may be, there's no need for them.",
                    "You notice as you travel through out the castle that all the gold around here are actually just plastic. \n\"What a strange material for currency\", you think to yourself.",
                    "You enter the castle itself and into the throne room."
                }
            };

            Places.Add(area3);


            AreaOfInterest seagate = new AreaOfInterest
            {
                Name = "The Sea Gate",
                AvailableItems = null,
                RequiredItems = new List<Item>() { slipkey },
                Dialogue =
                {
                    "And so this is it. Your ticket out of here.",
                    "But who knows what lies on the other side?",
                    "Could there be others waiting for you?",
                    "What if you are really just alone no matter what?",
                    "\"Only one way to find out\", you think to yourself."
                }
            };

            Places.Add(seagate);

            AreaOfInterest slipkeyencounter = new AreaOfInterest
            {
                Name = "No Where",
                AvailableItems = new List<Item>() { slipkey },
                Dialogue =
                {
                    "You see a strange looking artifact. On inspection, it seems to bare resemblance to those symbols.",
                    "This artifact looks familiar but you can't put your finger on it.",
                    "What's a strange artifact doing in the middle of no where?"
                }
            };
            Places.Add(slipkeyencounter);

            Player = new Player(6,4)
            {
                CharacterName = "",
                Inventory = new List<Item>()
            };
        }
        //I wrote Wait() just to save me time from writing System.Theading.Thread.Sleep alot :p
        private void Wait(int miliseconds, bool dots = false)
        {
            System.Threading.Thread.Sleep(miliseconds);
            if (dots)
            {
                for (int i = 0; i < 3; i++)
                {
                    Write(". ");
                    Wait(400);
                }

            }
        }
        //Text and TextLine are here to save time of coloring text and using Wait() too repetatively
        private void Text(string message, int miliseconds = 0)
        {
            ForegroundColor = ConsoleColor.Gray;
            CursorVisible = false;
            Write(message);
            ResetColor();
            Wait(miliseconds);
            CursorVisible = true;
        }
        private void TextLine(string message, int miliseconds = 0)
        {
            CursorVisible = false;
            ForegroundColor = ConsoleColor.Gray;
            WriteLine(message);
            ResetColor();
            Wait(miliseconds);
            CursorVisible = true;
        }
        private void Text(string message, string color, int miliseconds = 0)
        {
            if (color == "red")
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else if (color == "blue")
            {
                ForegroundColor = ConsoleColor.Blue;
            }
            else if (color == "green")
            {
                ForegroundColor = ConsoleColor.Green;
            }
            else if (color == "yellow")
            {
                ForegroundColor = ConsoleColor.Yellow;
            }
            else if (color == "white")
            {
                ForegroundColor = ConsoleColor.White;
            }
            else if (color == "black")
            {
                ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                ForegroundColor = ConsoleColor.Magenta;
            }
            CursorVisible = false;
            Write(message);
            ForegroundColor = ConsoleColor.Gray;
            Wait(miliseconds);
            CursorVisible = true;
        }
        private void TextLine(string message, string color, int miliseconds = 0)
        {
            if (color == "red")
            {
                ForegroundColor = ConsoleColor.Red;
            }
            else if (color == "blue")
            {
                ForegroundColor = ConsoleColor.Blue;
            }
            else if (color == "cyan")
            {
                ForegroundColor = ConsoleColor.Cyan;
            }
            else if (color == "green")
            {
                ForegroundColor = ConsoleColor.Green;
            }
            else if (color == "yellow")
            {
                ForegroundColor = ConsoleColor.Yellow;
            }
            else if (color == "white")
            {
                ForegroundColor = ConsoleColor.White;
            }
            else if (color == "black")
            {
                ForegroundColor = ConsoleColor.Black;
            }
            else
            {
                ForegroundColor = ConsoleColor.Magenta;
            }
            CursorVisible = false;
            WriteLine(message);
            ForegroundColor = ConsoleColor.Gray;
            Wait(miliseconds);
            CursorVisible = true;
        }
        private void Start()
        {
            //Title Screen
            WindowWidth = 150;
            int FadeInTitle = 0;
            while (FadeInTitle <= 4)
            {
                Clear();
                if (FadeInTitle == 0)
                {
                    ForegroundColor = ConsoleColor.Black;
                }
                else if (FadeInTitle == 1)
                {
                    ForegroundColor = ConsoleColor.DarkBlue;
                }
                else if (FadeInTitle == 2)
                {
                    ForegroundColor = ConsoleColor.DarkCyan;
                }
                else if (FadeInTitle == 3)
                {
                    ForegroundColor = ConsoleColor.Blue;
                }
                else if (FadeInTitle == 4)
                {
                    ForegroundColor = ConsoleColor.Cyan;
                }

                WriteLine(@" 
     @@@@@@   @@@  @@@  @@@@@@@   @@@@@@@@@@    @@@@@@   @@@@@@@   @@@   @@@@@@   
    @@@@@@@   @@@  @@@  @@@@@@@@  @@@@@@@@@@@  @@@@@@@@  @@@@@@@@  @@@  @@@@@@@@  
    !@@       @@!  @@@  @@!  @@@  @@! @@! @@!  @@!  @@@  @@!  @@@  @@!  @@!  @@@  
    !@!       !@!  @!@  !@   @!@  !@! !@! !@!  !@!  @!@  !@!  @!@  !@!  !@!  @!@  
    !!@@!!    @!@  !@!  @!@!@!@   @!! !!@ @!@  @!@!@!@!  @!@!!@!   !!@  @!@!@!@!  
     !!@!!!   !@!  !!!  !!!@!!!!  !@!   ! !@!  !!!@!!!!  !!@!@!    !!!  !!!@!!!!  
         !:!  !!:  !!!  !!:  !!!  !!:     !!:  !!:  !!!  !!: :!!   !!:  !!:  !!!  
        !:!   :!:  !:!  :!:  !:!  :!:     :!:  :!:  !:!  :!:  !:!  :!:  :!:  !:!  
    :::: ::   ::::: ::   :: ::::  :::     ::   ::   :::  ::   :::   ::  ::   :::  
    :: : :     : :  :   :: : ::    :      :     :   : :   :   : :  :    :   : :

");
                Wait(250);
                FadeInTitle++;
            }
            TextLine("                      A Short Adventure Game made by Vinh Nguyen\n", "cyan", 1000);
            ForegroundColor = ConsoleColor.Gray;
            WriteLine("                              (Press Any Key To Start)\n");
            ReadKey();
            Clear();

            //Asks for Player name before the game starts
            WriteLine("Welcome to the Submaria! \nWhat is your character's name in this adventure?");
            Player.CharacterName = ReadLine();
            Clear();
            WriteLine($"{Player.CharacterName}, welcome to Submaria!\nPress any key to continue.\n");
            ReadKey();
            Clear();
            //Sets the Window Title bar to show the character name and the name of the game after gathering the player's input
            Title = $"{Player.CharacterName} - Submaria";
        }
        //Introductory sequence that serves as a transition from Title to being in the actual game
        private void NewGame()
        {
            //Start the game with an introduction into the world
            TextLine("You wake up in a small room that seems to be yours.\nYou have no recollection of your memories and there does not seem to be any one around.", 1000);
            TextLine("What do you do?\n1) Call out\n2) Look around\n3) Wait", "blue");
            int WhatYouDidNumber = Utility.GetANumberFromUser(3);
            if (WhatYouDidNumber == 1)
            {
                TextLine("You called out if any one is around", 750);
                TextLine("there is no response.", 1400);
            }
            else if (WhatYouDidNumber == 2)
            {
                TextLine("You look around the room, it's seems to be a personal quarter.", 800);
                TextLine("You look outside your room as well to only find no one.",1400);
            }
            else
            {
                TextLine("You think to yourself that maybe someone will come in eventually to check up on you.", 1000);
                TextLine("However, no one came.", 1400);
            }
            TextLine("Eventually, You then decide to explore around for a short time and discover that you are in a submarine.", 1500);
            Text("(Type anything)\nYour reaction: ", "yellow");
            string Reaction = ReadLine().ToLower();
            //Reaction.ToLower();
            if (Reaction.Contains("poop") || Reaction.Contains("shit") || Reaction.Contains("pee") || Reaction.Contains("piss") || Reaction.Contains("vomit") || Reaction.Contains("puke"))
            {
                TextLine("... that's pretty gross, my fellow chum.", "");
                IntroEasterEggs++;
            }
            else if (Reaction.Contains("suicide") || Reaction.Contains("kill") || Reaction.Contains("explode"))
            {
                TextLine("Somehow your submarine combusts by itself and before you could react, you drown as the water quickly flows in.", "white", 3000);
                TextLine("Congratulations you've speedrunned this game!", "green", 2500);
                TextLine("Just kidding, you actually wake up in the same room that you woke up in \nand came out to the same place that you stood in before your dream ended.", 1500);
                TextLine("You still don't remember anything.", "red", 200);
                IntroEasterEggs++;
            }
            Wait(500, true);
            Text(@"
                                                                                            ┌────────────────────┐
                                                                                            │                    │
                                                                                            │                    │
                                                                                            │                    │
                                                                                         ┌──┘                    │
                                                                                         │                       │
                                                                                         │                       │
                  ┌───┐                                                                  │                       │
                  │   │            ┌───────┬─────────────────────────────────────────────┴───────────────────────┴───┐xxxxxx
                  │   │   ┌────────┘       │                                                                         │|||||xxxxx
             ▲    │  ┌┴───┘                │                                                                         │||||||xxxx
             │  ┌─┴──┘                     │                                                                         │   |||xxxx
            ┌┴┐ │                          │                             Your Submarine                              │    ||xxxx
            │ ├─┤                          │                                                                         │    ||xxxx
            └┬┘ │                          │                                                                         │   |||xxxx
             │  └─┬──┐                     │                                                                         │||||||xxxx
             ▼    │  └┬───┐                │                                                                         │|||||xxxxx
                  │   │   └────────────────┴─────────────────────────────────────────────────────────────────────────┘xxxxxx
                  └───┘" + "\n", "yellow");
            Wait(500);
            TextLine("You quickly make an inference that you own this little submarine.\nAs you enter the pilot seat of the submarine, you feel the knowledge of piloting this submarine flowing to your head.", 900);
            WriteLine("You see nothing but darkness.");

            bool Choice = true;
            int ChoiceNumberOneCheck = 0;
            while (Choice)
            {
                TextLine("\nWhat do you want to do?\n1) Get back up and explore around your submarine more\n2) Turn on the Lights", "blue");
                int UserChoice = Utility.GetANumberFromUser(2);
                if (UserChoice == 1)
                {
                    int number = -1;
                    Random random = new Random();
                    string[] SubmarineEncounters = { 
                        "You decided to go back and grab and eat some grubs.", 
                        "You go back and contemplate on life and wonder why you are here.", 
                        "You forgot what you were doing here, standing up.", 
                        "You see a Maclanky in your submarine.\nYou look at the maclanky and think about how delicious it would be.\nYou think about how delicious it would be if you ate it raw, cooked, and boiled.", 
                        "You realize that you are in a game for five minutes.", 
                        "You get a strange sense of deja vu as you've thought you might have done this before." 
                    };
                    number = random.Next(0, SubmarineEncounters.Length);
                    TextLine("You got up and:", 800);
                    TextLine(SubmarineEncounters[number], 1000);
                    ChoiceNumberOneCheck++;
                    if (ChoiceNumberOneCheck == 3)
                    {
                        TextLine("\nYou eventually find out about the headlights switch at the pilot seat.", 1000);
                        IntroEasterEggs++;
                    }
                    else if (ChoiceNumberOneCheck == 6)
                    {
                        TextLine("\nAs you go back to the pilot seat, you realize you can't pilot the Submarine with out turning on the lights.", "white", 1300);
                        IntroEasterEggs++;
                    }
                    else if (ChoiceNumberOneCheck == 9)
                    {
                        TextLine("\nYou know, supplies in here aren't going to last forever.", "red", 1500);
                        Text("Why don't you try turning on the ", "red");
                        Text("headlights ", "white");
                        TextLine("so we can get this show out in the ocean?", "red", 1500);
                        IntroEasterEggs++;
                    }
                    else if (ChoiceNumberOneCheck == 12)
                    {
                        TextLine("\nYour mind does not recognize the controls of the submarine, thus leaving you to succumb to the darkness.", "white", 2000);
                        TextLine("You stayed in the submarine for what feels like many days, as you continue to consume supllies", 1000);
                        TextLine("your submarine suffers from a sudden violent earthquake which knocks you out and permanently disables your submarine.", "red", 1000);
                        TextLine("Your fate has been sealed.", "red", 500);
                        WriteLine("(Press Any Key to End Game)");
                        ReadKey(true);
                        EndGame();
                    }
                }
                else
                {
                    TextLine("\nOne flick of the switch on the board in front with the label \"Head Lights\"\nand you can see, with your headlights on, that you are in a cave.", 700);
                    Choice = false;
                }
            }
            WriteLine("Press Any Key to Continue");
            ReadKey();
            CursorVisible = false;
            Clear();
            Wait(1000);
            BackgroundColor = ConsoleColor.DarkBlue;
            Clear();
            Wait(1000);
            BackgroundColor = ConsoleColor.Blue;
            Clear();
            Wait(500);
            TextLine("\nAs you exit the cave, you find your self in the middle of no where for now.\n(Press Any Key to go to the menu)", "black");
            ReadKey();
            ShowMenu();
        }

        //Shows a Summary and End's the game when called.
        private void EndGame()
        {
            Clear();
            Wait(500);
            BackgroundColor = ConsoleColor.DarkBlue;
            Clear();
            Wait(500);
            ResetColor();
            Clear();
            TextLine("You have collected:", "cyan", 1000);
            int Index = 0;
            foreach (Item item in Player.Inventory)
            {
                Index++;
                TextLine($"{Index} -" + item.Name);
            }
            WriteLine("");
            if (Player.Inventory.Count == 8)
            {
                TextLine("You collected all the Items available in the game!","green");
            }
            else if (Player.Inventory.Count >= 3)
            {
                TextLine("You collected all key items!", "white");
            }
            else if (Player.Inventory.Count == 0)
            {
                TextLine("You have collected nothing!");
            }
            Wait(1000);
            TextLine($"You have moved for {HowMuchYouMoved} times.", "white", 1000);
            TextLine($"You have explored areas for {HowMuchYouExplored} times.", "white", 1000);
            Text("That means you progressed through the game in a total of: ", 1000);
            int MovedAndExploredTotal = HowMuchYouMoved + HowMuchYouExplored;
            Text($"{MovedAndExploredTotal} ", "yellow");
            Text("times.\n", 1000);
            TextLine($"Intro Easter Egg Lines triggered: {IntroEasterEggs}", "magenta yes", 2000);
            if(IntroEasterEggs == 0)
            {
            TextLine("Hint: Try to explode in your reaction or explore your submarine a lot more before you leave the cave", "magenta" ,500);
            }
            bool endgamemenu = true;
            if (Win == true)
            {
                TextLine("Congratulations, You have beaten Submaria the game!", "green", 2000);
                while (endgamemenu == true)
                {
                    WriteLine("Do you want to play again? Y/N");
                    var consolekey = ReadKey(true);
                    switch (consolekey.Key)
                    {
                        case ConsoleKey.Y:
                            new Game();
                            break;
                        case ConsoleKey.N:
                            TextLine("Thank you so much for playing my game :)", "green", 3500);
                            endgamemenu = false;
                            break;
                        default:
                            TextLine("\nPlease Type in Y for Yes or N for no");
                            break;
                    }
                }
            }
            else
            {
            TextLine("Game Over.", "blue");
            WriteLine("Press Any Key to Exit");
            ReadKey();
            }
            Environment.Exit(0);
        }

        //Draws the map that the player will be in for the rest of the game and starts the game.
        private void Explore()
        {
            string[,] aquatank =
            { //  0   1   2   3   4   5   6   7   8   9  10  11  12  13   
                {"┌","─","─","─","─","─","─","─","─","─","─","─","─","┐" },//0
                {"|","+","+","+","+","+","+","+","+","+","█","+","+","│" },//1
                {"│","+","+","+","+","+","+","+","+","+","+","+","+","│" },//2
                {"│","+","+","+","+","+","+","+","+","+","+","+","+","│" },//3
                {"│","+","+","+","+","+","+","+","+","+","+","+","+","│" },//4
                {"│","+","+","+","+","+","+","+","+","+","+","+","+","│" },//5
                {"│","+","+","+","+","+","+","+","+","+","+","+","█","│" },//6
                {"│","█","+","+","+","+","+","+","+","+","+","+","+","│" },//7
                {"└","─","─","─","─","─","─","─","─","─","─","─","─","┘" } //8
            };
            TheAquaTank = new GridMap(aquatank);
            

            TheGridMapGame();
        }

        private void DrawFrame()
        {
            CursorVisible = false;
            BackgroundColor = ConsoleColor.Blue;
            Clear();
            TheAquaTank.Draw();
            Player.Draw();
        }
        private void PlayerMoveInput()
        {
            //Registeres Key Press more strictly, to prevent the game from registering many after holding down a specified key for so long.
            ConsoleKey Key;
            do
            {
            ConsoleKeyInfo keyInfo = ReadKey();
            Key = keyInfo.Key;
            }
            while (KeyAvailable);
                switch (Key)
            {
                case ConsoleKey.UpArrow:
                    if (TheAquaTank.CanMoveTo(Player.x, Player.y -1))
                    {
                        Player.y -= 1;
                    }
                    break;
                case ConsoleKey.DownArrow:
                    if (TheAquaTank.CanMoveTo(Player.x, Player.y + 1))
                    {
                        Player.y += 1;
                    }
                    break;
                case ConsoleKey.LeftArrow:
                    if (TheAquaTank.CanMoveTo(Player.x - 1, Player.y))
                    {
                        Player.x -= 1;
                    }
                    break;
                case ConsoleKey.RightArrow:
                    if (TheAquaTank.CanMoveTo(Player.x + 1, Player.y))
                    {
                        Player.x += 1;
                    }
                    break;
                case ConsoleKey.Escape:
                    ShowMenu();
                    break;
                default:
                    break;
            }
            if (Key == ConsoleKey.UpArrow || Key == ConsoleKey.DownArrow || Key == ConsoleKey.LeftArrow || Key == ConsoleKey.RightArrow)
            {
                HowMuchYouMoved++;
            }
        }
        private void TheGridMapGame()
        {
            while (true)
            {
                //Checks if the player has the key notes that they've found in each of the three areas on map and enables them to go to a hidden area (the Sea Gate) on the map
                if (Player.Inventory.Contains(note1) && Player.Inventory.Contains(note2) && Player.Inventory.Contains(note3))
                {
                    Accessible = true;
                }
                DrawFrame();
                
                PlayerMoveInput();
                //Sets where each █ should take the player to on the map depending on the location
                string locationGoal = TheAquaTank.GetGridMapLocation(Player.x, Player.y);
                if (locationGoal == "█")
                {
                    //Inverts the player's character color for visibility
                    Player.PlayerBackgroundColor = ConsoleColor.Green;
                    Player.SubmarineColor = ConsoleColor.DarkBlue;
                    int areanumber = -1;
                    if (Player.x == 1 && Player.y == 7)
                    {
                        areanumber = 0;
                    }
                    else if(Player.x == 10 && Player.y == 1)
                    {
                        areanumber = 1;
                    }
                    else if(Player.x == 12 && Player.y == 6)
                    {
                        areanumber = 2;
                    }
                    bool canGoTo = GoToArea(Places[areanumber]);
                    if (canGoTo)
                    {
                        InArea(Places[areanumber]);
                    }
                }
                //Sea Gate location, does not render █
                if (Player.x == 1 && Player.y == 1)
                {
                    bool TryGoTo = GoToTheGate(Places[3]);
                    if (TryGoTo)
                    {
                        InArea(Places[3]);
                    }
                }
                else
                {
                    Player.SubmarineColor = ConsoleColor.Yellow;
                    Player.PlayerBackgroundColor = ConsoleColor.DarkBlue;
                }
                //Gets a Random number and then checks if it surpasses a set value
                Random random = new Random();
                Random randompick = new Random();
                int chanceoffindingrandomitem = random.Next(0, 100);
                //The Sea Gate key encounter has a 3 percent chance of being found
                if (chanceoffindingrandomitem > 97)
                {
                    if (!Player.Inventory.Contains(slipkey))
                    {
                        HowMuchYouExplored++;
                        FoundTheKey(Places[4]);
                    }
                }
                //Players have a 5 percent chance of finding a random note, they are not key notes.
                else if(chanceoffindingrandomitem > 95)
                {
                    if (RandomNotes != null)
                    {
                        if(RandomNotes.Count > 0)
                        {
                            //An entirely new screen appears to inform players that they have found a note
                            Clear();
                            int randomitem = randompick.Next(0, RandomNotes.Count);
                            Player.PickUpItem(RandomNotes[randomitem]);
                            string prompt = RandomNotes[randomitem].ItemGetText;
                            string[] option = { "Okay!" };
                            MenuSystem confirmation = new MenuSystem(prompt, option);
                            int Confirmation = confirmation.Run("white");
                            switch(Confirmation)
                            {
                                case 0:
                                    break;
                            }
                            RandomNotes.RemoveAt(randomitem);
                        }
                    }
                }
            }
        }
        public void FoundTheKey(AreaOfInterest area)
        {
            bool MenuOn = true;

            while (MenuOn == true)
            {
                //Skips taking the player to the menu screen for finding the key if they already found the slipkey to avoid further repetition
                if (Player.Inventory.Contains(slipkey))
                {
                    MenuOn = false;
                }
                BackgroundColor = ConsoleColor.Blue;
                int randomindex = 0;
                Clear();
                string prompt = "";
                //Extra detail stuff, if Player finds the key before they find all three key notes, write a different message explaining that they don't know about the slipkey yet!
                if (Player.Inventory.Contains(note1) && Player.Inventory.Contains(note2) && Player.Inventory.Contains(note3))
                {
                    prompt = "You find a strange artifact on the ground out of no where, \nBased on the symbols you have passed by and the notes you've read this must be the key.\nWhat do you want to do?";
                }
                else
                {
                    prompt = "You find a strange artifact on the ground out of no where. What do you want to do?";
                }
                string[] options = {"Inspect the Artifact", "Check your Inventory", "Take the Artifact and Leave Area"};
                MenuSystem SlipKeyEncounterMenu = new MenuSystem(prompt, options);
                int userInput = SlipKeyEncounterMenu.Run("black");
                switch (userInput)
                {
                    case 0:
                        Random random = new Random();
                        //Ditto
                        if (Player.Inventory.Contains(note1) && Player.Inventory.Contains(note2) && Player.Inventory.Contains(note3))
                        {
                            TextLine("\nAs you inspect the key further, you recognize the similarities to the symbol. This is indeed the Key", "white", 500);
                        }
                        else
                        {
                            randomindex = random.Next(0, area.Dialogue.Count);
                            TextLine("\n" + area.Dialogue[randomindex], "black", 500);
                        }
                        TextLine("Press Any Key to Continue");
                        ReadKey();
                        break;
                    case 1:
                        Player.ShowInventory();
                        break;
                    case 2:
                        TextLine("\nYou use your Submarine's claw to dig up the Artifact.", "black", 500);
                        BackgroundColor = ConsoleColor.DarkBlue;
                        foreach (Item item in area.AvailableItems)
                        {
                            if (!Player.Inventory.Contains(item))
                            {
                                Player.PickUpItem(item);
                                //Ditto2
                                if (Player.Inventory.Contains(note1) && Player.Inventory.Contains(note2) && Player.Inventory.Contains(note3))
                                {
                                    TextLine("\n" + item.ItemGetText, "strange");
                                }
                                else
                                {
                                    TextLine("\nYou take the strange Artifact.", "strange");
                                }
                            }
                        }
                        BackgroundColor = ConsoleColor.Blue;
                        TextLine("Press Any Key to Continue Exploring");
                        ReadKey();
                            MenuOn = false;
                        break;
                }
            }
            Explore();
        }
        public bool GoToArea(AreaOfInterest area)
        {
            BackgroundColor = ConsoleColor.Blue;
            Clear();
            bool PlayerHasKey = true;
            return PlayerHasKey;
        }

        public bool GoToTheGate(AreaOfInterest area)
        {
            BackgroundColor = ConsoleColor.Blue;
            Clear();
            bool PlayerHasKey = true;
            //Takes the player to another screen if they have the key notes which tick Acessible to true
            if (Accessible == true)
            {
                if (area.RequiredItems != null)
                {
                    foreach (Item item in area.RequiredItems)
                    {
                        TextLine("You arrive at this place never seen before when you passed by. \nAll it took were those notes that you have collected to lead you here. \nYou could barely find where the entrance is on your first time in this location.\nYou could have never known. \nCould this be your ticket to freedom from the endless vast waters in this dome?", "black", 2000);
                        //Checks if the player does not have the slipkey, prints out message if the player doesn't have slipkey
                        if (!Player.Inventory.Contains(item))
                        {
                            TextLine("As you arrive, you see the gate... completely powered off and with out a way to turn it on. \nThere's nothing to do here so you went back out on a search to find a way to open the gate.", "black", 2000);
                            PlayerHasKey = false;
                        }
                        //Gives the player a pseudo key note upon first arrival
                        if (!Player.Inventory.Contains(gatenote))
                        {
                            Player.PickUpItem(gatenote);
                            TextLine(gatenote.ItemGetText, "black");
                        }
                        TextLine("(Press Any Key to Continue)", "white");
                        ReadKey();
                    }
                }
            }
            else
            {
                PlayerHasKey = false;
            }

            return PlayerHasKey;
        }
        public void InArea(AreaOfInterest area)
        {
            PlayerCommentsWhereIsEveryone++;
            bool MenuOn = true;

            while (MenuOn == true)
            {
                BackgroundColor = ConsoleColor.Blue;
                int randomindex = 0;
                Clear();
                TextLine("You arrive at: ", "green");
                Text($"{area.Name}!\n", "black");
                string prompt = $"You arrive at: {area.Name}! \nWhat do you want to do here?";
                if (PlayerCommentsWhereIsEveryone == 1)
                {
                    prompt = $"You arrive at: {area.Name} \n\"Where is everyone?\", you ask your self. \nWhat do you want to do here?";
                }
                else if (PlayerCommentsWhereIsEveryone == 2)
                {
                    prompt = $"You arrive at: {area.Name} \nNo one is here either. You wonder what could have happened to every one. \nWhat do you want to do here?";
                }
                else
                {
                    prompt = $"You arrive at: {area.Name} \nYou get the feeling that you should find a way out of here if there really is no sign of life any where. \nWhat do you want to do here?";
                }
                string[] options = { $"Explore {area.Name}", "Check your Inventory", "Leave Area" };
                //Each if (Player.x == 1 and Player.y == 1) statements check if the player's submarine/character(O) is at the secret location (the Sea Gate), if they are, the option strings are changed and the first option transitions the player out of the game to end the game. The Sea Gate is ultimately the end-game area.
                if (Player.x == 1 && Player.y == 1)
                {
                    options = new string[] { "Leave this world for good", "View Inventory", "Leave Gate for now" };
                }
                if (area.AvailableItems == null)
                {
                    TextLine("There's nothing to search around here.", "black");
                }
                MenuSystem InAreamenu = new MenuSystem(prompt, options);
                int userInput = InAreamenu.Run("black");
                switch(userInput)
                {

                    case 0:
                        if (Player.x == 1 && Player.y == 1)
                        {
                            Clear();
                            int index = 0;
                            while (index != area.Dialogue.Count)
                            {
                                TextLine(area.Dialogue[index], "black", 2000);
                                index++;
                            }
                            TextLine("The End. \nPress Any Key to End the Game", "green");
                            ReadKey();
                            Win = true;
                            EndGame();
                        }
                        else
                        {
                            Random random = new Random();
                            randomindex = random.Next(0, area.Dialogue.Count);

                            foreach (Item item in area.AvailableItems)
                            {
                                if (randomindex == area.Dialogue.Count - 1)
                                {
                                    if (!Player.Inventory.Contains(item))
                                    {
                                        Player.PickUpItem(item);
                                        TextLine("\n" + area.Dialogue[randomindex], "black", 1000);
                                        TextLine(item.ItemGetText, "white");
                                    }
                                    else
                                    {
                                        randomindex--;
                                        TextLine("\n" + area.Dialogue[randomindex], "black", 500);
                                    }
                                }
                                else
                                {
                                    TextLine("\n" + area.Dialogue[randomindex], "black", 500);
                                }
                                if (Player.Inventory.Contains(item))
                                {
                                    TextLine("There's nothing to search for here any more.", "yellow");
                                }
                            }
                            TextLine("Press Any Key to Continue");
                            ReadKey();
                            HowMuchYouExplored++;
                        }
                        break;
                    case 1:
                        Player.ShowInventory();
                        break;
                    case 2:
                        MenuOn = false;
                        break;
                    default:
                        TextLine("Please choose a valid number", "black");
                        break;
                }
            }
            Explore();
        }
        public void ShowMenu()
        {
            BackgroundColor = ConsoleColor.Blue;
            Clear();
            CursorVisible = true;
            string prompt = "Here are your options:";
            string[] options = { "Explore", "Check your Inventory", "Exit Game" };
            MenuSystem pausemenu = new MenuSystem(prompt, options);
            int userInput = pausemenu.Run("black");

            switch (userInput)
            {
                case 0:
                    Explore();
                    break;
                case 1:
                    Player.ShowInventory();
                    ShowMenu();
                    break;
                case 2:
                    CursorVisible = false;
                    EndGame();
                    break;
            }
            //Clear();

            //Checking to see if player entered the correct input.
            //if (userInput.Key == ConsoleKey.D1 || userInput.Key == ConsoleKey.NumPad1)
            //{
            //    Explore();
            //}
            //else if (userInput.Key == ConsoleKey.D2 || userInput.Key == ConsoleKey.NumPad2)
            //{
            //    Player.ShowInventory();
            //    ShowMenu();
            //}
            //else if (userInput.Key == ConsoleKey.D3 || userInput.Key == ConsoleKey.NumPad3)
            //{
            //CursorVisible = false;
            //EndGame();
            //}
            //else
            //{
            //    WriteLine("Please choose a valid option");
            //    ShowMenu();
            //}

        }
    }
}
