using System;

namespace Commands
{
    delegate void Result();
    class Command
    {
        public string name {get; set;}
        public string description {get; set;}
        public Result result {get; set;} //The method to do once the command is run.

        public Command(string name, string description, Action result)
        {
            this.name = name;
            this.description = description;
            this.result = new Result(result); //Make a delegate for the command itself
        }

        public void Execute()
        {
            this.result();
        }
    }
}