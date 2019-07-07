namespace DigThemGraves
{
	public interface IGraveHealth
	{
		int MaxHealthValue { get; }
		int HealthValue { get; }
		void Damage(int ammount);
		void Heal(int ammount);
	}
}
