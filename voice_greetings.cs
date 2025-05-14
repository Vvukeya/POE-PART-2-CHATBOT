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
            string full_location = AppDomain.CurrentDomain.BaseDirectory;
            string new_location = full_location.Replace("bin\\Debug\\", "");
            string full_path = Path.Combine(new_location, "voice_greetings.wav");

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