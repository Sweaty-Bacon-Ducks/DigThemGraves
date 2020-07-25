using System;
using UnityEngine;
using AbstractionLib.QuestSystem;
using UniRx;

namespace DigThemGraves
{
    /*
     * TODO: Move to abstraction lib as a decorator to Quest
     Active - 1110       
     Available - 1100
     Finished - 0100
     Failed - 1000

        Active -> Available
         1110
       & 0010
       ------
         0010

        Active -> Failed
         1110
       & 1000
       ------
         1000

        Failed -> Finished
         1000
       & 0100
       ------
         0000
           
     */
    [Serializable]
    public class QuestStateTransisitonMatrix
    {
        public QuestState ActiveMask = QuestState.Available | QuestState.Failed | QuestState.Finished;
        public QuestState AvailableMask = QuestState.Failed | QuestState.Finished;
        public QuestState FinishedMask = QuestState.Finished;
        public QuestState FailedMask = QuestState.Failed;

        public bool IsTransitionValid(QuestState from, QuestState to)
        {
            switch (from)
            {
                case QuestState.Active:
                    return (ActiveMask & from) == to;
                case QuestState.Available:
                    return (AvailableMask & from) == to;
                case QuestState.Finished:
                    return (FinishedMask & from) == to;
                case QuestState.Failed:
                    return (FailedMask & from) == to;
                case QuestState.None:
                    return false;
                default:
                    return false;
            }
        }
    }

    [Serializable]
    public class BuildGraveQuest : ReactiveQuest
    {
        [SerializeField]
        private GraveyardController graveyardController;

        [SerializeField]
        private QuestStateTransisitonMatrix matrix;

        public override IObservable<Unit> WhenFinished
        {
            get
            {
                return graveyardController.Model.BuiltGravesAsObservable.Take(1).AsUnitObservable();
            }
        }

        public override IObservable<Unit> WhenFailed
        {
            get
            {
                return Observable.Timer(TimeSpan.FromSeconds(10.0)).AsUnitObservable();
            }
        }
    }
}
