﻿using UnityEngine;
using UniRx;
using System;

namespace DigThemGraves
{
    public class Money
    {
        private FloatReactiveProperty _moneyReactiveProperty;
        public IObservable<float> MoneyAsObservable => _moneyReactiveProperty.AsObservable();

        public Sprite Sprite { get; private set; }

        public Money(Sprite sprite)
        {
            _moneyReactiveProperty = new FloatReactiveProperty(0);
            this.Sprite = sprite;
        }

        public bool CanAfford(float amount)
        {
            return (_moneyReactiveProperty.Value - amount) >= 0;
        }

        public void Add(float amount)
        {
            _moneyReactiveProperty.Value += amount;
        }

        public void Substract(float amount)
        {
            if (_moneyReactiveProperty.Value < amount)
            {
                Debug.LogWarning("The money is negative! Did you wanted to use SubstractWithNegatives?");
            }
            _moneyReactiveProperty.Value -= amount;
        }

        public void SubstractWithNegatives(float amount)
        {
            _moneyReactiveProperty.Value -= amount;
        }
    }
}