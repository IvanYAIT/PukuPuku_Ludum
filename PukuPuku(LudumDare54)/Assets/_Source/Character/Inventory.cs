using UnityEngine;

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

        void Start()
        {
            itemLayer = (int)Mathf.Log(itemLayerMask.value,2);
        }


        void Update()
        {
            if (isItemPicked && !onCooldown && Input.GetKeyDown(KeyCode.E))
            {
                _currentObject.gameObject.transform.parent = transform.parent.parent.parent;
                _currentObject.gameObject.GetComponent<Rigidbody>().isKinematic = false;
                _currentObject = null;
                onCooldown = true;
                isItemPicked = false;
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
                    other.gameObject.GetComponent<Rigidbody>().isKinematic = true;
                    isItemPicked = true;
                    _currentObject = other.gameObject;
                    onCooldown = true;
                    Invoke(nameof(ResetCoolDown), COOLDOWN);
                }

            }
        }

        private void ResetCoolDown() =>
            onCooldown = false;
    }
}