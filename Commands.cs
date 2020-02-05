using System;

namespace Commands
{
    delegate void Result();
    class Command
    {
        string name;
        string description;
        Result result; //The method to do once the command is run.

        public Command(string name, string description, Action result)
        {
            this.name = name;
            this.description = description;
            this.result = new Result(result); //Make a delegate for the command itself
        }

        public string GetName()
        {
            return this.name;
        }

        public string GetDescription()
        {
            return this.description;
        }

        public void Execute()
        {
            this.result();
        }
    }
}