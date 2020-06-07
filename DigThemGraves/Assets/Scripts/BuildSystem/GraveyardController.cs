using UnityEngine;
using System.Linq;
using UniRx;
using System.Collections.Generic;

namespace DigThemGraves
{
    public class GraveyardController : MonoBehaviour,
        IController<Graveyard>,
        IModelProxy<Graveyard>
    {
        public Graveyard Model { get; private set; }

        private void Awake()
        {
            var models = GetComponentsInChildren<IModelProxy<ReactiveGrave>>();
            Model = new Graveyard(models.Select(proxy => proxy.Model).ToList());
            Model.BuildPlaces.Do((grave) =>
            {
                grave.IsSelectedAsObservable.Where(b => b)
                    .Subscribe(_ => Model.BuildPlaces.Where(g => g != grave)
                        .ToList()
                        .ForEach(g => g.IsSelected = false));
            });
        }
    }

}