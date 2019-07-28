using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    public class ActionQueue : MonoBehaviour
    {
        private GameObject target;
        public GameObject Target
        {
            get
            {
                return target;
            }
            set
            {
                target = value;
            }
        }

        public Queue<Action> actionList = new Queue<Action>();
        public Action currentAction = null;

        void Update()
        {
            UpdateActions();
        }

        public bool IsEmpty()
        {
            return !Convert.ToBoolean(actionList.Count);
        }

        private void UpdateActions()
        {
            if (currentAction == null)
            {
                if (actionList.Count > 0)
                {
                    currentAction = actionList.Dequeue();
                    currentAction.Execute(Target);
                }
            }
            else
            {
                if (currentAction.IsFinished) currentAction = null;
            }
        }
    }
}

