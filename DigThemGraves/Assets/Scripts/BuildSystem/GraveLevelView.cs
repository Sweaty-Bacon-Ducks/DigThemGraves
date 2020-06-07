using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace DigThemGraves
{
    public class GraveLevelView
    {
        [FillFromFile("LevelSpritePairs")]
        private List<LevelSpritePair> LevelSpriteMapping;

        public Sprite SpriteFromLevel(uint level)
        {
            return LevelSpriteMapping.Where(item => item.Level == level)
                                     .First()
                                     .Sprite;
        }
    }
}