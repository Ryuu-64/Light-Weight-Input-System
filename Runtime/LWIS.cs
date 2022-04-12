using System;
using UnityEngine;

// ReSharper disable InconsistentNaming

namespace Ryuu.LightWeightInputSystem
{
    public static class LWIS
    {
        public static bool Input(KeyCode code, InputType type) => type switch
        {
            InputType.Down => (int) code switch
            {
                >= 0 and <= 509 => UnityEngine.Input.GetKeyDown(code),
                _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
            },
            InputType.Hold => (int) code switch
            {
                >= 0 and <= 509 => UnityEngine.Input.GetKey(code),
                _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
            },
            InputType.Up => (int) code switch
            {
                >= 0 and <= 509 => UnityEngine.Input.GetKeyUp(code),
                _ => throw new ArgumentOutOfRangeException(nameof(code), code, null)
            },
            InputType.None => throw new ArgumentOutOfRangeException(nameof(type), type, null),
            _ => throw new ArgumentOutOfRangeException(nameof(type), type, null)
        };
    }
}