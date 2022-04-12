using UnityEngine;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Ryuu.LightWeightInputSystem
{
    public class InputData
    {
        public KeyCode KeyCode;
        public InputType InputType;

        public InputData(KeyCode keyCode, InputType inputType = InputType.None)
        {
            KeyCode = keyCode;
            InputType = inputType;
        }
    }
}