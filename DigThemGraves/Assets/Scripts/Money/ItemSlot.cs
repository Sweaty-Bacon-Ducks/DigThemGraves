using UnityEngine;
using UnityEngine.UI;

namespace DigThemGraves
{
    public class ItemSlot : MonoBehaviour
    {
        [SerializeField] private Image image;

        private ItemInstance _item;
        public ItemInstance Item
        {
            get { return _item; }
            set
            {
                _item = value;

                if (_item == null)
                    image.enabled = false;
                else
                {
                    image.sprite = _item.Sprite;
                    image.enabled = true;
                }
            }
        }

        private void OnValidate()
        {
            if (image == null)
            {
                image = GetComponent<Image>();
            }
        }
    }
}