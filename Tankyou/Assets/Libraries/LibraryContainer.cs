using UnityEngine;
using System.Collections;

namespace Assets.Libraries
{
    public class LibraryContainer
    {
        public ResourceLibrary<Sprite> SpriteLibrary { get; set; }

        public ResourceLibrary<GameObject> GameObjectLibrary { get; set; }

        public ResourceLibrary<AudioClip> AudioLibrary { get; set; }

        public ResourceLibrary<AnimationClip> AnimationLibrary { get; set; }
    }
}
