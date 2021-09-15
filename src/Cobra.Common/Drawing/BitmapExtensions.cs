using System;
using System.Collections.Generic;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;
using System.Linq;

namespace Cobra.Common.Drawing;

public static class BitmapExtensions
{
    public static List<Bitmap> ConvertUrlsToBitmaps(this string folderPath, ImageFormat imageFormat)
    {
        List<Bitmap> bitmapList = new();
        var imagesFromFolder = Directory.GetFiles(folderPath, "*." + imageFormat, SearchOption.AllDirectories).ToList();
        // Loop Files
        foreach (string imgPath in imagesFromFolder)
        {
            try
            {
                var bmp = (Bitmap)Image.FromFile(imgPath);
                bitmapList.Add(bmp);
            }
            catch (Exception ex)
            {
                Console.Write(ex.Message);
            }
        }
        return bitmapList;
    }

    public static Bitmap Merge(this List<Bitmap> images)
    {
        var width = 0;
        var height = 0;
        // Get max width and height of the image
        foreach (var image in images)
        {
            width = image.Width > width ? image.Width : width;
            height = image.Height > height ? image.Height : height;
        }
        // merge images
        var bitmap = new Bitmap(width, height);
        using (var g = Graphics.FromImage(bitmap))
        {
            foreach (var image in images)
            {
                g.DrawImage(image, 0, 0);
            }
        }
        return bitmap;
    }
}