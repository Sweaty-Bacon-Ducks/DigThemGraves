using System.IO;
using UnityEditor;
using UnityEngine;

namespace DigThemGraves
{
	[CreateAssetMenu]
	public class ItemTemplate : ScriptableObject
	{
		public string Name;
		public Sprite Sprite;
		public float Cost;

		private void Awake()
		{
			if (string.IsNullOrEmpty(Name))
			{
				string assetPath = AssetDatabase.GetAssetPath(this.GetInstanceID());
				Name = Path.GetFileNameWithoutExtension(assetPath);
			}
		}
	}
}