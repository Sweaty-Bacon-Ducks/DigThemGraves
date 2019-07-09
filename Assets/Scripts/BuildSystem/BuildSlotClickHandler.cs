using DigThemGraves;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// TODO: Hide buildable menu, when clicked outside of buildSlot and build menu colliders.
public class BuildSlotClickHandler : MonoBehaviour
{
    [SerializeField]
    private GameObject BuildableMenu;

    [SerializeField]
    private ActiveBuildSlot activeSlot;

    void Update()
    {
        PerformMouseClick();
    }

    private void PerformMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePos = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            Vector2 mousePos2D = new Vector2(mousePos.x, mousePos.y);

            RaycastHit2D hit = Physics2D.Raycast(mousePos2D, Vector2.zero);
            if (hit.collider != null)
            {
                if (hit.collider.GetComponent<IBuildSlot>() != null)
                {
                    activeSlot.ActiveSlot = hit.collider.GetComponent<BuildSlot>();
                    BuildableMenu.SetActive(true);
                }
            }
            else
            {
                //BuildableMenu.SetActive(false);
            }
        }
    }
}
