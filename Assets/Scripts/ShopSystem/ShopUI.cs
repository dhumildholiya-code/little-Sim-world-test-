using System;
using System.Collections.Generic;
using LittleSimTest.InventoryLogic;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimTest.ShopSystem
{
    /// <summary>
    /// Shows visual presentation of shop and its items.
    /// </summary>
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private ItemUiCard itemCardPrefab;
        [SerializeField] private Button closeButton;

        private List<Item> _items;
        private List<ItemUiCard> _itemsUiCards = new List<ItemUiCard>();
        private Inventory _interactInventory;

        private void Start()
        {
            closeButton.onClick.AddListener(Close);
        }

        public void Init(List<Item> items)
        {
            _items = items;
        }

        public void RefreshItems()
        {
            DeleteItems();
            foreach (var item in _items)
            {
                ItemUiCard itemUiCard = Instantiate(itemCardPrefab, container);
                itemUiCard.Init(item, _interactInventory);
                _itemsUiCards.Add(itemUiCard);
            }
        }

        private void DeleteItems()
        {
            if (_itemsUiCards == null && _itemsUiCards.Count <= 0) return;
            for (int i = _itemsUiCards.Count - 1; i >= 0; i--)
            {
                Destroy(_itemsUiCards[i].gameObject);
                _itemsUiCards.RemoveAt(i);
            }

            _itemsUiCards.Clear();
        }

        public void Open(Inventory inventory)
        {
            _interactInventory = inventory;
            gameObject.SetActive(true);
            RefreshItems();
        }

        public void Close()
        {
            DeleteItems();
            gameObject.SetActive(false);
        }
    }
}