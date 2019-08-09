using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    public class ActionModel
    {
        public IAction Action;
        public ActionDisplay ActionInstance;

        public ActionModel(IAction action, ActionDisplay actionInstance)
        {
            this.Action = action;
            this.ActionInstance = actionInstance;
        }
    }
}
