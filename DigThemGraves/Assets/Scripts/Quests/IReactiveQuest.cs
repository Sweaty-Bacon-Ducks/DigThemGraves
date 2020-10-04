using AbstractionLib.QuestSystem;
using System;
using UniRx;

public interface IReactiveQuest : IQuest
{
    IObservable<Unit> WhenActivated { get; }
    IObservable<Unit> WhenFinished { get; }
    IObservable<Unit> WhenFailed { get; }
    IObservable<Unit> WhenAvailable { get; }
}
