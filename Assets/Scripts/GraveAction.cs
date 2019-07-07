using UnityEngine;

namespace DigThemGraves
{
	public abstract class GraveAction : ScriptableObject, IGraveAction
	{
		public abstract string Name { get; }

		public abstract void Execute(IGrave graveContext);
	}
}
