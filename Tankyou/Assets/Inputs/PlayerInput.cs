using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Inputs
{
    public class PlayerInput
    {
        public Dictionary<PlayerInputType, KeyCode> KeyMaps { get; set; }
        public Vector2 Pointer = Vector2.zero;
        public PlayerInputMechanic playerInputMechanic;

        public Func<PlayerInputType, bool> ButtonClick;
        public Func<PlayerInputType, bool> ButtonDown;
        public Func<PlayerInputType, bool> ButtonUp;
    }

    public enum PlayerInputType
    {
        PrimaryInput,
        SecondaryInput,
        TertriraryInput,

        Up_Primary,
        Left_Primary,
        Right_Primary,
        Down_Primary,
        Up_Secondary,
        Left_Secondary,
        Right_Secondary,
        Down_Secondary,

        Confirm,
        Cancel,

        Menu
    }

    public enum PlayerInputMechanic
    {
        None,
        Keyboard_And_Mouse,
        Controller
    }


}
