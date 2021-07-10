using LittleSimTest.InventoryLogic;

namespace LittleSimTest.Interface
{
    /// <summary>
    /// Interface to interact with object who communicate with Inventories.
    /// </summary>
    public interface INventoryINteractable
    {
        void Interact(Inventory interactedInventory);
    }
}