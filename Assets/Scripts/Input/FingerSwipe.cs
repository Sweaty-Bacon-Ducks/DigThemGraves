using UnityEngine;

namespace DigThemGraves
{
    class FingerSwipe : UserSwipe
    {
        private Vector2 touchPositionChange;
        public override SwipeData Swipe
        {
            get
            {
                if (UserHasTappedTheScreenOnce)
                {
                    touchPositionChange = LastTouchPositionDifference;
                    return new SwipeData(SwipeDirection, HasUserSwiped);
                }
                return SwipeData.NullSwipe();
            }
        }

        private bool UserHasTappedTheScreenOnce
        {
            get => Input.touches.Length == 1;
        }

        private Vector2 LastTouchPositionDifference
        {
            get => Input.GetTouch(0).deltaPosition;
        }

        private Vector2 SwipeDirection
        {
            get => Input.GetTouch(0).deltaPosition.normalized;
        }

        private bool HasUserSwiped
        {
            get => touchPositionChange.magnitude >= 0;
        }
    }
}
