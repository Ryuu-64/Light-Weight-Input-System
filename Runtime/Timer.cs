using System;
using UnityEngine;
using Object = UnityEngine.Object;

// ReSharper disable UnusedMethodReturnValue.Global
// ReSharper disable UnusedMember.Global
// ReSharper disable MemberCanBePrivate.Global
// ReSharper disable ParameterHidesMember

namespace Ryuu.LightWeightInputSystem
{
    public class Timer : IDisposable, IUpdate
    {
        public enum UpdateMode
        {
            FixedUpdate,
            Update,
        }

        private UpdateMode updateMode;
        private float timeSet;
        private float countDown;
        public Updater Updater { get; set; }
        private readonly Action onUpdate;
        private readonly Action onFixedUpdate;
        private Action onStop;
        public bool IsStop { get; private set; }
        public bool IsSetStop { get; private set; }

        public Timer(UpdateMode updateMode, Action onStop = null, Updater updater = null)
        {
            this.updateMode = updateMode;
            Updater = updater == null ? Object.FindObjectOfType<Updater>() : updater;
            this.onStop = onStop;
            onUpdate = () =>
            {
                if (IsStop || updateMode != UpdateMode.Update)
                {
                    return;
                }

                countDown -= Time.deltaTime;

                if (countDown > 0)
                {
                    return;
                }

                this.onStop?.Invoke();

                IsStop = true;
            };

            onFixedUpdate = () =>
            {
                if (IsStop || updateMode != UpdateMode.FixedUpdate)
                {
                    return;
                }

                countDown -= Time.fixedDeltaTime;

                if (countDown > 0)
                {
                    return;
                }

                this.onStop?.Invoke();

                IsStop = true;
            };
            Subscribe();
        }

        public Timer SetUpdateMode(UpdateMode updateMode)
        {
            this.updateMode = updateMode;
            Subscribe();
            return this;
        }

        public Timer SetOnStop(Action onStop)
        {
            this.onStop = onStop;
            Subscribe();
            return this;
        }

        public Timer Subscribe()
        {
            Unsubscribe();
            switch (updateMode)
            {
                case UpdateMode.FixedUpdate:
                    Updater.OnFixedUpdate += onFixedUpdate;
                    break;
                case UpdateMode.Update:
                    Updater.OnUpdate += onUpdate;
                    break;
                default:
                    throw new ArgumentOutOfRangeException();
            }

            return this;
        }

        public Timer Unsubscribe()
        {
            if (Updater == null)
            {
                return this;
            }

            Updater.OnUpdate -= onUpdate;
            Updater.OnFixedUpdate -= onFixedUpdate;

            return this;
        }

        public Timer SetTime(float timeSet)
        {
            this.timeSet = timeSet;
            return this;
        }

        public Timer SetCountDown()
        {
            countDown = timeSet;
            return this;
        }

        public Timer Start()
        {
            IsStop = false;
            IsSetStop = false;
            return this;
        }

        public Timer Stop()
        {
            IsStop = true;
            IsSetStop = true;
            return this;
        }

        public void Dispose() => Unsubscribe();
    }
}