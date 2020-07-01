using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Drawing;
using System.Drawing.Imaging;
using System.Drawing.Drawing2D;
namespace Management
{
    class Watermark
    {
        public void AddWatermark(string backgroundImagePath, string watermarkPath)
        {
            System.Drawing.Image backImage = Image.FromFile(backgroundImagePath);
            System.Drawing.Image waterImage = Image.FromFile(watermarkPath);
            Graphics g = Graphics.FromImage(backImage);
            g.SmoothingMode = SmoothingMode.AntiAlias;
            g.DrawImage(waterImage, backImage.Width * 4 / 5, 10, backImage.Width/5, backImage.Height/9);
            Bitmap layoutImageToBitmap = backImage.Clone() as Bitmap;
            if (System.IO.File.Exists("5.png"))
            {
                System.IO.File.Delete("5.png");
            }
            layoutImageToBitmap.Save("5"  + ".png", ImageFormat.Png);
        }
    }
}
