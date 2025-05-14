using System;

namespace POE_PART_2_CHATBOT
{
    internal class User_Interface
    {
        private string name;
        backendForAll search;

        // Constructor to initialize user interaction
        public User_Interface(string name)
        {
            this.name = name;
            search = new backendForAll(name); // Pass name to backendForAll

            Console.ForegroundColor = ConsoleColor.Blue;
            Console.Write("ChatBot :> ");
            Console.ForegroundColor = ConsoleColor.White;
            // Display welcome message
            Console.WriteLine($"Hello {name}, I'm here to help with cybersecurity related questions. Feel free to ask me anything related to cybersecurity, or type 'exit' to close the chat.");
            // Prompt user for input    
            string options = string.Empty;
            do
            {
                Console.ForegroundColor = ConsoleColor.Green;
                Console.Write($"{name} :> ");
                Console.ForegroundColor = ConsoleColor.White;
                options = Console.ReadLine();
                // Check if the user wants to exit
                if (options.ToLower().Equals("exit"))
                {
                    search.goodbye(this.name);
                }
                else
                {
                    search.searching(options.ToLower());
                }
            } while (options.ToLower() != "exit");
        }
    }
}