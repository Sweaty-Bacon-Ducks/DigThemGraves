using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    [CreateAssetMenu(menuName = "Template/GraveLevelView")]
    public class GraveLevelViewTemplate : ScriptableObject, IObjectFactory<GraveLevelView>
    {


        [SerializeField]
        private List<LevelSpritePair> LevelSpritePairs;

        private CopyObjectFactory<GraveLevelView> objectFactory;

        public GraveLevelViewTemplate()
        {
            objectFactory = new CopyObjectFactory<GraveLevelView>(this);
        }

        public GraveLevelView Create()
        {
            return objectFactory.Create();
        }
    }
}