using System;
using System.Drawing;
using System.IO;
using System.Drawing.Imaging;


namespace POE_PART_2_CHATBOT
{
    public class logo
    {
        //constructor of the logo class
        public logo()
        {
            //get where the project is
            string where = AppDomain.CurrentDomain.BaseDirectory;//get the path of the project 
            string new_path = where.Replace("bin\\Debug\\", "");//remove the bin\Debug\ from the path

            string imagePath = Path.Combine(new_path, "logo3.png");//combine the path with the image name 

            if (!File.Exists(imagePath))//check if the image exists and if not throw an exception
            {
                throw new FileNotFoundException("The image file was not found.", imagePath);//if not found throw an exception
            }//end of if

            Bitmap image = new Bitmap(imagePath);//create a bitmap object from the image path
            image = new Bitmap(image, new Size(100, 75));//resize the image

            for (int y = 0; y < image.Height; y++)//loop through the image
            {
                for (int x = 0; x < image.Width; x++)
                {
                    Color pixelColor = image.GetPixel(x, y);//get the pixel color
                    int gray = (pixelColor.R + pixelColor.G + pixelColor.B) / 3;//get the gray color
                    char asciiCharm = gray > 200 ? ' ' : gray > 150 ? '.' : gray > 100 ? '*' : gray > 50 ? '#' : '@';//get the ascii character
                    Console.Write(asciiCharm);//print the ascii character
                }//end of for
                Console.WriteLine();//print a new line
            }//end of for
        }//end of constructor
    }//end of class
}
