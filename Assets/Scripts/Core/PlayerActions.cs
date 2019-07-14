using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    [Serializable]
    public class PlayerActions : IPlayerActions
    {
        [SerializeField]
        private List<ScriptablePlayerAction> actions;

        public ICollection<IPlayerAction> Actions => (ICollection<IPlayerAction>)actions;

        public IEnumerator<IPlayerAction> GetEnumerator()
        {
            return Actions.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return Actions.GetEnumerator();
        }
    }
}