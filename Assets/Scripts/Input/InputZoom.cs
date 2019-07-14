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
}