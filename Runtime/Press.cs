using System;
using UnityEngine;
using Object = UnityEngine.Object;

namespace Ryuu.LightWeightInputSystem
{
    public class Press : IBoolAndValue
    {
        public Updater Updater { get; set; }
        public Action OnActive { get; set; }
        [SerializeField] public bool Bool { get; set; }
        [SerializeField] public float Value { get; set; }

        public Press(InputData inputData, Updater updater = null)
        {
            var timer = new Timer(Timer.UpdateMode.Update);
            timer.SetTime(0.15f).SetCountDown().Stop();
            Updater = updater == null ? Object.FindObjectOfType<Updater>() : updater;
            Updater.OnUpdate += () =>
            {
                if (LWIS.Input(inputData.KeyCode, InputType.Down))
                {
                    timer.SetCountDown().Start();
                }
                else if (LWIS.Input(inputData.KeyCode, InputType.Up))
                {
                    timer.Stop();
                }

                if (timer.IsStop && !timer.IsSetStop)
                {
                    Bool = true;
                    Value = 1;
                    OnActive?.Invoke();
                }
                else
                {
                    Bool = false;
                    Value = 0;
                }
            };
        }
    }
}