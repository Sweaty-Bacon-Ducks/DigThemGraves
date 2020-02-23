namespace DigThemGraves
{
    public interface IBuildable
	{
        IActions AvailableActions { get; }
        BuildSlot OccupiedSlot { get; set; }
        void Build();
    }
}
