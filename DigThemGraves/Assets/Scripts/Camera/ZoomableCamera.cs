using UnityEngine;

namespace DigThemGraves
{
    public class ZoomableCamera : MonoBehaviour
    {
        private InputZoom zoomGesture;

        [SerializeField]
        private float minZoom;
        [SerializeField]
        private float maxZoom;
        [SerializeField]
        private float sensitivity;
        [SerializeField]
        private Camera targetCamera;

        public float MinZoom => minZoom;
        public float MaxZoom => maxZoom;
        public float Sensitivity => sensitivity;

        private void Awake()
        {
            zoomGesture = InputZoom.Create(sensitivity);
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
