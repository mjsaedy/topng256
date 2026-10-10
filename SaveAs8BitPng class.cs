using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

public static class ImageHelper
{
    /// <summary>
    /// Saves an image as an 8-bit (256-color) indexed PNG using GDI+'s GIF encoder as an intermediary.
    /// </summary>
    /// <param name="sourceImage">The source image to convert</param>
    /// <param name="outputPath">Where to save the 8-bit PNG</param>
    /// <param name="quality">Optional: for JPEG sources, you might load differently</param>
    public static void SaveAs8BitPng(Image sourceImage, string outputPath)
    {
        // Step 1: Save to GIF in memory (triggers GDI+ quantization)
        using (MemoryStream gifStream = new MemoryStream())
        {
            sourceImage.Save(gifStream, ImageFormat.Gif);
            
            // Step 2: Reload the GIF (now indexed)
            gifStream.Position = 0;
            using (Bitmap indexedImage = new Bitmap(gifStream))
            {
                // Step 3: Save as PNG (preserves indexed format)
                indexedImage.Save(outputPath, ImageFormat.Png);
            }
        }
    }
}

/*
//Usage

using (Bitmap photo = new Bitmap("photo.jpg"))
{
    ImageHelper.SaveAs8BitPng(photo, "photo_8bit.png");
}
*/