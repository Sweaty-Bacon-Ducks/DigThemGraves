using System.Collections.Generic;

namespace DigThemGraves
{
	public interface IGraveyard
	{
		List<IBuildSlot> BuildSlots { get; }
	}
}
