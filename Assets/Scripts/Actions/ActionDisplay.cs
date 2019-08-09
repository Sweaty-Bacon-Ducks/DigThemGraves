﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DigThemGraves
{
    /// <summary>
    /// Class represents clickable icon in action queue
    /// </summary>
    public class ActionDisplay : MonoBehaviour
    {
        public IAction action;

        public void Load(IAction action)
        {
            this.action = action;
            GetComponent<Image>().sprite = action.Sprite;
        }

        public void OnClicked()
        {
            ActionQueue actionQueue = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ActionQueue>();
            actionQueue.RemoveAction(action);
        }
    }
}