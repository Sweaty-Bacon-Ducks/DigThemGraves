using UnityEngine;
using System.Linq;
using UniRx;

namespace DigThemGraves
{
    public class GraveyardController : MonoBehaviour,
        IController<Graveyard>,
        IModelProxy<Graveyard>
    {
        private Graveyard model;
        public Graveyard Model
        {
            get
            {
                if (model is null)
                {
                    var models = GetComponentsInChildren<IModelProxy<ReactiveGrave>>();
                    model = new Graveyard(models.Select(proxy => proxy.Model).ToList());
                }
                return model;
            }
        }

        private void Awake()
        {
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