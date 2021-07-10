using LittleSimTest.Utils;
using Unity.VisualScripting;
using UnityEngine;

namespace LittleSimTest.InventoryLogic
{
    /// <summary>
    /// Item Class which store information and functionalities for item.
    /// </summary>
    [CreateAssetMenu(menuName = "Item", fileName = "Item", order = 1)]
    public class Item : ScriptableObject
    {
        public event System.Action<Item> OnBuyItem;
        public event System.Action<Item> OnSellItem;
        public event System.Action<Item> OnEquipItem;

        [SerializeField] private EquipType type;
        [SerializeField] private int price;
        [SerializeField] private Sprite itemSprite;
        [SerializeField] private AnimationClip[] animationClips;

        public bool IsEquipped { get; set; }
        public EquipType Type => type;
        public int Price => price;
        public Sprite Icon => itemSprite;
        public bool IsOwned => ParentInventory != null;
        public AnimationClip[] AnimationClips => animationClips;

        public Inventory ParentInventory { private get; set; }

        /// <summary>
        /// Buy Item by adding into Inventory.
        /// </summary>
        /// <param name="inventory">Inventory which is interacted with Items</param>
        public void Buy(Inventory inventory)
        {
            inventory.AddItem(this);
            OnBuyItem?.Invoke(this);
        }

        /// <summary>
        /// Sell Item by Removing from Inventory
        /// </summary>
        /// <param name="inventory">Inventory which is interacted with Items</param>
        public void Sell(Inventory inventory)
        {
            inventory.Remove(this);
            OnSellItem?.Invoke(this);
        }

        /// <summary>
        /// Equip item
        /// </summary>
        /// <param name="inventory">Inventory which is interacted with Items</param>
        public void Equip(Inventory inventory)
        {
            IsEquipped = !IsEquipped;
            inventory.Equip(this, IsEquipped);
            OnEquipItem?.Invoke(this);
        }
    }
}