using UnityEngine;

namespace DigThemGraves
{
    public abstract class ScriptablePlayerAction : ScriptableObject, IPlayerAction
    {
        public abstract void Execute(IPlayer actionContext);
    }
}

