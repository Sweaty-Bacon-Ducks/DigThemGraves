namespace DigThemGraves
{
	public interface IBuildable
	{
		void Build();

        IBuildSlot TargetedBuildSlot { get; set; }
    }
}
