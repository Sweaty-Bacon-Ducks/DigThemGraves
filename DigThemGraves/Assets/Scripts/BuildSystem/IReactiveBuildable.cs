using System;

namespace DigThemGraves
{
    public interface IReactiveBuildable
    {
        IObservable<float> BuildTimeRemainingAsObservable { get; }
        IObservable<bool> IsBuiltAsObservable { get; }
    }
}
