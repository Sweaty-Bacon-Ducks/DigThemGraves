using UnityEngine;

namespace DigThemGraves
{
    public class PinchZoom : InputZoom
    {
        private float sensitivity;

        public PinchZoom(float Sensitivity)
        {
            this.sensitivity = Sensitivity;
        }

        public override float Sensitivity => sensitivity;

        public override float ZoomValue
        {
            get
            {
                var pinchAmmount = 0.0f;
                if (Input.touchCount == 2)
                {
                    var firstTouch = Input.GetTouch(0);
                    var secondTouch = Input.GetTouch(1);

                    var firstTouchesCurrentPosition = firstTouch.position;
                    var secondTouchesCurrentPosition = secondTouch.position;

                    var firstTouchesOldPosition = firstTouch.position - firstTouch.deltaPosition;
                    var secondTouchesOldPosition = secondTouch.position - secondTouch.deltaPosition;

                    var oldMagnitude = (firstTouchesOldPosition - secondTouchesOldPosition).magnitude;
                    var currentMagnitude = (firstTouchesCurrentPosition - secondTouchesCurrentPosition).magnitude;

                    pinchAmmount = currentMagnitude - oldMagnitude;

                    return sensitivity * pinchAmmount;
                }
                return pinchAmmount;
            }
        }
    }
}