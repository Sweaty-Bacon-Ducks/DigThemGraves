using UnityEngine;
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

public abstract class ReactiveQuest : MonoBehaviour, IReactiveQuest
{
    private Quest quest;

    [SerializeField]
    private string title;

    [SerializeField]
    private string description;

    private IObservable<Unit> whenAvailable;
    private IObservable<Unit> whenActivated;

    public QuestState QuestState => quest.QuestState;

    public bool IsActive => quest.IsActive;

    public bool IsAvailable => quest.IsAvailable;

    public bool IsFinished => quest.IsFinished;

    public bool HasFailed => quest.HasFailed;

    public string Description { get => description; set => description = value; }

    public string Title { get => title; set => title = value; }

    public virtual IObservable<Unit> WhenActivated
    {
        get
        {
            if (whenActivated is null)
            {
                return Observable.Never<Unit>();
            }
            return whenActivated;

        }
    }

    public abstract IObservable<Unit> WhenFinished { get; }

    public abstract IObservable<Unit> WhenFailed { get; }

    public virtual IObservable<Unit> WhenAvailable
    {
        get
        {
            if (whenAvailable is null)
            {
                return Observable.Never<Unit>();
            }
            return whenAvailable;

        }
    }

    public IQuest MakeActive()
    {
        return quest.MakeActive();
    }

    public IQuest MakeAvailable()
    {
        return quest.MakeActive();
    }

    public IQuest MakeFailed()
    {
        return quest.MakeFailed();
    }

    public IQuest MakeFinished()
    {
        return quest.MakeFinished();
    }

    private void Awake()
    {
        quest = new Quest();

        WhenActivated.Subscribe((_) => MakeActive());
        WhenAvailable.Subscribe((_) => MakeAvailable());
        WhenFinished.Subscribe((_) => MakeFinished());
        //TODO: Zabronić zmiany stanu gdy quest jest ukończony
        WhenFailed.Subscribe((_) => MakeFailed());
    }
}
