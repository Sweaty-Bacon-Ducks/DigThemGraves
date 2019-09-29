using UnityEngine;
namespace DigThemGraves
{
    public struct SwipeData
    {
        public Vector3 Direction;
        public bool Swiped;

        public SwipeData(Vector3 direction, bool swiped)
        {
            Direction = direction;
            Swiped = swiped;
        }

        public static SwipeData NullSwipe()
        {
            return new SwipeData(Vector3.zero, false);
        }
    }
}