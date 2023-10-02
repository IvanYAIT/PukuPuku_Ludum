using UnityEngine;
using Zenject;

namespace Player
{
    public class InputListener : MonoBehaviour
    {
        private CharacterController _controller;
        private CharacterData _data;

        [Inject]
        public void Constructor(CharacterController characterController, CharacterData characterData)
        {
            _controller = characterController;
            _data = characterData;
        }

        private void Start()
        {
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
        }

        void Update()
        {
            _controller.GroundCheck(_data.PlayerRb, _data.PlayerTransfrom, _data.PlayerHeight, _data.GroundDrag, _data.GroundMask);

            Vector2 axises = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
            _controller.Move(_data.Orientation, _data.PlayerRb, axises, _data.Speed, _data.AirMultiplier);

            _controller.Rotate(_data.Orientation, _data.PlayerTransfrom, _data.PlayerBodyTransfrom, _data.CameraTransfrom, axises, _data.RotationSpeed, _data.FixRotation);

            if (Input.GetKeyDown(KeyCode.Space))
                _controller.Jump(_data.PlayerRb, _data.PlayerTransfrom, _data.JumpForce);
        }
    }
}