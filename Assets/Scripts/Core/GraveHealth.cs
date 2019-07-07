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

		public void Damage(int ammount)
		{
			ammount = Math.Max(0, ammount);
			healthValue = Math.Max(0, healthValue - ammount);
		}

		public void Heal(int ammount)
		{
			ammount = Math.Min(maxHealthValue, ammount);
			healthValue = Math.Min(MaxHealthValue, healthValue + ammount);
		}
	}
}
