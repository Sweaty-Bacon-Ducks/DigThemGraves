using UnityEngine;
using AbstractionLib.QuestSystem;
using System;
using UniRx;

namespace DigThemGraves
{
    public abstract class ReactiveQuest : MonoBehaviour, IReactiveQuest
    {
        private Quest quest;

        [SerializeField]
        private QuestStateTransisitonMatrix transitionMatrix;

        [SerializeField]
        private string title;

        [SerializeField]
        private string description;

        public QuestState QuestState => quest.QuestState;

        public bool IsActive => quest.IsActive;

        public bool IsAvailable => quest.IsAvailable;

        public bool IsFinished => quest.IsFinished;

        public bool HasFailed => quest.HasFailed;

        public string Description { get => description; set => description = value; }

        public string Title { get => title; set => title = value; }

        public virtual IObservable<Unit> WhenActivated { get; }

        public abstract IObservable<Unit> WhenFinished { get; }

        public abstract IObservable<Unit> WhenFailed { get; }

        public virtual IObservable<Unit> WhenAvailable { get; }

        public IQuest MakeActive()
        {
            return quest.MakeActive();
        }

        public IQuest MakeAvailable()
        {
            return quest.MakeAvailable();
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

            WhenActivated.Subscribe((_) =>
            {
                Debug.Log($"Quest {title} activated");
                MakeActive();
            });
            WhenAvailable.Subscribe((_) =>
            {
                Debug.Log($"Quest {title} available");
                MakeAvailable();
            });
            WhenFinished.Subscribe((_) =>
            {
                if (IsActive)
                {
                    MakeFinished();
                    Debug.Log($"Quest {title} finished");
                }
            });
            WhenFailed.Subscribe((_) =>
            {
                if (!IsFinished && IsActive)
                {
                    Debug.Log($"Quest {title} failed");
                    MakeFailed();
                }
            });
        }
    }
}
