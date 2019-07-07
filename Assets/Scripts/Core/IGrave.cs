namespace DigThemGraves
{
    public interface IGrave
    {
		IGraveActions AvailableActions { get; }
		IGraveHealth Health { get; }
    }
}
