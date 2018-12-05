using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Inputs
{
    public class InputContainer
    {
        public InputFetcher InputFetcher { get; set; }
        public Dictionary<PlayerType, PlayerInput> PlayerInputs { get; set; }

        public InputContainer Init()
        {
            foreach(var pair in PlayerInputs)
            {
                PlayerInputs[pair.Key].ButtonClick = (PlayerInputType inputType) => ButtonClick(pair.Key, inputType);
                PlayerInputs[pair.Key].ButtonDown = (PlayerInputType inputType) => ButtonDown(pair.Key, inputType);
                PlayerInputs[pair.Key].ButtonUp = (PlayerInputType inputType) => ButtonUp(pair.Key, inputType);
            }

            return this;
        }

        public bool ButtonClick(PlayerType playerType, PlayerInputType inputType)
        {
            return InputFetcher.ButtonClick(PlayerInputs[playerType].KeyMaps[inputType]);
        }

        public bool ButtonDown(PlayerType playerType, PlayerInputType inputType)
        {
            return InputFetcher.ButtonDown(PlayerInputs[playerType].KeyMaps[inputType]);
        }

        public bool ButtonUp(PlayerType playerType, PlayerInputType inputType)
        {
            return InputFetcher.ButtonUp(PlayerInputs[playerType].KeyMaps[inputType]);
        }
    }

    public enum PlayerType
    {
        Player1,
        Player2
    }
}
