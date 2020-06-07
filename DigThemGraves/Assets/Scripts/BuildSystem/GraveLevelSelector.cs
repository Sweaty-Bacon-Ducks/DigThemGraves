using System;
using System.Collections.Generic;
using System.Linq;
using UniRx;
using UnityEngine;

namespace DigThemGraves
{
    public class GraveLevelSelector : MonoBehaviour
    {
        [SerializeField]
        private List<GameObject> elementsOfOptionsPanel;
        private List<GraveLevelOption> options;

        public IObservable<uint> SelectedOptionAsObservable { get; private set; }

        private void Awake()
        {
            options = GetComponentsInChildren<GraveLevelOption>().ToList();
            SelectedOptionAsObservable = options.Select(x => x.SelectedOptionAsObservable).Merge();
            Deactivate();
        }

        public void Activate()
        {
            foreach (var item in elementsOfOptionsPanel)
            {
                item.SetActive(true);
            }
        }

        public void Deactivate()
        {
            foreach (var item in elementsOfOptionsPanel)
            {
                item.SetActive(false);
            }
        }
    }

}
