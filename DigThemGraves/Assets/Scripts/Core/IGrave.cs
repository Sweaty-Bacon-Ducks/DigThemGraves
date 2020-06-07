namespace DigThemGraves
{
    public interface IGrave
    {
        uint Level { get; }
        void Upgrade(); // Consider using a list of actions
        void BuildGraveWithLevel(uint level);
    }
}
