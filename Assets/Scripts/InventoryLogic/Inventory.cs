using System;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;

namespace LittleSimTest.InventoryLogic
{
    /// <summary>
    /// Inventory Class stores items and work as middle layer between Item and Inventory Holder.
    /// </summary>
    public class Inventory
    {
        public event Action<Item> OnItemAdd;
        public event Action<Item> OnItemRemove;
        public event Action<Item, bool> OnItemEquipped;

        private readonly List<Item> _items;

        public Inventory()
        {
            _items = new List<Item>();
        }

        /// <summary>
        /// Add item in Inventory if does not exist in inventory.
        /// </summary>
        /// <param name="item"> Item to add in Inventory</param>
        public void AddItem(Item item)
        {
            if (!_items.Contains(item))
            {
                _items.Add(item);
                item.ParentInventory = this;
                OnItemAdd?.Invoke(item);
            }
            else
            {
                Debug.Log($"You already have that item");
            }
        }

        /// <summary>
        /// Remove Item from Inventory if it is in Inventory.
        /// </summary>
        /// <param name="item">Item to remove from Inventory</param>
        public void Remove(Item item)
        {
            if (_items.Contains(item))
            {
                item.ParentInventory = null;
                _items.Remove(item);
                OnItemRemove?.Invoke(item);
            }
            else
            {
                Debug.Log($"You dont have item {item} in inventory to remove.");
            }
        }

        /// <summary>
        /// Equip/Dequip Item if it is in Inventory
        /// </summary>
        /// <param name="item">Item to Equip/Dequip </param>
        /// <param name="active">true for Equip and false for Dequip</param>
        public void Equip(Item item, bool active)
        {
            var sameItemTypeList = _items.Where((x) => x.Type == item.Type).ToList();
            foreach (var sameTypeItem in sameItemTypeList)
            {
                if (item == sameTypeItem)
                {
                    OnItemEquipped?.Invoke(item, active);
                }
                else
                {
                    sameTypeItem.Dequip(this);
                }
            }
        }
    }
}