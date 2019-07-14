using System.Collections.Generic;

namespace DigThemGraves
{
	public interface IActions
	{
		Dictionary<string, IBuildAction> Actions { get; }
		void ExecuteActionWithName(string name);
	}
}
