using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace Ryuu.LightWeightInputSystem
{
    public class Combination : IBoolAndValue
    {
        public Updater Updater { get; set; }
        public Action OnActive { get; set; }
        [SerializeField] public bool Bool { get; set; }
        [SerializeField] public float Value { get; set; }

        public Combination(IReadOnlyCollection<IBool> list, Updater updater = null)
        {
            Updater = updater == null ? UnityEngine.Object.FindObjectOfType<Updater>() : updater;
            Updater.OnUpdate += () =>
            {
                int count = list.Count(@bool => @bool.Bool);

                if (count == list.Count)
                {
                    Bool = true;
                    OnActive?.Invoke();
                }
                else
                {
                    Bool = false;
                }
            };
        }
    }
}