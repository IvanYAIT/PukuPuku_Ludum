using System;
using UnityEngine;
using Zenject;
using Claustrophobia;

namespace House
{
    public class Room : MonoBehaviour
    {
        public static Action<float> OnRoomChange;
        public static Action<bool> OnPlayerInRoom;

        [SerializeField] private LayerMask itemLayerMask;
        [SerializeField] private LayerMask playerLayerMask;

        private int _itemLayer;
        private int _playerLayer;
        private float _valuePerItem;

        [Inject]
        public void Construct(ClaustrophobiaSettings settings)
        {
            _valuePerItem = settings.ValuePerItem;
        }

        private void Start()
        {
            _itemLayer = (int)Mathf.Log(itemLayerMask.value, 2);
            _playerLayer = (int)Mathf.Log(playerLayerMask.value, 2);
        }

        private void OnTriggerEnter(Collider other)
        {
            if(other.gameObject.layer == _itemLayer)
            {
                OnRoomChange?.Invoke(-_valuePerItem);
            }
            if (other.gameObject.layer == _playerLayer)
                OnPlayerInRoom?.Invoke(true);
        }

        private void OnTriggerExit(Collider other)
        {
            if (other.gameObject.layer == _itemLayer)
            {
                OnRoomChange?.Invoke(_valuePerItem);
            }
            if (other.gameObject.layer == _playerLayer)
                OnPlayerInRoom?.Invoke(false);
        }
    }
}