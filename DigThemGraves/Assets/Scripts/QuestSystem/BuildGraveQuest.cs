using System;
using UnityEngine;
using AbstractionLib.QuestSystem;
using UniRx;

namespace DigThemGraves
{
    // TODO: Generalizacja tworzenia questów, z obecną abstrakcją wystarczy powiedzieć kiedy mają się zmieniać stany questa
    [Serializable]
    public class BuildGraveQuest : Quest
    {
        public IObservable<ReactiveGrave> BuiltGravesAsObservable { get; private set; }

        public BuildGraveQuest(IObservable<ReactiveGrave> builtGravesAsObservable)
        {
            this.BuiltGravesAsObservable = builtGravesAsObservable;

            BuiltGravesAsObservable
                .Do(_ => Debug.Log("Built grave for quest"))
                .Subscribe(_ => MakeFinished());
        }
    }
}
