using UnityEngine;

namespace DigThemGraves
{
    public abstract class ScriptablePlayerAction : ScriptableObject, IPlayerAction
    {
		public abstract bool IsFinished { get; set; }

        public abstract Sprite Sprite { get; set; }

        public abstract void Cancel();

        public abstract void Execute();
	}
}

