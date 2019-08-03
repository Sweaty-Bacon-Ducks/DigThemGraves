using System.Collections;
using System.Collections.Generic;
using System.Threading.Tasks;
using UnityEngine;

namespace DigThemGraves
{
    public class TEMPWaitingAction : IAction
    {
        private bool isFinished;
        public bool IsFinished
        {
            get
            {
                return isFinished;
            }
            set
            {
                isFinished = value;
            }
        }

        private Sprite sprite;
        public Sprite Sprite
        {
            get
            {
                return sprite;
            }
            set
            {
                sprite = value;
            }
        }

        public TEMPWaitingAction(Sprite sprite)
        {
            this.Sprite = sprite;
        }

        public void Execute()
        {
            Task.Delay(2000);
            IsFinished = true;
        }
    }
}
