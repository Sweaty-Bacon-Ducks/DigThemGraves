using UnityEngine;

namespace DigThemGraves
{
    public interface IAction
    {
        void Execute();
        bool IsFinished { get; set; }
    }
}