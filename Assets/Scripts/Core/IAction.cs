using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    public interface IAction<T>
    {
        void Execute(T actionContext);
    }
}