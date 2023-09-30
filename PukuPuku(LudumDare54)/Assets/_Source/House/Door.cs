using UnityEngine;

namespace House
{
    public class Door : MonoBehaviour
    {
        [SerializeField] private Transform spawnpoint;
        [SerializeField] private LayerMask playerLayerMask;

        private int playerLayer;

        void Start()
        {
            playerLayer = (int)Mathf.Log(playerLayerMask.value, 2);
        }

        private void OnTriggerStay(Collider other)
        {
            if (other.gameObject.layer == playerLayer)
                if(Input.GetKeyDown(KeyCode.F))
                    other.gameObject.transform.position = spawnpoint.position;
        }
    }
}