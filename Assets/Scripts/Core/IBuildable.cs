namespace DigThemGraves
{
    public interface IBuildable
	{
        IActions AvailableActions { get; }
        IBuildSlot OccupiedSlot { get; set; }
        IBuildSlot TargetedBuildSlot { get; set; }
        void Build();
    }
}
