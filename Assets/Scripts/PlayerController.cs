using LittleSimTest.SO_Script;
using UnityEngine;

namespace LittleSimTest
{
    public class PlayerController : CharacterController
    {
        [SerializeField] private ClothSocket[] sockets;
        [SerializeField] private ClothItem item;

        private void OnEnable()
        {
            PopulateClothSocket();
        }

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

            if (Input.GetKeyDown(KeyCode.I))
            {
                foreach (var clothSocket in sockets)
                {
                    if (clothSocket.type == item.type)
                    {
                        clothSocket.Equip(item);
                    }
                }
            }

            if (Input.GetKeyDown(KeyCode.O))
            {
                foreach (var clothSocket in sockets)
                {
                    if (clothSocket.type == item.type)
                    {
                        clothSocket.Remove(item);
                    }
                }
            }
        }

        private void PopulateClothSocket()
        {
            sockets = GetComponentsInChildren<ClothSocket>();
        }
    }
}