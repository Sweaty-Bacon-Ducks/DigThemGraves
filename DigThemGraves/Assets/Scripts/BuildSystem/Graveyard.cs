using System;
using System.Collections.Generic;
using System.Linq;
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

        public IObservable<ReactiveGrave> BuiltGravesAsObservable => builtGraves.ToObservable();

        public Graveyard()
        {
            builtGraves = new ReactiveCollection<ReactiveGrave>();
            var s = BuiltGravesAsObservable.Where(g => g.IsBuild).Subscribe(g => builtGraves.Add(g));
        }

        public Graveyard(ICollection<ReactiveGrave> buildPlaces) : this()
        {
            this.buildPlaces = buildPlaces;
        }

        public void ExtendBuildPlaces(IEnumerable<ReactiveGrave> buildPlaces)
        {
            this.buildPlaces.Do(grave => BuildPlaces.Add(grave));
        }
    }
}
