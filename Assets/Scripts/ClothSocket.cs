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

    /// <summary>
    /// Handle cloth animation and Equip and UnEquip of Clothes on player.
    /// </summary>
    public class ClothSocket : MonoBehaviour
    {
        public EquipType type;

        public Animator MyAnimator { get; set; }

        private SpriteRenderer _spriteRenderer;
        private Animator _parentAnimator;
        private AnimatorOverrideController _animatorOverrideController;

        private void Awake()
        {
            _spriteRenderer = GetComponent<SpriteRenderer>();
            _parentAnimator = GetComponentInParent<Animator>();
            MyAnimator = GetComponent<Animator>();

            _animatorOverrideController = new AnimatorOverrideController(MyAnimator.runtimeAnimatorController);

            MyAnimator.runtimeAnimatorController = _animatorOverrideController;
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
            _spriteRenderer.color = Color.white;

            var clipNames = Constants.OverrideAnimationsName;
            for (var i = 0; i < clipNames.Length; i++)
            {
                _animatorOverrideController[clipNames[i]] = item.AnimationClips[i];
            }
        }

        public void Remove()
        {
            var clipNames = Constants.OverrideAnimationsName;
            foreach (var clip in clipNames)
            {
                _animatorOverrideController[clip] = null;
            }

            var c = _spriteRenderer.color;
            c.a = 0;
            _spriteRenderer.color = c;
        }
    }
}