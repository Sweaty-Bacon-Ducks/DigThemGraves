using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

namespace DigThemGraves
{
    /// <summary>
    /// Class represents clickable icon in action queue
    /// </summary>
    public class ActionView : MonoBehaviour
    {
        public IAction action;

        private ActionQueue actionQueue;

        void Start()
        {
            actionQueue = GameObject.FindGameObjectWithTag("GameManager").GetComponent<ActionQueue>();
        }

        public void Load(IAction action)
        {
            this.action = action;
            GetComponent<Image>().sprite = action.Sprite;
        }

        public void OnClicked()
        {
            actionQueue.RemoveAction(action);
        }
    }
}