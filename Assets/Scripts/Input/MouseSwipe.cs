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
                if (UserPressedLeftMouseButton)
                    lastClick = Input.mousePosition;

                return UserHoldsLeftMouseButton ? 
                    new SwipeData(SwipeDirection,
                                  HasMousePositionChanged) : SwipeData.NullSwipe();
            }
        }

        private bool UserPressedLeftMouseButton
        {
            get => Input.GetMouseButtonDown(LEFT_MOUSE_BUTTON);
        }

        private bool UserHoldsLeftMouseButton
        {
            get => Input.GetMouseButton(LEFT_MOUSE_BUTTON);
        }

        private Vector3 SwipeDirection
        {
            get => (Input.mousePosition - lastClick).normalized;
        }

        private bool HasMousePositionChanged
        {
            get
            {
                Vector3 currentMousePosition = Input.mousePosition;
                if ((lastClick - currentMousePosition).magnitude < DEADZONE)
                {
                    return false;
                }
                return true;
            }
        }
    }
}
