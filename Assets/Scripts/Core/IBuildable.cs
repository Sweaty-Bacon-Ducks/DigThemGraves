namespace DigThemGraves
{
    public interface IBuildable
	{
        IActions AvailableActions { get; }
        IBuildSlot OccupiedSlot { get; set; }
        BuildSlot TargetedBuildSlot { get; set; }
        void Build();
    }
}
