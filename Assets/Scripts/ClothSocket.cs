using LittleSimTest.SO_Script;
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
        [SerializeField] private ClothItem defaultClothItem;
        public EquipType type;
        
        public Animator MyAnimator { get; set; }

        private SpriteRenderer _spriteRenderer;
        private Animator _parentAnimator;
        private AnimatorOverrideController _animatorOverrideController;
        private ClothItem _currentClothItem;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _parentAnimator = GetComponentInParent<Animator>();
            MyAnimator = GetComponent<Animator>();

            _animatorOverrideController = new AnimatorOverrideController(MyAnimator.runtimeAnimatorController);

            MyAnimator.runtimeAnimatorController = _animatorOverrideController;

            if (defaultClothItem) Equip(defaultClothItem);
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

        public void Equip(ClothItem item)
        {
            item.Equip(_spriteRenderer, _animatorOverrideController);
            _currentClothItem = item;
        }

        public void Remove(ClothItem item)
        {
            item.Remove(_spriteRenderer, _animatorOverrideController);
            _currentClothItem = null;
            Equip(defaultClothItem);
        }
    }
}