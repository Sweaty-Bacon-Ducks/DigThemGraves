using UnityEngine;

namespace DigThemGraves
{
	public class TouchClick : InputClick
	{
		public override ClickData ClickPoint
		{
			get
			{
				var clickData = ClickData.EmptyClick();

				if (UserHasTappedTheScreenOnce)
				{
					var touch = UsersFirstTouch;

					clickData.Clicked = true;
					clickData.OnScreenClickPoint = touch.position;
				}
				return clickData;
			}
		}

		private bool UserHasTappedTheScreenOnce
		{
			get => Input.touches.Length == 1;
		}

		private Touch UsersFirstTouch { get => Input.GetTouch(0); }
	}
}
