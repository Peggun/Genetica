﻿using Algorithmia.Core.Interfaces;
using Algorithmia.Core.Algorithms.Noise;

namespace Algorithmia.Core.Factories
{
    /// <summary>
    /// Factory for creating noise generator instances based on the noise type.
    /// </summary>
    public static class NoiseGeneratorFactory
    {
        public static INoiseGenerator CreateNoiseGenerator(FastNoiseLite.NoiseType type) =>
            type switch
            {
                FastNoiseLite.NoiseType.Perlin => new PerlinNoise(),
                _ => throw new ArgumentException($"Unsupported noise type: {type}", nameof(type))
            };
    }
}
