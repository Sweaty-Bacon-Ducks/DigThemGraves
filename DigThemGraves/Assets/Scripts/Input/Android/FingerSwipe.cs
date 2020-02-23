using UnityEngine;

namespace DigThemGraves
{
    class FingerSwipe : UserSwipe
    {
        public override SwipeData Swipe
        {
            get
            {
                if (Input.touchCount > 0 && Input.GetTouch(0).phase == TouchPhase.Moved)
                {
                    var swipeDirection = Input.GetTouch(0).deltaPosition.normalized;
                    return new SwipeData(swipeDirection, true);
                }
                return SwipeData.NullSwipe();
            }
        }
    }
}
