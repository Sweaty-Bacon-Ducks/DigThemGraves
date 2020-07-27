using TMPro;
using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace DigThemGraves
{
    //TODO: Separate this script to MVC when upgrading shop functionality
    public class Shop : MonoBehaviour
    {
        [Tooltip("Items available for sale")]
        [SerializeField] private ItemTemplate[] shopItems;

        [SerializeField] private GameObject shopItemPrefab;

        [SerializeField] private Transform shopParent;

        private InventoryController inventoryController;
        private MoneyController moneyController;

        private void Awake()
        {
            inventoryController = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>();
            moneyController = GameObject.FindGameObjectWithTag("Player").GetComponent<MoneyController>();
        }

        private void Start()
        {
            PopulateShop();
        }

        private void PopulateShop()
        {
            foreach (ItemTemplate item in shopItems)
            {
                GameObject itemObject = Instantiate(shopItemPrefab, shopParent);

                itemObject.GetComponent<Button>()
                    .onClick
                    .AsObservable()
                    .Subscribe(_ => OnShopItemButtonClick(item));

                //ItemSprite
                itemObject.transform.GetChild(0).GetComponent<Image>().sprite = item.Sprite;
                //ItemName
                itemObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.Name;
                //ItemCost
                itemObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.Cost.ToString();

                //Money sprite
                itemObject.transform.GetChild(3).GetComponent<Image>().sprite = moneyController.Sprite;
            }
        }

        public void OnShopItemButtonClick(ItemTemplate item)
        {
            if (moneyController.CanAfford(item.Cost))
            {
                moneyController.SubtractMoney(item.Cost);
                inventoryController.AddItem(item);
            }
            else
            {
                Debug.Log("Cannot afford");
            }
        }
    }
}