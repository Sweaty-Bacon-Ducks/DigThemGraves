using UnityEngine;

namespace DigThemGraves
{
	public abstract class Grave : MonoBehaviour, 
								  IGrave,
								  IBuildable
	{
		public abstract IGraveActions AvailableActions { get; }
		public abstract IGraveHealth Health { get; }
		public abstract void Build();
	}
}
