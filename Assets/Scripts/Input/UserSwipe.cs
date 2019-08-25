namespace DigThemGraves
{
    public abstract class UserSwipe
    {
        public abstract SwipeData Swipe { get; }

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
