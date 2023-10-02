using System;
using UnityEngine;
using Zenject;
using Claustrophobia;
using UnityEngine.UI;

namespace House
{
    public class Room : MonoBehaviour
    {
        public static Action<float> OnRoomChange;
        public static Action<bool> OnPlayerInRoom;

        [SerializeField] private LayerMask itemLayerMask;
        [SerializeField] private LayerMask playerLayerMask;
        [SerializeField] private GameObject tutor;
        [SerializeField] private Button onBtn;

        private int _itemLayer;
        private int _playerLayer;
        private float _valuePerItem;
        private bool firstTime = true;

        [Inject]
        public void Construct(ClaustrophobiaSettings settings)
        {
            _valuePerItem = settings.ValuePerItem;
            onBtn.onClick.AddListener(Back);
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
            {
                OnPlayerInRoom?.Invoke(true);
                if (firstTime)
                {
                    ShowScreen();
                    firstTime = false;
                }
            }
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

        private void ShowScreen()
        {
            Time.timeScale = 0;
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            tutor.SetActive(true);
        }

        private void Back()
        {
            Time.timeScale = 1;
            Cursor.lockState = CursorLockMode.Locked;
            Cursor.visible = false;
            tutor.SetActive(false);
        }
    }
}