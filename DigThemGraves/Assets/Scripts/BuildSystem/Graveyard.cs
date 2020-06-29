using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UniRx;

namespace DigThemGraves
{
    public class Graveyard
    {
        private ReactiveCollection<ReactiveGrave> builtGraves;
        private ICollection<ReactiveGrave> buildPlaces;

        public ICollection<ReactiveGrave> BuildPlaces
        {
            get => buildPlaces.ToList();
        }

        public IObservable<ReactiveGrave> BuiltGravesAsObservable => builtGraves.ObserveAdd().Select(e => e.Value);

        public Graveyard()
        {
            builtGraves = new ReactiveCollection<ReactiveGrave>();
        }

        public Graveyard(ICollection<ReactiveGrave> buildPlaces) : this()
        {
            this.buildPlaces = buildPlaces;
            BuildPlaces.Do(g => g.IsBuiltAsObservable
                                 .Where(b => b)
                                 .Do(_ => Debug.Log("A grave was built"))
                                 .Subscribe(_ => builtGraves.Add(g)));
        }

        public void ExtendBuildPlaces(IEnumerable<ReactiveGrave> buildPlaces)
        {
            throw new NotImplementedException();
        }
    }
}
