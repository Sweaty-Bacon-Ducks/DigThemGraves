using UnityEngine;

namespace DigThemGraves
{
	public abstract class GraveAction : ScriptableObject, IBuildAction
	{
		public abstract string Name { get; }

		public abstract void Execute(IBuildable buildable);
    }
}
