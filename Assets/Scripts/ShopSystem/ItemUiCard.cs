using LittleSimTest.InventoryLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimTest.ShopSystem
{
    public class ItemUiCard : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI ownedText;
        [SerializeField] private Button[] actionButtons;

        private Item _item;

        public void Init(Item item)
        {
            _item = item;
            UpdateUI();
        }

        private void UpdateUI()
        {
            iconImage.sprite = _item.Icon;
            nameText.text = _item.name;
            priceText.text = $"Price : {_item.Price}";
            ownedText.text = "";
        }
    }
}