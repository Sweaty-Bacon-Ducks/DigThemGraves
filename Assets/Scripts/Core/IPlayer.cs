namespace DigThemGraves
{
    public interface IPlayer
    {
         PlayerActions AvailableActions { get; }
         void ExecuteAllActions();
    }
}