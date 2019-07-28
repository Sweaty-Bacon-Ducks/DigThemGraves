using UnityEngine;

namespace DigThemGraves
{
	public abstract class Action : IAction
	{
		public abstract string Name { get; }

        public abstract bool IsFinished { get; set; }

        public abstract void Execute(GameObject target);
    }
}
