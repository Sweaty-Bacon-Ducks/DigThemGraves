using UnityEngine;

namespace DigThemGraves
{
    class FingerSwipe : UserSwipe
    {
        public override SwipeData Swipe
        {
            get
            {
                if (Input.touchCount == 1)
                {
                    var currentTouch = Input.GetTouch(0);
                    var positionChange = currentTouch.deltaPosition;
                    var swiped = false;
                    if (positionChange.magnitude >= 0)
                    {
                        swiped = true;
                    }
                    return new SwipeData(positionChange.normalized, swiped);
                }
                return SwipeData.NullSwipe();
            }
        }
    }
}
