using UnityEngine;
namespace DigThemGraves
{
    public struct SwipeData
    {
        public Vector3 Direction;
        public bool Swiped;

        private static SwipeData nullSwipe = new SwipeData(Vector3.zero, false);

        public SwipeData(Vector3 direction, bool swiped)
        {
            Direction = direction;
            Swiped = swiped;
        }

        public static SwipeData NullSwipe()
        {
            return nullSwipe;
        }
    }
}