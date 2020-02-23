using UnityEngine;

namespace DigThemGraves
{
    public abstract class Queue : MonoBehaviour
    {
        public abstract void AddAction(IAction action);
        public abstract void RemoveAction(IAction action);
    }
}