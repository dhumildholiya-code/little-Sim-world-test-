using System.Net.Http.Headers;
using UnityEngine;

namespace LittleSimTest
{
    /// <summary>
    /// Handles core Movement logic and Aniamtion for any character.
    /// </summary>
    [RequireComponent(typeof(Rigidbody2D))]
    [RequireComponent(typeof(Animator))]
    public abstract class CharacterController : MonoBehaviour
    {
        [SerializeField] private float speed;

        private Rigidbody2D _rb;
        private Animator _myAnimator;

        protected Vector2 Direction;
        protected bool IsMoving => Direction.x != 0 || Direction.y != 0;

        protected virtual void Awake()
        {
            _rb = GetComponent<Rigidbody2D>();
            _myAnimator = GetComponent<Animator>();
        }

        protected virtual void Update()
        {
            HandleAnimationLayers();
        }

        private void FixedUpdate()
        {
            Move();
        }

        private void Move()
        {
            _rb.velocity = Direction.normalized * speed;
        }

        protected virtual void HandleAnimationLayers()
        {
            if (IsMoving)
            {
                ActivateLayer("WalkLayer");
                _myAnimator.SetFloat("x", Direction.x);
                _myAnimator.SetFloat("y", Direction.y);
            }
            else
            {
                ActivateLayer("IdleLayer"); 
            }
        }


        protected virtual void ActivateLayer(string layerName)
        {
            for (int i = 0; i < _myAnimator.layerCount; i++)
            {
                _myAnimator.SetLayerWeight(i, 0);
            }

            _myAnimator.SetLayerWeight(_myAnimator.GetLayerIndex(layerName), 1);
        }
    }
}