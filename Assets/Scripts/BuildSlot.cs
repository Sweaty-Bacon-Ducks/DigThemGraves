using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
	public abstract class BuildSlot : MonoBehaviour, IBuildSlot
	{
		public abstract IBuildable Occupant { get; }

        public abstract List<IBuildable> PossibleBuildables { get; }
    }
}
