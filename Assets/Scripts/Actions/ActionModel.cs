using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    public class ActionModel
    {
        public IAction Action;
        public ActionView ActionInstance;

        public ActionModel(IAction action, ActionView actionInstance)
        {
            this.Action = action;
            this.ActionInstance = actionInstance;
        }
    }
}
