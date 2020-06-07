using System;
using UnityEngine;
using UniRx;
using System.Collections.Generic;
using System.Linq;

namespace DigThemGraves
{
    public class GraveyardPresenter : MonoBehaviour
    {
        [SerializeField]
        private GraveLevelSelector GraveLevelSelector;
        private IEnumerable<IModelProxy<ReactiveGrave>> graveModels;

        private void Awake()
        {
            graveModels = GetComponentsInChildren<IModelProxy<ReactiveGrave>>().AsEnumerable();
        }

        private void Start()
        {
            graveModels.Select(item => item.Model.CanBuildAsObservable).Merge()
                .Where(canBuild => canBuild)
                .Subscribe(_ => GraveLevelSelector.Activate());


            GraveLevelSelector.SelectedOptionAsObservable
                              .Subscribe((l =>
                              {
                                  graveModels.Where((item => (item.Model.IsSelected == true && !item.Model.IsBuild)))
                                                      .ToList()
                                                      .ForEach((g => g.Model.BuildGraveWithLevel(l)));
                              }));
            GraveLevelSelector.SelectedOptionAsObservable.Subscribe(level => graveModels.Do(item => item.Model.IsSelected = false));
            GraveLevelSelector.SelectedOptionAsObservable.Subscribe(_ => GraveLevelSelector.Deactivate());
        }
    }
}
