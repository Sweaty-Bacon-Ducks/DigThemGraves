using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    public class ActionWTF
    {
        public IAction Action;
        public ActionInstance ActionInstance;

        public ActionWTF(IAction action, ActionInstance actionInstance)
        {
            this.Action = action;
            this.ActionInstance = actionInstance;
        }
    }
}
