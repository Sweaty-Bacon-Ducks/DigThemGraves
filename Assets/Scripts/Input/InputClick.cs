using UnityEngine;

namespace DigThemGraves
{
	public struct ClickData
	{
		public Vector2 OnScreenClickPoint;
		public bool Clicked;

		private static ClickData EMPTY_CLICK;

		public ClickData(Vector2 clickPoint, bool clicked)
		{
			OnScreenClickPoint = clickPoint;
			Clicked = clicked;
		}

		public static ClickData EmptyClick()
		{
			return EMPTY_CLICK;
		}
	}
	public abstract class InputClick
	{
		public abstract ClickData ClickPoint { get; }

		public static InputClick Create()
		{
#if UNITY_ANDROID
			return new TouchClick();
#endif
#if UNITY_EDITOR
			return new MouseClick();
#else
           throw new PlatformNotSupportedException;
#endif
		}
	}
}