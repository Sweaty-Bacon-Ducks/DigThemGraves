using UnityEngine;

namespace Assets.Editor.QuestDesigner.Extensions
{
    public static class RectExtensions
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="offset"></param>
        /// <returns></returns>
        public static Rect Translate(this Rect rect, Vector2 offset)
        {

        }

        /// <summary>
        /// Scales the rectangle homogeneously in each dimension.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        public static Rect Scale(this Rect rect, float units)
        {
            return new Rect(rect.x - units,
                rect.y - units,
                rect.width + (2 * units),
                rect.height + (2 * units));
        }

        /// <summary>
        /// Scales the rectangle's dimension according to a given vector.
        /// </summary>
        /// <param name="rect"></param>
        /// <param name="units"></param>
        /// <returns></returns>
        public static Rect Scale(this Rect rect, Vector2 units)
        {
            return new Rect(rect.position, rect.size + units);
        }
    }
}
