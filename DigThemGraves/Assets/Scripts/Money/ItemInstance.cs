using System;
using UnityEngine;

namespace DigThemGraves
{
	[Serializable]
	public class ItemInstance
	{
		public string Name;
		public Sprite Sprite;
		public float Cost;

		public ItemTemplate template;

		public ItemInstance(ItemTemplate itemTemplate)
		{
			template = itemTemplate;

			Name = itemTemplate.Name;
			Sprite = itemTemplate.Sprite;
			Cost = itemTemplate.Cost;
		}

		public void ReturnToDefaults()
		{
			Name = template.Name;
			Sprite = template.Sprite;
			Cost = template.Cost;
		}
	}
}