using System.Collections.Generic;

namespace DigThemGraves
{
	public interface IActions
	{
		Dictionary<string, IAction> Actions { get; }
		void ExecuteActionWithName(string names);
	}
}
