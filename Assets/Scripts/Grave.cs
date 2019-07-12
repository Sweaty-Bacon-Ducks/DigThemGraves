using UnityEngine;

namespace DigThemGraves
{
	public abstract class Grave : MonoBehaviour, 
								  IGrave,
								  IBuildable
	{
		public abstract IGraveActions AvailableActions { get; }
		public abstract IGraveHealth Health { get; }
        public abstract IBuildSlot OccupiedSlot { get; set; }

        public abstract IBuildSlot TargetedBuildSlot { get; set; }

        public abstract void Build();
	}
}
