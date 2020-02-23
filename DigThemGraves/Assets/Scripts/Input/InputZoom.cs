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
#elif UNITY_EDITOR
			return new MouseWheelZoom(Sensitivity);
#else
           throw new PlatformNotSupportedException();
#endif
		}
	}
}