namespace DigThemGraves
{
	public interface IBuildAction
	{
		string Name { get; }
		void Execute(IBuildable buildable);
	}
}
