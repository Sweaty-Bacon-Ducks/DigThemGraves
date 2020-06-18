using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace DigThemGraves
{
    public class ShopView : MonoBehaviour
    {
        [Tooltip("Items available for sale")]
        [SerializeField] private ItemTemplate[] shopItems;

        [SerializeField] private GameObject shopItemPrefab;
        [SerializeField] private Transform shopContainer;

        [SerializeField] private Sprite moneySprite;

        [SerializeField] private Inventory inventory;

        private void Start()
        {
            PopulateShop();
        }

        private void PopulateShop()
        {
            foreach (ItemTemplate item in shopItems)
            {
                GameObject itemObject = Instantiate(shopItemPrefab, shopContainer);

                itemObject.GetComponent<Button>().onClick.AddListener(() => OnShopItemButtonClick(item));

                //ItemSprite
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite = item.Sprite;
                //ItemName
                itemObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.Name;
                //ItemCost
                itemObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.Cost.ToString();

                //Money sprite
                itemObject.transform.GetChild(3).GetComponent<Image>().sprite = moneySprite;
            }
        }

        // logika chyba do kontrolera
        public void OnShopItemButtonClick(ItemTemplate item)
        {
            if (inventory.IsFull)
            {
                Debug.Log("No space for the item");
                return;
            }
            if (inventory.Money.CanAfford(item.Cost))
            {
                inventory.Money.SubtractMoney(item.Cost);
                inventory.AddItem(item);
                Debug.Log("Bought item " + item.Name);
            }
            else
            {
                Debug.Log("Cannot afford");
            }
        }
    }
}