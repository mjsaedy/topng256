using System;
using System.Drawing;
using System.Drawing.Imaging;
using System.IO;

class Program
{
    static void Main(string[] args)
    {
        try
        {
            // Check if source file is provided
            if (args.Length == 0)
            {
                Console.WriteLine("Usage: Program.exe <sourceImagePath>");
                Console.WriteLine("Example: Program.exe C:\\photos\\myphoto.jpg");
                return;
            }

            string sourcePath = args[0];
            string outputPath = Path.Combine(
                Path.GetDirectoryName(sourcePath),
                Path.GetFileNameWithoutExtension(sourcePath) + "_256.png"
            );

            Console.WriteLine($"Source: {sourcePath}");
            Console.WriteLine($"Output: {outputPath}");

            // Load the source image
            using (Bitmap sourceImage = new Bitmap(sourcePath))
            {
                Console.WriteLine($"Source format: {sourceImage.PixelFormat}");
                Console.WriteLine($"Source size: {sourceImage.Width}x{sourceImage.Height}");

                // Step 1: Save the image as GIF to a MemoryStream
                using (MemoryStream gifStream = new MemoryStream())
                {
                    // Save as GIF with default encoder
                    sourceImage.Save(gifStream, ImageFormat.Gif);
                    
                    Console.WriteLine($"GIF stream size: {gifStream.Length} bytes");

                    // Step 2: Load the GIF from the memory stream
                    gifStream.Position = 0; // Reset to beginning
                    using (Bitmap gifImage = new Bitmap(gifStream))
                    {
                        Console.WriteLine($"Loaded GIF format: {gifImage.PixelFormat}");
                        Console.WriteLine($"GIF palette size: {gifImage.Palette.Entries.Length} colors");

                        // Step 3: Save the loaded GIF as PNG
                        gifImage.Save(outputPath, ImageFormat.Png);
                    }
                }
            }

            // Step 4: Verify the output PNG
            using (Bitmap outputImage = new Bitmap(outputPath))
            {
                Console.WriteLine($"\n=== Verification ===");
                Console.WriteLine($"Output PNG format: {outputImage.PixelFormat}");
                Console.WriteLine($"Output PNG palette size: {outputImage.Palette.Entries.Length} colors");
                Console.WriteLine($"Output PNG file: {outputPath}");
            }

            Console.WriteLine("\nDone!");
        }
        catch (Exception ex)
        {
            Console.WriteLine($"Error: {ex.Message}");
            Console.WriteLine($"Stack trace: {ex.StackTrace}");
        }
    }
}