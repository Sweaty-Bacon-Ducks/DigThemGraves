using System;
using UnityEngine;

namespace DigThemGraves
{
    public class MovableCamera : MonoBehaviour
    {
        [SerializeField]
        private float acceleration;
        [SerializeField]
        private bool inverseSteering;
        [SerializeField]
        private Camera targetCamera;

        private UserSwipe swipeGateway;
        private void Awake()
        {
            swipeGateway = UserSwipe.Create();
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


