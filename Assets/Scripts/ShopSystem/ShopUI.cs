using System;
using System.Collections.Generic;
using LittleSimTest.InventoryLogic;
using UnityEngine;
using UnityEngine.UI;

namespace LittleSimTest.ShopSystem
{
    public class ShopUI : MonoBehaviour
    {
        [SerializeField] private Transform container;
        [SerializeField] private ItemUiCard itemCardPrefab;
        [SerializeField] private Button closeButton;

        private List<Item> _items;
        private List<ItemUiCard> _itemsUiCards;

        private void Start()
        {
            closeButton.onClick.AddListener(Close);
        }

        public void Init(List<Item> items)
        {
            _items = items;
            _itemsUiCards = new List<ItemUiCard>();
        }

        public void RefreshItems()
        {
            DeleteItems();
            foreach (var item in _items)
            {
                ItemUiCard itemUiCard = Instantiate(itemCardPrefab, container);
                itemUiCard.Init(item);
                _itemsUiCards.Add(itemUiCard);
            }
        }

        private void DeleteItems()
        {
            if (_itemsUiCards == null && _itemsUiCards.Count <= 0) return;
            for (int i = _itemsUiCards.Count - 1; i >= 0; i--)
            {
                Destroy(_itemsUiCards[i]);
                _itemsUiCards.RemoveAt(i);
            }

            _itemsUiCards.Clear();
        }

        public void Open()
        {
            gameObject.SetActive(true);
            RefreshItems();
        }

        public void Close()
        {
            gameObject.SetActive(false);
        }
    }
}