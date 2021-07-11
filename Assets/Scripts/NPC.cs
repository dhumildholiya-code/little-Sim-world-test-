using LittleSimTest.DilogueSystem;
using LittleSimTest.Interface;
using LittleSimTest.InventoryLogic;
using UnityEngine;

namespace LittleSimTest
{
    public class NPC : MonoBehaviour, INventoryINteractable
    {
        [SerializeField] private Dialogue dialogue;
        
        public void Interact(Inventory interactedInventory)
        {
            DialogueController.Instance.StartDialogue(dialogue);
        }
    }
}