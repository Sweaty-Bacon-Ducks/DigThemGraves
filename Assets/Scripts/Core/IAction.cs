using UnityEngine;

namespace DigThemGraves
{
    public interface IAction
    {
        Sprite Sprite { get; set; }
        void Execute();
        bool IsFinished { get; set; }
    }
}