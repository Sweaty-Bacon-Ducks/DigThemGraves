using UnityEngine;

namespace DigThemGraves
{
    public class BuildAction : IAction
    {
        [SerializeField]
        private string actionName;

        private GameObject target;

        public string Name
        {
            get
            {
                return actionName;
            }
        }

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

        public BuildAction(GameObject target)
        {
            this.target = target;
        }

        public void Execute()
        {
            Debug.Log("Building grave");
            target.GetComponent<Buildable>().Build();
            IsFinished = true;
        }
    }
}
