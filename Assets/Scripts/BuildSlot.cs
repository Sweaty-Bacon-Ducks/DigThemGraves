using UnityEngine;

namespace DigThemGraves
{
	public abstract class BuildSlot : IBuildSlot
	{
		public abstract IBuildable Occupant { get; }
	}
}
