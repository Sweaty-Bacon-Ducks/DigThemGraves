using System;

namespace DigThemGraves
{
    public interface IReactiveHealth<T>
    {
        IObservable<T> MaxHealthAsObservable { get; }
        IObservable<T> CurrentHealthAsObservable { get; }
    }
}
