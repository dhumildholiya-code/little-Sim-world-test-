using UnityEngine;

namespace LittleSimTest
{
    public class PlayerController : CharacterController
    {
        [SerializeField] private ClothSocket[] sockets;
        
        protected override void Update()
        {
            GetInput();
            base.Update();
        }

        protected override void HandleAnimationLayers()
        {
            base.HandleAnimationLayers();
            if (!IsMoving) return;
            foreach (var clothSocket in sockets)
            {
                clothSocket.HandleAnimation(Direction.x, Direction.y);
            }
        }

        protected override void ActivateLayer(string layerName)
        {
            base.ActivateLayer(layerName);
            foreach (var clothSocket in sockets)
            {
                clothSocket.ActivateLayer(layerName);
            }
        }

        private void GetInput()
        {
            Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}