using System;

namespace Ryuu.LightWeightInputSystem
{
    public interface IOnActive
    {
        public Action OnActive { get; set; }
    }
}