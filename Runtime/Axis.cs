﻿using System;

namespace Ryuu.LightWeightInputSystem
{
    public class Axis : IBoolAndValue
    {
        public Updater Updater { get; set; }
        public Action OnActive { get; set; }
        public float Value { get; set; }
        public bool Bool { get; set; }

        public Axis(IBool negative, IBool positive, Updater updater = null)
        {
            Updater = updater == null ? UnityEngine.Object.FindObjectOfType<Updater>() : updater;
            Updater.OnUpdate += () =>
            {
                if (!(negative.Bool ^ positive.Bool))
                {
                    Value = 0;
                    Bool = false;
                }

                if (negative.Bool)
                {
                    Value = -1;
                    Bool = true;
                }

                if (positive.Bool)
                {
                    Value = 1;
                    Bool = true;
                }
            };
        }
    }
}