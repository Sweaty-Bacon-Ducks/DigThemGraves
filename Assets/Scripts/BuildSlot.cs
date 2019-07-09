using UnityEngine;

namespace DigThemGraves
{
	public abstract class BuildSlot : MonoBehaviour, IBuildSlot
	{
		public abstract IBuildable Occupant { get; }
	}
}
