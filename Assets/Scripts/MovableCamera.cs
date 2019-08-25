using System;
using UnityEngine;

namespace DigThemGraves
{
    [RequireComponent(typeof(Camera))]
    public class MovableCamera : MonoBehaviour
    {
        [SerializeField]
        private float acceleration;
        [SerializeField]
        private bool inverseSteering;

        private UserSwipe swipeGateway;
        private Camera targetCamera;
        void Awake()
        {
            swipeGateway = UserSwipe.Create();
            targetCamera = GetComponent<Camera>();
        }

        void LateUpdate()
        {
            var swipeData = swipeGateway.Swipe;
            if (!swipeData.Swiped)
            {
                return;
            }

            var direction = swipeData.Direction;
            var offset = inverseSteering ? (-1) * direction * acceleration : direction * acceleration;
            var targetPosition = targetCamera.transform.position + offset;
            targetCamera.transform.position = targetPosition;
        }
    }
}


