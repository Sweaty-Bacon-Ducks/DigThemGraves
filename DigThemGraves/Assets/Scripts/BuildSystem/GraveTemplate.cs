using UnityEngine;

namespace DigThemGraves
{
    [CreateAssetMenu(menuName = "Template/Grave")]
    public class GraveTemplate : ScriptableObject, IObjectFactory<ReactiveGrave>
    {
        [SerializeField]
        private uint MaxHealth;
        [SerializeField]
        private float BuildTime;

        public ReactiveGrave Create()
        {
            var g = new ReactiveGrave(MaxHealth, BuildTime);
            return g;
        }
    }
}