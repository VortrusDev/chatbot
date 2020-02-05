using System;
using System.Collections.Generic;
using Commands;
using Stories;
namespace Chatbot
{
    class Program
    {

        const string name = "Rebecca";
        const ConsoleColor BotColor = ConsoleColor.Cyan;
        const ConsoleColor InputColor = ConsoleColor.DarkMagenta;
        string[] Jokes = new string[3]{"You don't need a parachute to go skydiving.\nYou need a parachute to go skydiving twice.",
                                       "I broke my finger last week.\nOn the other hand, I'm okay.",
                                       "Did you hear the joke about the high wall?\n It was hilarious, I'm still trying to get over it!"};
        Story[] stories = new Story[1]
        {
            new Story("The Haunting of GlennDale Creek", 
                new Page[]{
                    new Page("...\"Do you really think we should be doing this?\"\n"
                           + "\"Not really, but what other choice do we have?\"\n\n"
                           + "Billy and Jamie have been arguing like this for hours.")})
        };
        
        Command[] Commands; //Set in Main 

        static void Main(string[] args)
        {

            Program bot = new Program();

            bot.Commands = new Command[]
            {
                //Adding commands to run
                new Command("quit", "Quits the program.", new Action(bot.Quit)),
                new Command("help", "Displays all keywords and their uses.", new Action(bot.DisplayHelp)),
                new Command("joke", "Tells a joke!", new Action(bot.Joke)),
                new Command("story", "Tells a story!", new Action(bot.ChooseStory))
            };

            bool exit = false; //Exits the program when true. 

            while (!exit)
            {
                bot.Greet();
                bot.TakeInput();
            }
        }

        //Greet a new user with a first-time message.
        void Greet()
        {
            Console.ForegroundColor = BotColor;
            Console.WriteLine("Hello there! I see this is your first time talking to me!");
            Console.WriteLine("Nice to meet you! My name's {0}.", name);
            Console.WriteLine("What can I do for you?");
        }

        void TakeInput()
        {
            Console.ForegroundColor = InputColor;
            string response = Console.ReadLine(); 
            response = response.ToLower(); //Make the reply lowercase to be easy to parse.

            for (int i = 0; i < Commands.Length; i++)
            {
                if (response == Commands[i].name)
                {
                    Commands[i].Execute();
                }
            }
        }

        void Quit()
        {
            Console.ForegroundColor = ConsoleColor.White;
            Environment.Exit(0);
        }

        void DisplayHelp()
        {
            Console.ForegroundColor = BotColor;
            Console.WriteLine();
            foreach(Command c in Commands)
            {
                Console.WriteLine("    {0} - {1}", c.name, c.description);
                Console.WriteLine();
            }
        }

        void Joke()
        {
            Random rand = new Random();
            int random = rand.Next(0,Jokes.Length);

            Console.ForegroundColor = BotColor;

            Console.WriteLine();

            Console.WriteLine(Jokes[random]);

            Console.WriteLine();

        }

        void ChooseStory()
        {
            Console.ForegroundColor = BotColor;
            Console.WriteLine("You got it! Which story do you want to hear? Just tell me the number, or say \"Quit\" to stop.");

            int i = 0;
            foreach(Story s in stories)
            {
                Console.WriteLine("    {0} - {1}", i, s.title);
                i++;
            }
            
            string response = "";
            bool storyChosen = false;
            while (response != "quit" && !storyChosen)
            {
                Console.ForegroundColor = InputColor;
                response = Console.ReadLine();

                int val;
                if (int.TryParse(response, out val))
                {
                    if (val < stories.Length && val >= 0)
                    {
                        //Should match a story
                        ReadStory(val);
                        storyChosen = true;
                    }
                }
            }

        }

        void ReadStory(int storyNumber)
        {
            Console.ForegroundColor = BotColor;
            Console.WriteLine("/////////////////////////////////////////");
            Console.WriteLine(stories[storyNumber].title);
        }
    }
}
