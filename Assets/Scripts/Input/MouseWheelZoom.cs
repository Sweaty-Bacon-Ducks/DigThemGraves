using UnityEngine;

namespace DigThemGraves
{
    public class MouseWheelZoom : InputZoom
    {
        private float sensitivity;

        public MouseWheelZoom(float Sensitivity)
        {
            this.sensitivity = Sensitivity;
        }
        public override float Sensitivity => sensitivity;
        public override float ZoomValue
        {
            get
            {
                return sensitivity * Input.mouseScrollDelta.y;
            }
        }
    }
}