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
        private void Awake()
        {
            swipeGateway = UserSwipe.Create();
            targetCamera = GetComponent<Camera>();
        }

        private void LateUpdate()
        {
            SwipeData swipeData = swipeGateway.Swipe;
            if (!swipeData.Swiped)
            {
                return;
            }

            Vector3 direction = swipeData.Direction;
            Vector3 offset = inverseSteering ? (-1) * direction * acceleration : direction * acceleration;
            Vector3 targetPosition = targetCamera.transform.position + offset;
            targetCamera.transform.position = targetPosition;
        }
    }
}


