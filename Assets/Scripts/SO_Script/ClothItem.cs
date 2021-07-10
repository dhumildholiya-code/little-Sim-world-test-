using UnityEngine;
using LittleSimTest.Utils;


namespace LittleSimTest.SO_Script
{
    [CreateAssetMenu(menuName = "ClothItem", fileName = "Cloth Item", order = 1)]
    public class ClothItem : ScriptableObject
    {
        public EquipType type;
        [SerializeField] private AnimationClip[] animationClips;

        public void Equip(SpriteRenderer spriteRenderer, AnimatorOverrideController animatorOverrideController)
        {
            spriteRenderer.color = Color.white;

            var clipNames = Constants.OverrideAnimationsName;
            for (var i = 0; i < clipNames.Length; i++)
            {
                animatorOverrideController[clipNames[i]] = animationClips[i];
            }
        }

        public void Remove(SpriteRenderer spriteRenderer, AnimatorOverrideController animatorOverrideController)
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