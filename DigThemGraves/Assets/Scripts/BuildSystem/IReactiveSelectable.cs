using System;

namespace DigThemGraves
{
    public interface IReactiveSelectable
    {
        IObservable<bool> IsSelectedAsObservable { get; }
    }
}
