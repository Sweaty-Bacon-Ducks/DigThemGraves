using System;

namespace UniRx
{
    /// <summary>
    /// Inspectable ReactiveProperty.
    /// </summary>
    [Serializable]
    public class UIntReactiveProperty : ReactiveProperty<uint>
    {

        public UIntReactiveProperty()
            : base()
        {

        }

        public UIntReactiveProperty(uint initialValue)
            : base(initialValue)
        {

        }
    }
}

