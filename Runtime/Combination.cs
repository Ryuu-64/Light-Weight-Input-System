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
        public Action OnInActive { get; set; }
        [SerializeField] public bool Bool { get; set; }
        [SerializeField] public float Value { get; set; }

        public Combination(IReadOnlyCollection<InputData> list, Updater updater = null)
        {
            Updater = updater == null ? UnityEngine.Object.FindObjectOfType<Updater>() : updater;
            Updater.OnUpdate += () =>
            {
                int count = list.Count(data => LWIS.Input(data.KeyCode, InputType.Down) || LWIS.Input(data.KeyCode, InputType.Hold));

                if (count == list.Count)
                {
                    Bool = true;
                    OnActive?.Invoke();
                }
                else
                {
                    Bool = false;
                    OnInActive?.Invoke();
                }
            };
        }
    }
}