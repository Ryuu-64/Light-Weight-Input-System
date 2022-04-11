using UnityEngine;

// ReSharper disable FieldCanBeMadeReadOnly.Global
// ReSharper disable ClassNeverInstantiated.Global

namespace Ryuu.LightWeightInputSystem
{
    public class InputData
    {
        public KeyCode KeyCode;
        public InputType InputType;

        public InputData(KeyCode keyCode)
        {
            KeyCode = keyCode;
            InputType = InputType.None;
        }

        public InputData(KeyCode keyCode, InputType inputType)
        {
            KeyCode = keyCode;
            InputType = inputType;
        }
    }
}