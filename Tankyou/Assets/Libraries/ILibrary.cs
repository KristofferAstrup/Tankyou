using System.Collections.Generic;
using UnityEngine;
using System.Collections;

namespace Assets.Libraries
{
    public interface ILibrary<T, U>
    {
        U Get(T name);
    }
}
