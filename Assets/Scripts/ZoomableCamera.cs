using UnityEngine;

namespace DigThemGraves
{
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
