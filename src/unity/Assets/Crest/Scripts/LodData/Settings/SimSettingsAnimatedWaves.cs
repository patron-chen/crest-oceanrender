﻿// This file is subject to the MIT License as seen in the root of this folder structure (LICENSE)

using UnityEngine;

namespace Crest
{
    [CreateAssetMenu(fileName = "SimSettingsAnimatedWaves", menuName = "Crest/Animated Waves Sim Settings", order = 10000)]
    public class SimSettingsAnimatedWaves : SimSettingsBase, IReadbackSettingsProvider
    {
        [Tooltip("Read back wave shape to CPU for collision/physics."), Header("Readback to CPU")]
        public bool _readbackData = true;

        [Tooltip("Minimum floating object width. The larger the objects that will float, the lower the resolution of the read data. If an object is small, the highest resolution LODs will be sample for physics. This is an optimisation. Set to 0 to disable this optimisation and always copy high res data.")]
        public float _minObjectWidth = 0f;
        [Tooltip("Similar to the minimum width, but this setting will exclude the larger LODs from being copied. Set to 0 to disable this optimisation and always copy low res data.")]
        public float _maxObjectWidth = 0f;

        public void GetMinMaxGridSizes(out float minGridSize, out float maxGridSize)
        {
            // Wavelengths that repeat twice or more across the object are irrelevant and don't need to be read back.
            minGridSize = 0.5f * _minObjectWidth / OceanRenderer.Instance._minTexelsPerWave;
            maxGridSize = 0.5f * _maxObjectWidth / OceanRenderer.Instance._minTexelsPerWave;
        }
    }
}