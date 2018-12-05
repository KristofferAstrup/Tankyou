using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Assets.Libraries
{
    public class ResourceLibrary<U>: ILibrary<string, U> where U : Object
    {
        private readonly Dictionary<string, U> _resources;

        public ResourceLibrary(string path)
        {
            _resources = new Dictionary<string, U>();

            foreach (var res in Resources.LoadAll(path))
            {
                if (res.GetType() != typeof(U)) continue;
                var typedRes = (U)res;
                _resources.Add(typedRes.name, typedRes);
            }
        }

        public U Get(string name)
        {
            return _resources[name];
        }

    }
}
