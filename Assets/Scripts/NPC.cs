using System;
using LittleSimTest.DilogueSystem;
using LittleSimTest.Interface;
using LittleSimTest.InventoryLogic;
using LittleSimTest.ShopSystem;
using UnityEngine;

namespace LittleSimTest
{
    public class NPC : MonoBehaviour, INventoryINteractable
    {
        [SerializeField] private Dialogue dialogue;
        [SerializeField] private Shop shop;

        private Inventory _currentInteractInventory;

        private void Start()
        {
            DialogueController.Instance.OnEndDialogue += HandleDialogueEnd;
        }

        private void OnDestroy()
        {
            DialogueController.Instance.OnEndDialogue += HandleDialogueEnd;
        }

        private void HandleDialogueEnd()
        {
            shop.Open(_currentInteractInventory);
        }

        public void Interact(Inventory interactedInventory)
        {
            DialogueController.Instance.StartDialogue(dialogue);
            _currentInteractInventory = interactedInventory;
        }
    }
}