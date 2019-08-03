using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DigThemGraves
{
    public class ActionQueue : MonoBehaviour
    {
        private LinkedList<ActionWTF> actionList = new LinkedList<ActionWTF>();
        private IAction currentAction = null;

        [SerializeField]
        private GameObject actionMenu;

        [SerializeField]
        private GameObject actionIcon;

        void Update()
        {
            UpdateActions();
        }

        public bool IsEmpty()
        {
            return actionList.Count == 0;
        }

        private void UpdateActions()
        {
            if (!IsEmpty())
            {
                if (currentAction == null || currentAction.IsFinished)
                {
                    currentAction = actionList.First.Value.Action;
                    actionList.RemoveFirst();
                    currentAction.Execute();
                }
            }
        }

        public void AddAction(IAction action)
        {
            GameObject newActionIcon = Instantiate(actionIcon, actionMenu.transform);
            ActionInstance actionInstance = newActionIcon.GetComponent<ActionInstance>();
            actionInstance.Load(action);
            actionList.AddLast(new ActionWTF(action, actionInstance));
        }

        public void RemoveAction(IAction action)
        {
            ActionWTF actionWTF = actionList.Where(x => x.Action == action).FirstOrDefault();
            actionList.Remove(actionWTF);
            Destroy(actionWTF.ActionInstance.gameObject);
        }
    }
}