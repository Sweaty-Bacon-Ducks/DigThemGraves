using UnityEngine;
using UnityEngine.AI;

namespace DigThemGraves
{
    public class WalkingAction : Action
    {
        [SerializeField]
        private string actionName;
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
                return agent.remainingDistance < 1;
            }
            set
            {
                isFinished = value;
            }
        }

        private NavMeshAgent agent;
        private Vector3 objectivePos;

        public override void Execute(GameObject target)
        {
            agent = target.GetComponent<NavMeshAgent>();
            objectivePos = target.transform.position;
            WalkToTarget();
        }

        public void WalkToTarget()
        {
            agent.SetDestination(objectivePos);
        }
    }
}
