using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using POE_PART_2_CHATBOT;

namespace POE_PART_2_CHATBOT
{
    internal class Program
    {
        static void Main(string[] args)
        {
            new voice_greetings(); // Play greeting sound
            new logo(); // Display logo

            greeting_text text = new greeting_text();
            text.ask_name(); // Get user name

            // Start user interaction with chatbot
            new User_Interface(text.getName());
        }
    }
}
