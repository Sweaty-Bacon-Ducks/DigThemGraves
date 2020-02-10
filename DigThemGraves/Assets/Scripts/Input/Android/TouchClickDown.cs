using UnityEngine;

namespace DigThemGraves
{
	public class TouchClickDown : InputClickDown
	{
		public override ClickData ClickInformation
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
