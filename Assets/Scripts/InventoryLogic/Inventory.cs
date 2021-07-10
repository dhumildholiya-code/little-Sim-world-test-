using System.Collections.Generic;
using UnityEngine;

namespace LittleSimTest.InventoryLogic
{
    public class Inventory
    {
        private readonly List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        public void AddItem(Item item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
                item.ParentInventory = this;
            }
            else
            {
                Debug.Log($"You already have that item");
            }
        }

        public void Remove(Item item)
        {
            if (_items.Contains(item))
            {
                item.ParentInventory = null;
                _items.Remove(item);
            }
            else
            {
                Debug.Log($"You dont have item {item} in inventory to remove.");
            }
        }
    }
}