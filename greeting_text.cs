using System;

namespace POE_PART_2_CHATBOT
{
    internal class greeting_text
    {
        private string name = string.Empty;

        public greeting_text()
        {
        }

        // Prompt user for their name
        public void ask_name()
        {
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("************************************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.WriteLine("|*|       Greetings welcome to Cybersecurity AI       |*|");
            Console.ForegroundColor = ConsoleColor.DarkBlue;
            Console.WriteLine("************************************************************");
            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("ChatBot :> ");
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine("Enter your name : ");

            Console.ForegroundColor = ConsoleColor.DarkGray;
            Console.Write("Your name :> ");
            Console.ForegroundColor = ConsoleColor.White;
            name = Console.ReadLine();
        }

        internal string getName()
        {
            return name;
        }
    }
}
