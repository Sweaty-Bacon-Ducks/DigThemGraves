using System;
using UnityEngine;
using UniRx;

namespace DigThemGraves
{
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
