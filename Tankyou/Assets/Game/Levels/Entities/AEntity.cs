using States;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using UnityEngine;

namespace Assets.Game.Levels.Entities
{
    public abstract class AEntity : IUpdate
    {
        
        public readonly GameObject GameObject;

        public AEntity(GameObject gameObject)
        {
            GameObject = gameObject;
        }

        public abstract void Update(float delta);
    }
}
