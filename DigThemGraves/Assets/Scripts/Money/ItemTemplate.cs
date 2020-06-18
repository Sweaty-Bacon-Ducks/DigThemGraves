using UnityEngine;

namespace DigThemGraves
{
	[CreateAssetMenu]
	public class ItemTemplate : ScriptableObject
	{
		public string Name;
		public Sprite Sprite;
		public float Cost;
	}
}