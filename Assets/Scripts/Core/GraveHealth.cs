using System;
using UnityEngine;

namespace DigThemGraves
{
	[Serializable]
	public class GraveHealth : IGraveHealth
	{
		private int maxHealthValue;
		private int healthValue;
		public int HealthValue
		{
			get
			{
				return healthValue;
			}
		}

		public int MaxHealthValue { get { return maxHealthValue; } }

		public void Damage(int amount)
		{
			amount = Math.Max(0, amount);
			healthValue = Math.Max(0, healthValue - amount);
		}

		public void Heal(int amount)
		{
			amount = Math.Min(maxHealthValue, amount);
			healthValue = Math.Min(MaxHealthValue, healthValue + amount);
		}
	}
}
