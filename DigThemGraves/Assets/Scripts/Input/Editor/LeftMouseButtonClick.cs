using UnityEngine;

namespace DigThemGraves
{
    public class LeftMouseButtonClick : InputClick
    {
        private const short LEFT_MOUSE_BUTTON = 0;
        public override ClickData ClickInformation
        {
            get
            {
                var clickData = ClickData.EmptyClick();
                if (UserHasClickedLeftMouseButton)
                {
                    clickData.Clicked = true;
                    clickData.OnScreenClickPoint = Input.mousePosition;
                }
                return clickData;
            }
        }

        private bool UserHasClickedLeftMouseButton
        {
            get => Input.GetMouseButton(LEFT_MOUSE_BUTTON);
        }
    }
}
