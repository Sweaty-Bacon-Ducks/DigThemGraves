﻿using System;
using UniRx;
using UniRx.Operators;
using UnityEngine;

namespace DigThemGraves
{
    public class ReactiveGrave : IGrave,
        IReactiveHealth<uint>,
        IHealthComponent<uint>,
        IReactiveSelectable,
        IReactiveBuildable
    {
        [SerializeField]
        private UIntReactiveProperty levelReactiveProperty;
        [SerializeField]
        private UIntReactiveProperty maxHealthReactiveProperty;
        [SerializeField]
        private UIntReactiveProperty currentHealthReactiveProperty;
        [SerializeField]
        private FloatReactiveProperty buildTimeReactiveProperty;
        [SerializeField]
        private BoolReactiveProperty isSelectedReactiveProperty;
        [SerializeField]
        private BoolReactiveProperty isBuiltReactiveProperty;
        [SerializeField]
        private FloatReactiveProperty buildTimeRemainingReactiveProperty;

        public ReactiveGrave(uint maxHealth, float buildTime)
        {
            levelReactiveProperty = new UIntReactiveProperty();
            currentHealthReactiveProperty = new UIntReactiveProperty();
            isSelectedReactiveProperty = new BoolReactiveProperty();
            isBuiltReactiveProperty = new BoolReactiveProperty();
            maxHealthReactiveProperty = new UIntReactiveProperty();
            maxHealthReactiveProperty = new UIntReactiveProperty(maxHealth);
            buildTimeReactiveProperty = new FloatReactiveProperty(buildTime);
            buildTimeRemainingReactiveProperty = new FloatReactiveProperty(buildTime);
        }

        public IObservable<uint> LevelAsObservable => levelReactiveProperty.AsObservable();
        public IObservable<uint> MaxHealthAsObservable => maxHealthReactiveProperty.AsObservable();
        public IObservable<uint> CurrentHealthAsObservable => currentHealthReactiveProperty.AsObservable();
        public IObservable<bool> IsSelectedAsObservable => isSelectedReactiveProperty.AsObservable();
        public IObservable<float> BuildTimeRemainingAsObservable => buildTimeRemainingReactiveProperty.AsObservable();
        public IObservable<bool> IsBuiltAsObservable => isBuiltReactiveProperty.AsObservable();
        public IObservable<bool> CanBuildAsObservable => isSelectedReactiveProperty.AsObservable()
            .Select(isSelected => isSelected && !isBuiltReactiveProperty.Value);

        public uint MaxHealthValue => maxHealthReactiveProperty.Value;

        public uint CurrentHealth => currentHealthReactiveProperty.Value;

        public bool IsSelected
        {
            get => isSelectedReactiveProperty.Value;
            set => isSelectedReactiveProperty.SetValueAndForceNotify(value);
        }

        public uint Level => levelReactiveProperty.Value;

        public float BuildTime
        {
            get => buildTimeReactiveProperty.Value;
            set => buildTimeReactiveProperty.SetValueAndForceNotify(value);
        }

        public bool IsBuilt
        {
            get
            {
                if (levelReactiveProperty.Value > 0)
                {
                    isBuiltReactiveProperty.SetValueAndForceNotify(true); // Poprawić
                }
                return isBuiltReactiveProperty.Value;
            }
        }

        public void BuildGraveWithLevel(uint level)
        {
            if (!IsBuilt)
            {
                Observable.Interval(TimeSpan.FromMilliseconds(100))
                    .Take(Mathf.CeilToInt(10 * BuildTime))
                    .Subscribe(
                        onNext: sec =>
                        {
                            Debug.Log($"Construction time elapsed: {sec}, Time remaining {BuildTime - ((sec + 1) / 10f)}");
                            buildTimeRemainingReactiveProperty.SetValueAndForceNotify(BuildTime - ((sec + 1) / 10f));
                        },
                        onCompleted: () =>
                        {
                            levelReactiveProperty.SetValueAndForceNotify(level);
                            isBuiltReactiveProperty.SetValueAndForceNotify(true);
                        });
            }
        }

        public void Damage(uint amount)
        {
            var newHealth = Convert.ToUInt32(Mathf.Clamp(
                value: currentHealthReactiveProperty.Value - amount,
                min: 0,
                max: maxHealthReactiveProperty.Value));
            currentHealthReactiveProperty.SetValueAndForceNotify(newHealth);
        }

        public void Heal(uint amount)
        {
            var newHealth = Convert.ToUInt32(Mathf.Clamp(
                value: currentHealthReactiveProperty.Value + amount,
                min: 0,
                max: maxHealthReactiveProperty.Value));
            currentHealthReactiveProperty.SetValueAndForceNotify(newHealth);
        }

        public void Upgrade()
        {
            levelReactiveProperty.SetValueAndForceNotify(levelReactiveProperty.Value + 1);
        }
    }
}
