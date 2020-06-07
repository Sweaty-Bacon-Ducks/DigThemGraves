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

        private SpriteRenderer spriteRenderer;
        private IController<ReactiveGrave> graveController;
        private Animator selectionAnimator;

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
            selectionAnimator = GetComponentInChildren<Animator>();
        }

        private void Start()
        {
            Model.LevelAsObservable
                 .Where(l => l > 0)
                 .Subscribe(l => spriteRenderer.sprite = GraveLevelViewGateway.SpriteFromLevel(l));
            Model.IsSelectedAsObservable.Subscribe(s => selectionAnimator.SetBool("IsSelected", s));
        }
    }
}
