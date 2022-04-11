using System;
using UnityEngine;

namespace Ryuu.LightWeightInputSystem
{
    public class Updater : MonoBehaviour
    {
        public event Action OnFixedUpdate;
        public event Action OnUpdate;
        public event Action OnLateUpdate;

        private void Update() => OnUpdate?.Invoke();

        private void FixedUpdate() => OnFixedUpdate?.Invoke();

        private void LateUpdate() => OnLateUpdate?.Invoke();
    }
}