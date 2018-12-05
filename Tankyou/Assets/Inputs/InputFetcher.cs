using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Inputs
{
    public class InputFetcher
    {
        public Vector3 Mouse_Pos { get; private set; }
        public bool Mouse_Moved { get; private set; }

        public Dictionary<KeyCode, ButtonInput> Buttons { get; private set; }

        public InputFetcher()
        {
            Init();
        }

        public void Init()
        {
            Buttons = new Dictionary<KeyCode, ButtonInput>();
            var buttonTypes = Enum.GetValues(typeof(KeyCode));
            foreach (KeyCode buttonType in buttonTypes)
            {
                Buttons[buttonType] = new ButtonInput();
            }
        }

        public void Update()
        {
            if (Buttons == null) Init();
            Refresh();

            if (Input.mousePosition != Mouse_Pos)
            {
                Mouse_Moved = true;
                Mouse_Pos = Input.mousePosition;
            }

            var buttonTypes = Enum.GetValues(typeof(KeyCode));
            foreach (KeyCode buttonType in buttonTypes)
            {
                Buttons[buttonType].Click = Input.GetKey(buttonType);
                Buttons[buttonType].Down = Input.GetKeyDown(buttonType);
                Buttons[buttonType].Up = Input.GetKeyUp(buttonType);
            }

        }

        public bool ButtonClick(KeyCode type)
        {
            return Buttons[type].Click;
        }

        public bool ButtonDown(KeyCode type)
        {
            return Buttons[type].Down;
        }

        public bool ButtonUp(KeyCode type)
        {
            return Buttons[type].Up;
        }

        private void Refresh()
        {
            Mouse_Moved = false;
        }

    }
}
