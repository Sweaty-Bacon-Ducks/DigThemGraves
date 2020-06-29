using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace DigThemGraves
{
    public class GravePresenter : MonoBehaviour, IPresenter<ReactiveGrave>
    {
        [SerializeField]
        private GraveLevelViewTemplate graveLevelViewTemplate;
        [SerializeField]
        private Animator buildAnimator;
        [SerializeField]
        private Animator selectionAnimator;

        private SpriteRenderer spriteRenderer;
        private IController<ReactiveGrave> graveController;

        private GraveLevelView GraveLevelViewGateway
        {
            get
            {
                return graveLevelViewTemplate.Create();
            }
        }

        public ReactiveGrave Model => graveController.Model;

        private void Awake()
        {
            spriteRenderer = GetComponent<SpriteRenderer>();
            graveController = GetComponent<IController<ReactiveGrave>>();
        }

        private void Start()
        {
            Model.LevelAsObservable
                 .Where(l => l > 0)
                 .Subscribe(l => spriteRenderer.sprite = GraveLevelViewGateway.SpriteFromLevel(l));
            Model.IsSelectedAsObservable.Subscribe(s => selectionAnimator.SetBool("IsSelected", s));
            Model.BuildTimeRemainingAsObservable
                .Where(remainingBuildTime => (remainingBuildTime < Model.BuildTime) && (remainingBuildTime > 0))
                .Take(1)
                .Subscribe(_ => buildAnimator.SetBool("ConstructionStarted", true));
            Model.BuildTimeRemainingAsObservable
                .Where(remainingBuildTime => remainingBuildTime <= 0)
                .Take(1)
                .Subscribe(_ => buildAnimator.SetBool("ConstructionEnded", true));
        }
    }
}
