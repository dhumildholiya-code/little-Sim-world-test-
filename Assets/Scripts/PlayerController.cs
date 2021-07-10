using UnityEngine;
using UnityEngine.EventSystems;

namespace LittleSimTest
{
    public class PlayerController : CharacterController
    {
        protected override void Update()
        {
            GetInput();
            base.Update();
        }

        private void GetInput()
        {
            Direction = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        }
    }
}