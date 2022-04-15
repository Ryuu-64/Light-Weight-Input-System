using System;

namespace Ryuu.LightWeightInputSystem
{
    public class Tap : IBoolAndValue
    {
        public Updater Updater { get; set; }
        public Action OnActive { get; set; }
        public Action OnInActive { get; set; }
        public bool Bool { get; set; }
        public float Value { get; set; }

        public Tap(InputData inputData, Updater updater = null)
        {
            var timer = new Timer(Timer.UpdateMode.Update);
            timer.SetTime(0.2f).SetCountDown().Stop();
            Updater = updater == null ? UnityEngine.Object.FindObjectOfType<Updater>() : updater;
            Updater.OnUpdate += () =>
            {
                if (timer.IsStop)
                {
                    Bool = false;
                    Value = 0;
                    OnInActive?.Invoke();
                }

                if (LWIS.Input(inputData.KeyCode, InputType.Down))
                {
                    timer.SetCountDown().Start();
                }
                else if (LWIS.Input(inputData.KeyCode, InputType.Up))
                {
                    if (!timer.IsStop)
                    {
                        Bool = true;
                        Value = 1;
                        OnActive?.Invoke();
                    }

                    timer.Stop();
                }
            };
        }
    }
}