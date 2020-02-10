using UnityEngine;

namespace DigThemGraves
{
    public abstract class UserSwipe
    {
        public abstract SwipeData Swipe { get; }

        public virtual bool WasSwiped { get => Swipe.Swiped; }
        public virtual Vector3 Direction { get => Swipe.Direction; }

        public static UserSwipe Create()
        {
#if UNITY_ANDROID
			return new FingerSwipe();
#elif UNITY_EDITOR
            return new MouseSwipe();
#else
           throw new PlatformNotSupportedException();
#endif
        }
    }
}
