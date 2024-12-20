﻿using Genetica;
using Genetica.Sinks;

namespace Genetica.Examples.NoiseDemos.Perlin
{
    /// <summary>
    /// Demonstrates Perlin noise generation and rendering to a image file.
    /// </summary>
    public class PerlinNoiseDemo
    {
        private const int Width = 16;
        private const int Height = 16;
        private const float Scale = 0.01f;

        public static void Run()
        {
            try
            {
                var perlinNoise = NoiseGeneratorFactory.CreateNoiseGenerator(NoiseType.White);
                perlinNoise.SetSeed(1337);
                perlinNoise.SetFrequency(0.1f);

                //perlinNoise.SetOutputFileType(FileTypes.JPEG);  // For image sink

                // Generate Noise Map
                float[,] noise = perlinNoise.GenerateNoiseMap(Width, Height, Scale);

                var sinks = new ISink[]
                {
                    //new ConsoleSink(),                // Output to console
                    //new ImageSink(FileTypes.PNG),     // Output to a PNG image
                    //new ImageSink(FileTypes.JPEG),    // Output to a JPEG image
                    //new TextFileSink(),               // Output to an text file
                    //new DebugSink(),                  // Output to debug console
                    //new JsonSink(),                   // Output to a JSON file
                    //new CsvSink()                     // Output to a CSV file (kinda needs fixing a little)
                };

                // Use each sink
                foreach (var sink in sinks)
                {
                    sink.Write(noise);
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Error generating noise: {ex.Message}");
            }
        }
    }
}
