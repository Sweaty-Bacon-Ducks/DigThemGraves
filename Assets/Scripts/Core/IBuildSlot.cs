using System.Collections.Generic;

namespace DigThemGraves
{
	public interface IBuildSlot
	{
		IBuildable Occupant { get; }

        List<Buildable> PossibleBuildables { get; }

        void OnMouseUp();
	}
}
