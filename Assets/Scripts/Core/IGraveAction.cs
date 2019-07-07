namespace DigThemGraves
{
	public interface IGraveAction
	{
		string Name { get; }
		void Execute(IGrave graveContext);
	}
}
