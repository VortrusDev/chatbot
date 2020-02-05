using System;
using System.Collections.Generic;
using Commands;
namespace Chatbot
{
    class Program
    {

        const string name = "Rebecca";
        const ConsoleColor BotColor = ConsoleColor.Cyan;
        const ConsoleColor InputColor = ConsoleColor.DarkMagenta;
        string[] Jokes = new string[2]{"You don't need a parachute to go skydiving.\nYou need a parachute to go skydiving twice.",
                                       "I broke my finger last week.\nOn the other hand, I'm okay."};
        Command[] Commands; //Set in Main 

        static void Main(string[] args)
        {

            Program bot = new Program();

            bot.Commands = new Command[]
            {
                //Adding commands to run
                new Command("quit", "Quits the program.", new Action(bot.Quit)),
                new Command("help", "Displays all keywords and their uses.", new Action(bot.DisplayHelp)),
                new Command("joke", "Tells a joke!", new Action(bot.Joke))
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
            response.ToLower(); //Make the reply lowercase to be easy to parse.

            for (int i = 0; i < Commands.Length; i++)
            {
                if (response == Commands[i].GetName())
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
                Console.WriteLine("    {0} - {1}", c.GetName(), c.GetDescription());
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
    }
}
