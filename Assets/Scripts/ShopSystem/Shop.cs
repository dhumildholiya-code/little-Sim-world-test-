using System;
using System.Collections.Generic;
using LittleSimTest.Interface;
using LittleSimTest.InventoryLogic;
using UnityEngine;

namespace LittleSimTest.ShopSystem
{
    public class Shop : MonoBehaviour, INteractable
    {
        [SerializeField]
        private List<Item> items;

        [SerializeField] private ShopUI shopUI;

        private void Start()
        {
            shopUI.Init(items);
        }

        public void Interact()
        {
            shopUI.Open();
        }
    }
}