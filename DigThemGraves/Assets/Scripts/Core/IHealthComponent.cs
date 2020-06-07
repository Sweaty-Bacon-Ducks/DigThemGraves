namespace DigThemGraves
{
    public interface IHealthComponent<T>
    {
        void Damage(T amount);
        void Heal(T amount);
    }
}
