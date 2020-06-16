using DigThemGraves;
using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UniRx;
using UnityEngine;
using UnityScript.Steps;

namespace DigThemGraves
{
    public class MoneyPresenter : MonoBehaviour, IPresenter<MoneyModel>
    {
        private MoneyModel _model;
        public MoneyModel Model => _model;

#pragma warning disable CS0649
        [SerializeField]
        private TextMeshProUGUI _text;
#pragma warning restore CS0649

        [SerializeField] private Sprite _moneySprite;

        private void Awake()
        {
            _model = new MoneyModel(_moneySprite);

            Model.MoneyAsObservable
                 .Subscribe(m =>
                 {
                     _text.text = string.Format("{0}", m);
                 });
        }

        public void DebugAddMoney()
        {
            Model.Add(15);
        }

        public void DebugSubtractMoney()
        {
            Model.Substract(10);
        }
    }
}