using System;
using AbstractionLib.QuestSystem;

namespace DigThemGraves
{
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
}
