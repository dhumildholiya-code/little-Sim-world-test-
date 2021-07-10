using LittleSimTest.Interface;
using UnityEngine;
using LittleSimTest.InventoryLogic;
using UnityEditor.Experimental.GraphView;

namespace LittleSimTest
{
    public class PlayerController : CharacterController
    {
        [SerializeField] private ClothSocket[] sockets;
        [SerializeField] private LayerMask interactableLayer;

        private Inventory _inventory;
        private Camera _cam;
        private Vector2 _mouseWorldPosition;

        private void Start()
        {
            _cam = Camera.main;
            _inventory = new Inventory();
        }

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

            _mouseWorldPosition = _cam.ScreenToWorldPoint(Input.mousePosition);
            if (Input.GetMouseButtonDown(0))
            {
                Debug.Log("Hello");
                Collider2D col = Physics2D.OverlapCircle(_mouseWorldPosition, 0.2f, interactableLayer);
                if (!col) return;
                INteractable interactable = col.GetComponent<INteractable>();
                Debug.Log(interactable.ToString());
                interactable?.Interact();
            }
        }

        private void PopulateClothSocket()
        {
            sockets = GetComponentsInChildren<ClothSocket>();
        }
    }
}