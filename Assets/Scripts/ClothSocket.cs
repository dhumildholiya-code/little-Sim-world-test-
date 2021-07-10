using LittleSimTest.Utils;
using UnityEngine;

namespace LittleSimTest
{
    public class ClothSocket : MonoBehaviour
    {
        [SerializeField] private AnimationClip[] animationClips;
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

        private void Update()
        {
            if (Input.GetKeyDown(KeyCode.I))
            {
                Equip(animationClips);
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                Dequip();
            }
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

        private void Equip(AnimationClip[] clips)
        {
            _spriteRenderer.color = Color.white;
            
            var clipNames = Constants.OverrideAnimationsName;
            for (int i = 0; i < clipNames.Length; i++)
            {
                _animatorOverrideController[clipNames[i]] = clips[i];
            }
        }

        private void Dequip()
        {
            var clipNames = Constants.OverrideAnimationsName;
            for (int i = 0; i < clipNames.Length; i++)
            {
                _animatorOverrideController[clipNames[i]] = null;
            }

            var c = _spriteRenderer.color;
            c.a = 0;
            _spriteRenderer.color = c;
        }
    }
}