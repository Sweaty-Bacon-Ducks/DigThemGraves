using System;
using UnityEngine;
using AbstractionLib.QuestSystem;
using UniRx;

namespace DigThemGraves
{
    // TODO: Generalizacja tworzenia questów, z obecną abstrakcją wystarczy powiedzieć kiedy mają się zmieniać stany questa
    [Serializable]
    public class BuildGraveQuest : ReactiveQuest
    {
        [SerializeField]
        private GraveyardController graveyardController;

        public override IObservable<Unit> WhenFinished
        {
            get => graveyardController.Model.BuiltGravesAsObservable.Take(1).Do((_) => Debug.Log("good boi")).AsUnitObservable();
        }

        public override IObservable<Unit> WhenFailed
        {
            get => Observable.Timer(TimeSpan.FromSeconds(10.0)).Do((_) => Debug.Log("u fucked up")).AsUnitObservable();
        }
    }
}
