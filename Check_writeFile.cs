using System;
using System.Collections.Generic;
using System.IO;

namespace POE_PART_2_CHATBOT
{
    public class Check_writeFile
    {
        // Return the path for the memory file
        private string path_return()
        {
            string fullpath = AppDomain.CurrentDomain.BaseDirectory;
            string new_path = fullpath.Replace("bin\\Debug\\", "");
            string path = Path.Combine(new_path, "memory.txt");
            return path;
        }
        // Return the path for the memory file
        // Check if the memory file exists, create it if not
        public void check_file()
        {
            string path = path_return();
            if (!File.Exists(path))
            {
                File.CreateText(path);
            }
            else
            {
                Console.WriteLine("File is found...");
            }
        }

        // Return the contents of the memory file
        public List<string> return_memory()
        {
            string path = path_return();
            return new List<string>(File.ReadAllLines(path));
        }

        // Save data to the memory file
        public void save_memory(List<string> save_new)
        {
            string path = path_return();
            File.WriteAllLines(path, save_new);
        }
    }
}
