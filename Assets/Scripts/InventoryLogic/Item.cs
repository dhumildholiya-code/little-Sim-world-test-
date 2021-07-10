using LittleSimTest.Utils;
using UnityEngine;

namespace LittleSimTest.InventoryLogic
{
    [CreateAssetMenu(menuName = "Item", fileName = "Item", order = 1)]
    public class Item : ScriptableObject
    {
        [SerializeField] private EquipType type;
        [SerializeField]private int price;
        [SerializeField] private Sprite itemSprite;
        [SerializeField] private AnimationClip[] animationClips;

        public EquipType Type => type;
        public int Price => price;
        public Sprite Icon => itemSprite;

        public Inventory ParentInventory { private get; set; }

        public void Buy()
        {
            
        }

        public void Sell()
        {
            
        }

        public void Equip(SpriteRenderer spriteRenderer, AnimatorOverrideController animatorOverrideController)
        {
            spriteRenderer.color = Color.white;

            var clipNames = Constants.OverrideAnimationsName;
            for (var i = 0; i < clipNames.Length; i++)
            {
                animatorOverrideController[clipNames[i]] = animationClips[i];
            }
        }

        public void Dequip(SpriteRenderer spriteRenderer, AnimatorOverrideController animatorOverrideController)
        {
            var clipNames = Constants.OverrideAnimationsName;
            foreach (var clip in clipNames)
            {
                animatorOverrideController[clip] = null;
            }

            var c = spriteRenderer.color;
            c.a = 0;
            spriteRenderer.color = c;
        }
    }
}