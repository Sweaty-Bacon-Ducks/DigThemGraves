using UnityEngine;

namespace DigThemGraves
{
    public class BuildAction : Action
    {
        [SerializeField]
        private string actionName;

        private GameObject target;

        public override string Name
        {
            get
            {
                return actionName;
            }
        }

        private bool isFinished;
        public override bool IsFinished
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

        public override void Execute()
        {
            Debug.Log("Building grave");
            target.GetComponent<Buildable>().Build();
            IsFinished = true;
        }
    }
}
