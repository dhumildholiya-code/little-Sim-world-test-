using LittleSimTest.InventoryLogic;
using LittleSimTest.Utils;
using UnityEngine;

namespace LittleSimTest
{
    [System.Serializable]
    public enum EquipType
    {
        Body,
        Leg,
    }

    public class ClothSocket : MonoBehaviour
    {
        [SerializeField] private Item defaultItem;
        public EquipType type;
        
        public Animator MyAnimator { get; set; }

        private SpriteRenderer _spriteRenderer;
        private Animator _parentAnimator;
        private AnimatorOverrideController _animatorOverrideController;
        private Item _currentItem;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _parentAnimator = GetComponentInParent<Animator>();
            MyAnimator = GetComponent<Animator>();

            _animatorOverrideController = new AnimatorOverrideController(MyAnimator.runtimeAnimatorController);

            MyAnimator.runtimeAnimatorController = _animatorOverrideController;

            if (defaultItem) Equip(defaultItem);
        }

        public void HandleAnimation(float x, float y)
        {
            MyAnimator.SetFloat("x", x);
            MyAnimator.SetFloat("y", y);
        }

        public void ActivateLayer(string layerName)
        {
            for (int i = 0; i < MyAnimator.layerCount; i++)
            {
                MyAnimator.SetLayerWeight(i, 0);
            }

            MyAnimator.SetLayerWeight(MyAnimator.GetLayerIndex(layerName), 1);
        }

        public void Equip(Item item)
        {
            item.Equip(_spriteRenderer, _animatorOverrideController);
            _currentItem = item;
        }

        public void Remove(Item item)
        {
            item.Dequip(_spriteRenderer, _animatorOverrideController);
            _currentItem = null;
            Equip(defaultItem);
        }
    }
}