namespace DigThemGraves
{
	public interface IHealth
	{
		int MaxHealthValue { get; }
		int HealthValue { get; }
		void Damage(int amount);
		void Heal(int amount);
	}
}
