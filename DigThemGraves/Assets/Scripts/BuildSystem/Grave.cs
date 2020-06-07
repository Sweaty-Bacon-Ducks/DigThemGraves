using System;
using UnityEngine;

namespace DigThemGraves
{
    [Serializable]
    public class Grave : IGrave,
        IHealthComponent<uint>,
        IBuildable
    {
        [SerializeField]
        private uint level;
        [SerializeField]
        private uint maxHealth;
        [SerializeField]
        private uint currentHealth;
        [SerializeField]
        private float buildTime;
        [SerializeField]
        private float buildTimeRemaining;
        [SerializeField]
        private bool isBuilt;
        [SerializeField]
        private bool isSelected;

        public Grave()
        {
            level = 0;
            isBuilt = false;
            currentHealth = maxHealth;
        }

        public uint MaxHealthValue => maxHealth;

        public uint CurrentHealth => currentHealth;

        public bool IsSelected { get => isSelected; set => isSelected = value; }

        public uint Level => level;

        public float BuildTime
        {
            get => buildTime;
            set => buildTime = value;
        }

        public void Build()
        {
            throw new NotImplementedException();
        }

        public void BuildGraveWithLevel(uint level)
        {
            this.level = level;
            isBuilt = true;
        }

        public void Damage(uint amount)
        {
            currentHealth = Convert.ToUInt32(Mathf.Clamp(
                value: currentHealth - amount,
                min: 0,
                max: maxHealth));
        }

        public void Heal(uint amount)
        {
            currentHealth = Convert.ToUInt32(Mathf.Clamp(
                value: currentHealth + amount,
                min: 0,
                max: maxHealth));
        }

        public bool IsBuilt()
        {
            if (level > 0)
            {
                isBuilt = true;
            }
            return isBuilt;
        }

        public void Upgrade()
        {
            level++;
        }
    }
}
