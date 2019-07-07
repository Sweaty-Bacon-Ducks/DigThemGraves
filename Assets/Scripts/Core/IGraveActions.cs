using System.Collections.Generic;

namespace DigThemGraves
{
	public interface IGraveActions
	{
		Dictionary<string, IGraveAction> Actions { get; }
		void ExecuteActionWithName(string name);
	}
}
