using System;
using LittleSimTest.Interface;
using UnityEngine;
using LittleSimTest.InventoryLogic;
using LittleSimTest.SoundSystem;

namespace LittleSimTest
{
    /// <summary>
    /// Handles Player movement and interaction.
    /// </summary>
    public class PlayerController : CharacterController
    {
        [SerializeField] private Item[] defaultItems;
        [SerializeField] private ClothSocket[] sockets;
        [SerializeField] private LayerMask interactableLayer;

        private Inventory _inventory;
        private Camera _cam;
        private Vector2 _mouseWorldPosition;

        private void Start()
        {
            _cam = Camera.main;
            _inventory = new Inventory();
            _inventory.OnItemAdd += HandleItemAdded;
            _inventory.OnItemRemove += HandleItemRemoved;
            _inventory.OnItemEquipped += HandleItemEquipped;

            foreach (var defaultItem in defaultItems)
            {
                _inventory.AddItem(defaultItem);
                defaultItem.Equip(_inventory);
            }
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
                Collider2D col = Physics2D.OverlapCircle(_mouseWorldPosition, 0.2f, interactableLayer);
                if (!col) return;
                INventoryINteractable interactable = col.GetComponent<INventoryINteractable>();
                interactable?.Interact(_inventory);
            }
        }
        
        private void HandleItemRemoved(Item item)
        {
            SoundManager.Instance.PlayConfirmSound();
            foreach (var clothSocket in sockets)
            {
                if (clothSocket.type == item.Type)
                {
                    clothSocket.Remove();
                }
            }
        }

        private void HandleItemAdded(Item item)
        {
            // Debug.Log($"{this.name} bought {item.name}");
            SoundManager.Instance.PlayConfirmSound();
        }

        private void HandleItemEquipped(Item item, bool active)
        {
            foreach (var clothSocket in sockets)
            {
                if (clothSocket.type == item.Type)
                {
                    SoundManager.Instance.PlayOnEquipSound();
                    if(active)
                        clothSocket.Equip(item);
                    else
                        clothSocket.Remove();
                }
            }
        }

        private void PopulateClothSocket()
        {
            sockets = GetComponentsInChildren<ClothSocket>();
        }

        private void OnDestroy()
        {
            _inventory.OnItemAdd -= HandleItemAdded;
            _inventory.OnItemRemove -= HandleItemRemoved;
            _inventory.OnItemEquipped -= HandleItemEquipped;
        }
    }
}