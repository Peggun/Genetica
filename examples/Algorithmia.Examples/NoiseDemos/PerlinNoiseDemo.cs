﻿using Algorithmia.Factories;
using Algorithmia.Enums;
using Algorithmia.Interfaces;
using Algorithmia.Sinks;

namespace Algorithmia.Examples.NoiseDemos.Perlin
{
    /// <summary>
    /// Demonstrates Perlin noise generation and rendering to a image file.
    /// </summary>
    public class PerlinNoiseDemo
    {
        private const int Width = 512;
        private const int Height = 512;
        private const float Scale = 0.01f;

        public static void Run()
        {
            try
            {
                var perlinNoise = NoiseGeneratorFactory.CreateNoiseGenerator(FastNoiseLite.NoiseType.Perlin);
                perlinNoise.SetSeed(1337);
                perlinNoise.SetFrequency(0.1f);

                //perlinNoise.SetOutputFileType(FileTypes.JPEG);  // For image sink

                // Generate Noise Map
                float[,] noise = perlinNoise.GenerateNoiseMap(Width, Height, Scale);

                var sinks = new ISink[]
                {
                    new ConsoleSink(),                // Output to console
                    new ImageSink(FileTypes.PNG),    // Output to an image
                    new TextFileSink(),               // Output to an text file
                    new DebugSink(),                  // Output to debug console
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