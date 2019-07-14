using UnityEngine;

namespace DigThemGraves
{
    public abstract class Grave : Buildable, 
								  IGrave
	{
		public abstract IHealth Health { get; }
	}
}
