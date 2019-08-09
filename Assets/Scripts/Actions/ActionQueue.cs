using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Linq;

namespace DigThemGraves
{
    public class ActionQueue : Queue
    {
        private LinkedList<ActionModel> actionList = new LinkedList<ActionModel>();
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
            if (currentAction == null)
            {
                if (!IsEmpty())
                {
                    currentAction = actionList.First.Value.Action;
                    currentAction.Execute();
                }
            }
            else if (currentAction.IsFinished)
            {
                RemoveAction(currentAction);
                currentAction = null;
            }
        }

        public override void AddAction(IAction action)
        {
            GameObject newActionIcon = Instantiate(actionIcon, actionMenu.transform);
            ActionDisplay actionInstance = newActionIcon.GetComponent<ActionDisplay>();
            actionInstance.Load(action);
            actionList.AddLast(new ActionModel(action, actionInstance));
        }

        public override void RemoveAction(IAction action)
        {
            ActionModel actionWTF = actionList.Where(x => x.Action == action).FirstOrDefault();
            actionList.Remove(actionWTF);
            Destroy(actionWTF.ActionInstance.gameObject);
        }
    }
}