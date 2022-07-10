using System;
using System.Drawing;
using System.Drawing.Imaging;

namespace ImageSave
{
    class MainClass
    { 
        public static void Main(string[] args)
        {
            //   ImageVisual($"Сласибо Ляле{Environment.NewLine}за вкусные греночки");
            Console.WriteLine(GetPercent(3000, 31000));
        }

        public static string GetPercent(double previus, double current)
        {
            double result = (previus / current) * 100;
            if (previus < current)
                return (100 - result).ToString("0.00");
            else
                return (result -= 100).ToString("0.00");
        }

        public static void ImageVisual(string text)
        {
            //first, create a dummy bitmap just to get a graphics object
            Image img = new Bitmap(10,10);
            Graphics drawing = Graphics.FromImage(img);

            //measure the string to see how big the image needs to be
            SizeF textSize = drawing.MeasureString(text, new Font("Arial", 10));

            //free up the dummy image and old graphics object
            img.Dispose();
            drawing.Dispose();

            //create a new image of the right size
            img = new Bitmap((int)textSize.Width, (int)textSize.Height);

            drawing = Graphics.FromImage(img);

            //paint the background
            drawing.Clear(Color.Black);

            //create a brush for the text
            Brush textBrush = new SolidBrush(Color.White);

            drawing.DrawString(text, new Font("Arial", 10), textBrush, 0, 0);

            drawing.Save();

            textBrush.Dispose();
            drawing.Dispose();

            img.Save(@"/Users/nikitaserduk/Desktop/111.png", ImageFormat.Png);
        }       
    }
}