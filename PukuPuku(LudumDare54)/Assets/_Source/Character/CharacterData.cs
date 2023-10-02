using UnityEngine;

namespace Player
{
    public class CharacterData : MonoBehaviour
    {
        [SerializeField] private float speed;
        [SerializeField] private float rotationSpeed;
        [SerializeField] private float jumpForce;
        [SerializeField] private float groundDrag;
        [SerializeField] private float airMultiplier;
        [SerializeField] private float playerHeight;
        [SerializeField] private Rigidbody playerRb;
        [SerializeField] private Transform playerTransfrom;
        [SerializeField] private Transform orientation;
        [SerializeField] private Transform playerBodyTransfrom;
        [SerializeField] private Transform cameraTransfrom;
        [SerializeField] private LayerMask groundMask;
        [SerializeField] private bool fixRotation;

        public float Speed => speed;
        public float RotationSpeed => rotationSpeed;
        public float JumpForce => jumpForce;
        public float GroundDrag => groundDrag;
        public float AirMultiplier => airMultiplier;
        public float PlayerHeight => playerHeight;
        public Rigidbody PlayerRb => playerRb;
        public Transform PlayerTransfrom => playerTransfrom;
        public Transform Orientation => orientation;
        public Transform PlayerBodyTransfrom => playerBodyTransfrom;
        public Transform CameraTransfrom => cameraTransfrom;
        public LayerMask GroundMask => groundMask;
        public bool FixRotation => fixRotation;
    }
}