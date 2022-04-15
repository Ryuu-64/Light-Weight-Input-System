using System;

namespace Ryuu.LightWeightInputSystem
{
    public interface IAction
    {
        public Action OnActive { get; set; }
        public Action OnInActive { get; set; }
    }
}