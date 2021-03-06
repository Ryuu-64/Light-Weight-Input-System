using System;
using UnityEngine;

namespace Ryuu.LightWeightInputSystem
{
    public class Repetition : IBoolAndValue, ICount
    {
        public Updater Updater { get; set; }
        public Action OnActive { get; set; }
        public Action OnInActive { get; set; }
        [SerializeField] public bool Bool { get; set; }
        [SerializeField] public float Value { get; set; }
        [SerializeField] public int Count { get; set; }

        public Repetition(KeyCode keyCode, int count, Updater updater = null)
        {
            Count = count;
            var timer = new Timer(Timer.UpdateMode.Update);
            timer.SetTime(0.2f).SetCountDown().Stop();

            int tempCount = 0;

            Updater = updater == null ? UnityEngine.Object.FindObjectOfType<Updater>() : updater;

            Updater.OnUpdate += () =>
            {
                if (timer.IsStop)
                {
                    tempCount = 0;
                    Bool = false;
                    Value = 0;
                }

                if (!LWIS.Input(keyCode, InputType.Down))
                {
                    return;
                }

                if (tempCount == 0)
                {
                    timer.SetCountDown().Start();
                    tempCount++;
                }
                else if (tempCount < Count && !timer.IsStop)
                {
                    timer.SetCountDown().Start();
                    tempCount++;
                }

                if (tempCount == Count)
                {
                    tempCount = 0;
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