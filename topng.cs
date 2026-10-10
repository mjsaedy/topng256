using System;
using System.Drawing;
using System.Drawing.Drawing2D;
using System.Drawing.Imaging;
using System.IO;
using System.Collections.Generic;
using System.Text;

namespace MdsyApps {

    class MdsyConsoleApp {
        
        public static void Main(string[] args) {
            if (args.Length < 2 ) {
                Console.WriteLine("\n\tUsage: topng.exe <input> <output>");
                return;
            }

            string inputFile = args[0];
            string outputFile = args[1];
            Console.WriteLine($"input file: {inputFile}");
            Console.WriteLine($"output file: {outputFile}");

             //change as needed
            //int value = int.TryParse(args[2], out int result) ? result : 128;
            //float value = float.TryParse(args[2], out float result) ? result : 0.8f;
            //Console.WriteLine($"numeric value: {value}");

            var source = new Bitmap(inputFile);
            var target = (source); //do something
            
            //target.Save(outputFile, ImageFormat.Gif);
            target.Save(outputFile, ImageFormat.Png);
            //target.Save(outputFile, ImageFormat.Jpeg);

            return;
        }



    } //class

} //namespace

