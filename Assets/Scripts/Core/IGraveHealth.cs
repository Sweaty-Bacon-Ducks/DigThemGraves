namespace DigThemGraves
{
	public interface IGraveHealth
	{
		int MaxHealthValue { get; }
		int HealthValue { get; }
		void Damage(int amount);
		void Heal(int amount);
	}
}
