using System;
using UnityEngine;

// ReSharper disable Unity.RedundantAttributeOnTarget

namespace Ryuu.LightWeightInputSystem
{
    public class Input : IBoolAndValue
    {
        public Updater Updater { get; set; }
        public Action OnActive { get; set; }
        public Action OnInActive { get; set; }
        [SerializeField] public bool Bool { get; set; }
        [SerializeField] public float Value { get; set; }

        public Input(KeyCode keyCode, InputType inputType, Updater updater = null)
        {
            Updater = updater == null ? UnityEngine.Object.FindObjectOfType<Updater>() : updater;
            Updater.OnUpdate += () =>
            {
                if (LWIS.Input(keyCode, inputType))
                {
                    Bool = true;
                    Value = 1;
                    OnActive?.Invoke();
                }
                else
                {
                    Bool = false;
                    Value = 0;
                    OnInActive?.Invoke();
                }
            };
        }
    }
}