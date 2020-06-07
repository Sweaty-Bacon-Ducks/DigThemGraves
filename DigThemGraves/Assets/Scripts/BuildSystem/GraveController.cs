using UniRx;
using UniRx.Triggers;
using UnityEngine;

namespace DigThemGraves
{
    public class GraveController : MonoBehaviour,
        IController<ReactiveGrave>,
        IModelProxy<ReactiveGrave>
    {
        private ReactiveGrave reactiveGrave;

        public GraveTemplate GraveTemplate;

        public ReactiveGrave Model
        {
            get
            {
                if (reactiveGrave is null)
                {
                    reactiveGrave = GraveTemplate.Create();
                }
                return reactiveGrave;
            }
        }

        private void Awake()
        {
            this.OnMouseDownAsObservable()
                .Subscribe(_ => Model.IsSelected = !Model.IsSelected);
            //this.UpdateAsObservable()
            //    .Select(_ => Input.GetMouseButtonDown(0))
            //    .CombineLatest(Model.IsSelectedAsObservable.DefaultIfEmpty(false), (l, r) => l && !r)
            //    .Where(MouseWasClicked => MouseWasClicked)
            //    .Do(i => Debug.Log(i))
            //    .Subscribe(MouseWasClicked => Model.IsSelected = false);

        }
    }
}
