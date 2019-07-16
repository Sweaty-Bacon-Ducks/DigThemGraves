using UnityEngine;

namespace DigThemGraves
{
	public abstract class GraveAction : ScriptableObject, IAction<IGrave>
	{
		public abstract string Name { get; }

        public abstract void Execute(IGrave graveContext);
    }
}
