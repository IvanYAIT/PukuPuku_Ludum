using UnityEngine;
using Zenject;

namespace Player
{
    public class Inventory : MonoBehaviour
    {
        [SerializeField] private LayerMask itemLayerMask;

        private GameObject _currentObject;
        private int itemLayer;
        private bool isItemPicked;
        private bool onCooldown;
        private const float COOLDOWN = 0.5f;
        private FixedJoint _joint;
        private CharacterAnimationController _animationController;

        [Inject]
        public void Construct(CharacterAnimationController animationController)
        {
            _animationController = animationController;
        }

        void Start()
        {
            itemLayer = (int)Mathf.Log(itemLayerMask.value,2);
            _joint = GetComponent<FixedJoint>();
        }

        void Update()
        {
            if (isItemPicked && !onCooldown && Input.GetKeyDown(KeyCode.E))
            {
                _currentObject.gameObject.transform.parent = transform.parent.parent.parent;
                _joint.connectedBody = null;
                _currentObject = null;
                onCooldown = true;
                isItemPicked = false;
                _animationController.ItemPickedUp(isItemPicked);
                Invoke(nameof(ResetCoolDown), COOLDOWN);
            }
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == itemLayer)
            {
                if (!isItemPicked && !onCooldown && Input.GetKey(KeyCode.E))
                {
                    other.gameObject.transform.parent = transform;
                    other.gameObject.transform.position = transform.position;
                    _joint.connectedBody = other.gameObject.GetComponent<Rigidbody>();
                    isItemPicked = true;
                    _currentObject = other.gameObject;
                    onCooldown = true;
                    _animationController.ItemPickedUp(isItemPicked);
                    Invoke(nameof(ResetCoolDown), COOLDOWN);
                }

            }
        }

        private void ResetCoolDown() =>
            onCooldown = false;
    }
}