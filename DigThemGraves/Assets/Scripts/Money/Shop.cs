using DigThemGraves;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Shop : MonoBehaviour
{
    [Tooltip("Items available for sale")]
    [SerializeField] private Item[] _shopItems;

    [SerializeField] GameObject _shopItemPrefab;
    [SerializeField] Transform _shopContainer;

    [SerializeField] MoneyPresenter _moneyPresenter;

    private void Start()
    {
        PopulateShop();
    }

    private void PopulateShop()
    {
        foreach (Item item in _shopItems)
        {
            GameObject itemObject = Instantiate(_shopItemPrefab, _shopContainer);

            itemObject.GetComponent<Button>().onClick.AddListener(() => OnShopItemButtonClick(item));

            //ItemSprite
            itemObject.transform.GetChild(0).GetComponent<Image>().sprite = item.Sprite;
            //ItemName
            itemObject.transform.GetChild(1).GetComponent<TextMeshProUGUI>().text = item.Name;
            //ItemCost
            itemObject.transform.GetChild(2).GetComponent<TextMeshProUGUI>().text = item.Cost.ToString();

            //Money sprite
            itemObject.transform.GetChild(3).GetComponent<Image>().sprite = _moneyPresenter.Model.Sprite;
        }
    }

    public void OnShopItemButtonClick(Item item)
    {
        if (_moneyPresenter.Model.Substract(item.Cost))
        {
            Debug.Log("Bought item " + item.Name);
        }
        else
        {
            Debug.Log("Cannot afford");
        }
    }
}
