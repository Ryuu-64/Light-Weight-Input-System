using System;

namespace Ryuu.LightWeightInputSystem
{
    public class BoolAndValue : IBoolAndValue
    {
        public Updater Updater { get; set; }
        public Action OnActive { get; set; }
        public Action OnInActive { get; set; }
        public bool Bool { get; set; }
        public float Value { get; set; }
    }
}