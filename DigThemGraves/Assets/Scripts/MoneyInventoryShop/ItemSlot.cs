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
                _item = value;

                image.sprite = _item.Sprite;
            }
        }

        public void Initialize(ItemInstance item)
        {
            inventory = GameObject.FindGameObjectWithTag("Player").GetComponent<InventoryController>();
            image = GetComponent<Image>();

            GetComponent<Button>().OnClickAsObservable()
                .Subscribe(_ => inventory.RemoveItem(Item));

            Item = item;
        }
    }
}