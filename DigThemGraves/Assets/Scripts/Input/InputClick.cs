using UnityEngine;

namespace DigThemGraves
{
    public abstract class InputClick
    {
        public abstract ClickData ClickInformation { get; }

        public virtual bool WasClicked { get => ClickInformation.Clicked; }
        public virtual Vector2 ClickPoint { get => ClickInformation.OnScreenClickPoint; }

        public static InputClick Create()
        {
#if UNITY_ANDROID
			return new TouchClick();
#elif UNITY_EDITOR
            return new LeftMouseButtonClick();
#else
           throw new PlatformNotSupportedException();
#endif
        }
    }
}