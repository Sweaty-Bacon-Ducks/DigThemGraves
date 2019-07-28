using UnityEngine;

namespace DigThemGraves
{
    public interface IAction
    {
        void Execute(GameObject target);
        bool IsFinished { get; set; }
    }
}