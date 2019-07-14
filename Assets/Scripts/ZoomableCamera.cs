using System;
using UnityEngine;

namespace DigThemGraves
{
    public abstract class InputZoom
    {
        public abstract float Sensitivity { get; }
        public abstract float ZoomValue { get; }

        public static InputZoom Create(float Sensitivity)
        {
#if UNITY_ANDROID
            return new PinchZoom(Sensitivity);
#endif
#if UNITY_IOS
            throw new PlatformNotSupportedException("Current build target: IOS");
#else
            return new MouseWheelZoom(Sensitivity);
#endif
        }
    }

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

    [Serializable]
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

    [RequireComponent(typeof(Camera))]
    public class ZoomableCamera : MonoBehaviour
    {
        private Camera targetCamera;
        private InputZoom zoomGesture;

        [SerializeField]
        private float minZoom;
        [SerializeField]
        private float maxZoom;
        [SerializeField]
        private float sensitivity;

        public float MinZoom => minZoom;
        public float MaxZoom => maxZoom;
        public float Sensitivity => sensitivity;

        private void Awake()
        {
            zoomGesture = InputZoom.Create(sensitivity);
            targetCamera = GetComponent<Camera>();
        }

        private void Update()
        {
            var currentSize = targetCamera.orthographicSize;
            targetCamera.orthographicSize = Mathf.Clamp(currentSize - zoomGesture.ZoomValue,
                                                        MinZoom,
                                                        MaxZoom);
        }
    }
}
