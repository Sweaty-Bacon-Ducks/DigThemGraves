using UniRx;
using UnityEngine;
using UnityEngine.UI;

namespace DigThemGraves
{
    public class ItemSlot : MonoBehaviour
    {
        private Image image;
        private InventoryController inventory;

        private ItemInstance _item;
        public ItemInstance Item
        {
            get { return _item; }
            set
            {
                GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => inventory.RemoveItem(Item));

                _item = value;

                image.sprite = _item.Sprite;
            }
        }


        private void Awake()
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>();
            image = GetComponent<Image>();
        }
    }
}