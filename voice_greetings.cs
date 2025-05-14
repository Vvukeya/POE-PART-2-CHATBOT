using System;
using System.IO;
using System.Media;

namespace POE_PART_2_CHATBOT
{
    public class voice_greetings
    {
        // Constructor to play a greeting sound
        public voice_greetings()
        {
            // Get the full path of the sound file
            string full_location = AppDomain.CurrentDomain.BaseDirectory;
            // Replace "bin\\Debug\\" with an empty string to get the correct path
            string new_location = full_location.Replace("bin\\Debug\\", "");
            // Combine the new location with the sound file name
            string full_path = Path.Combine(new_location, "voice_greetings.wav");
            // Check if the file exists
            try
            {
                using (SoundPlayer player = new SoundPlayer(full_path))
                {
                    player.PlaySync();
                }
            }
            catch (Exception error)
            {
                Console.WriteLine(error.Message);
            }
        }
    }
}