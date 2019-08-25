using UnityEngine;

namespace DigThemGraves
{
    public class MouseSwipe : UserSwipe
    {
        private const short LEFT_MOUSE_BUTTON = 0;
        private const float DEADZONE = 0.05f;
        private Vector3 lastClick;
        private bool mousePositionChanged;
        public override SwipeData Swipe
        {
            get
            {
                if (Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON))
                {
                    lastClick = Input.mousePosition;
                }

                var currentMousePosition = Input.mousePosition;
                if ((lastClick - currentMousePosition).magnitude < DEADZONE)
                {
                    mousePositionChanged = false;
                }
                mousePositionChanged = true;

                if (Input.GetMouseButton(LEFT_MOUSE_BUTTON))
                {
                    var direction = (currentMousePosition - lastClick).normalized;
                    var result = new SwipeData(direction, mousePositionChanged);
                    return result;
                }
                return SwipeData.NullSwipe();
            }
        }
    }
}
