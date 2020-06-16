using UnityEngine;

public class ItemInstance
{
	public string Name;
	public Sprite Sprite;
	public float Cost;

	public ItemTemplate template;

	public ItemInstance(ItemTemplate itemTemplate)
	{
		this.template = itemTemplate;

		this.Name = itemTemplate.Name;
		this.Sprite = itemTemplate.Sprite;
		this.Cost = itemTemplate.Cost;
	}

	public void ReturnToDefaults()
	{
		this.Name = template.Name;
		this.Sprite = template.Sprite;
		this.Cost = template.Cost;
	}
}
