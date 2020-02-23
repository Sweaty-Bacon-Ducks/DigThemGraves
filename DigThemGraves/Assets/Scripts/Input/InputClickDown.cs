using UnityEngine;

namespace DigThemGraves
{
    public abstract class InputClickDown
    {
        public abstract ClickData ClickInformation { get; }

        public virtual bool WasClicked { get => ClickInformation.Clicked; }
        public virtual Vector2 ClickPoint { get => ClickInformation.OnScreenClickPoint; }

        public static InputClickDown Create()
        {
#if UNITY_ANDROID
			return new TouchClickDown();
#elif UNITY_EDITOR
            return new LeftMouseButtonClickDown();
#else
           throw new PlatformNotSupportedException();
#endif
        }
    }
}