using System.Collections.Generic;
using LittleSimTest.Interface;
using LittleSimTest.InventoryLogic;
using UnityEngine;

namespace LittleSimTest.ShopSystem
{
    /// <summary>
    /// Handles Interaction between Player and ShopUI.
    /// Store Items present in shop.
    /// </summary>
    public class Shop : MonoBehaviour, INventoryINteractable
    {
        [SerializeField]
        private List<Item> items;

        [SerializeField] private ShopUI shopUI;

        private void Start()
        {
            shopUI.Init(items);
        }

        public void Open(Inventory interactedInventory)
        {
            shopUI.Open(interactedInventory);
        }

        public void Interact(Inventory interactedInventory)
        {
            shopUI.Open(interactedInventory);
        }
    }
}