using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    public class GraveBuildSlot : BuildSlot
    {
        [SerializeField]
        private GameObject buildableMenu;
        public override IBuildable Occupant { get { return Occupant; } }

        [SerializeField]
        private List<Buildable> possibleBuildables;

        public override List<Buildable> PossibleBuildables
        {
            get { return possibleBuildables; }
        }

        public override void OnMouseDown()
        {
            //PossibleBuildables[0].TargetedBuildSlot = this;

            foreach (IBuildable buildable in PossibleBuildables)
            {
                buildable.TargetedBuildSlot = this;
            }

            Vector3 pos = buildableMenu.transform.position;
            Rect canvasRect = buildableMenu.transform.parent.GetComponent<RectTransform>().rect;

            Vector3 mousePos = Camera.main.WorldToScreenPoint(transform.position);

            if (pos.x < 0)
                pos = new Vector3(0, pos.y, pos.z);

            if (pos.x > canvasRect.width)
                pos = new Vector3(pos.x, pos.y, pos.z);

            if (pos.y < 0)
                pos = new Vector3(pos.x, 0, pos.z);

            if (pos.y > canvasRect.height)
                pos = new Vector3(pos.x, canvasRect.height, pos.z);

            buildableMenu.SetActive(true);
        }
    }
}
