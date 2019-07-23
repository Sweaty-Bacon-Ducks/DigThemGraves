using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace DigThemGraves
{
    // TODO: 
    // Wyłączanie menu, jeśli gracz kliknął poza BuildSlot
    // Dokładniejsze dostosowanie wielkości menu scrollowania do ilości przycisków
    public class BuildableMenuDisplay : MonoBehaviour
    {
        [SerializeField]
        private GameObject buildableMenu;

        private List<Buildable> possibleBuildables;

        private BuildSlot targetedBuildSlot;

        public void ActivateMenu(List<Buildable> possibleBuildables, BuildSlot targetedBuildSlot)
        {
            this.possibleBuildables = possibleBuildables;
            this.targetedBuildSlot = targetedBuildSlot;
            LoadMenu();
            ShowMenu();
        }

        private void LoadMenu()
        {
            // Delete all existing buttons
            Transform buttonsParent = buildableMenu.transform.GetChild(0);
            for (int i = 0; i < buildableMenu.transform.GetChild(0).childCount; ++i)
            {
                Destroy(buttonsParent.GetChild(i).gameObject);
            }

            // Create new buttons
            foreach (Buildable buildable in possibleBuildables)
            {
                Buildable newBuildable = Instantiate(buildable);
                newBuildable.transform.SetParent(buttonsParent);
                newBuildable.TargetedBuildSlot = targetedBuildSlot;
            }

            // Create scrollable menu appropriate for number of buildables
            RectTransform buildableMenuRect = buttonsParent.parent.GetComponent<RectTransform>();
            RectTransform buttonsParentRect = buttonsParent.GetComponent<RectTransform>();

            buttonsParentRect.sizeDelta = new Vector2(buildableMenuRect.rect.width * possibleBuildables.Count, 
                                                      buildableMenuRect.rect.height);

            buttonsParentRect.position = new Vector3(buildableMenuRect.position.x + buildableMenuRect.rect.width * possibleBuildables.Count,  
                                                     buttonsParentRect.position.y, 
                                                     buttonsParentRect.position.z);
        }

        private void ShowMenu()
        {
            // Position of the clicked BuildSlot
            Vector3 originalPos = Camera.main.WorldToScreenPoint(targetedBuildSlot.transform.position);
            Vector3 pos = originalPos;

            Rect canvasRect = GetComponent<RectTransform>().rect;
            Rect menuRect = buildableMenu.transform.GetComponent<RectTransform>().rect;

            // If BuildSlot doesn't fit inside the canvas, then move it accordingly
            if (pos.x < menuRect.width)
                pos.x = menuRect.width;

            if (pos.x > canvasRect.width - menuRect.width)
                pos.x = canvasRect.width - (menuRect.width * 2);

            if (pos.y < menuRect.height)
                pos.y = menuRect.height;

            if (pos.y > canvasRect.height - menuRect.height)
                pos.y = canvasRect.height - (menuRect.height * 2);

            // If buildSlot position is inside Canvas, then show menu above buildSlot
            if (pos == originalPos)
                pos.y += menuRect.height;

            buildableMenu.transform.position = pos;

            buildableMenu.SetActive(true);
        }
    }
}