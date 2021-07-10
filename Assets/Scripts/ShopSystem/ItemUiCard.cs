using System;
using LittleSimTest.InventoryLogic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimTest.ShopSystem
{
    /// <summary>
    /// Handle UI for Item Class. Updates Information and delegate function call from user to Item class. 
    /// </summary>
    public class ItemUiCard : MonoBehaviour
    {
        [SerializeField] private Image iconImage;
        [SerializeField] private TextMeshProUGUI nameText;
        [SerializeField] private TextMeshProUGUI priceText;
        [SerializeField] private TextMeshProUGUI ownedText;
        [SerializeField] private Button buyButton;
        [SerializeField] private Button sellButton;
        [SerializeField] private Button equipButton;
        [SerializeField] private TextMeshProUGUI equipButtonText;
        
        private Item _item;
        private Inventory _interactedInventory;

        public void Init(Item item, Inventory interactionInventory)
        {
            _item = item;
            _interactedInventory = interactionInventory;
            UpdateUI();

            buyButton.onClick.AddListener(() => _item.Buy(_interactedInventory));
            sellButton.onClick.AddListener(()=>_item.Sell(_interactedInventory));
            equipButton.onClick.AddListener(()=> _item.Equip(_interactedInventory));

            _item.OnBuyItem += HandleBuyItem;
            _item.OnSellItem += HandleSellItem;
            _item.OnEquipItem += HandleEquipItem;
        }

        private void HandleSellItem(Item item)
        {
            if (_item == item)
            {
                ownedText.text = _item.IsOwned ? "Owned" : "";
                DisableAllActionButtons();
                buyButton.gameObject.SetActive(true);
            }
        }

        private void HandleEquipItem(Item item)
        {
            if (_item == item)
            {
                equipButtonText.text = _item.IsEquipped ? "UnEquip" : "Equip";
            }
        }

        private void HandleBuyItem(Item item)
        {
            if (_item == item)
            {
                ownedText.text = _item.IsOwned ? "Owned" : "";
                DisableAllActionButtons();
                equipButton.gameObject.SetActive(true);
                sellButton.gameObject.SetActive(true);
            }
        }

        private void UpdateUI()
        {
            iconImage.sprite = _item.Icon;
            nameText.text = _item.name;
            priceText.text = $"Price : {_item.Price}";
            ownedText.text = _item.IsOwned ? "Owned" : "";
            equipButton.gameObject.SetActive(_item.IsOwned);
            equipButtonText.text = _item.IsEquipped ? "Unequip" : "Equip";
            sellButton.gameObject.SetActive(_item.IsOwned);
            buyButton.gameObject.SetActive(!_item.IsOwned);
        }

        private void DisableAllActionButtons()
        {
            equipButton.gameObject.SetActive(false);
            sellButton.gameObject.SetActive(false);
            buyButton.gameObject.SetActive(false);
        }

        private void OnDestroy()
        {
            _item.OnBuyItem -= HandleBuyItem;
            _item.OnSellItem -= HandleSellItem;
            _item.OnEquipItem -= HandleEquipItem;
        }
    }
}