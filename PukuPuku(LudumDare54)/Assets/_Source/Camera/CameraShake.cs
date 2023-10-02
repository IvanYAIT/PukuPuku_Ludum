using Cinemachine;
using UnityEngine;
using Claustrophobia;
using Zenject;

namespace Camera
{
    public class CameraShake : MonoBehaviour
    {
        [SerializeField] private CinemachineFreeLook freeLook;

        private float _currentShakePower;

        [Inject]
        public void Construct(ClaustrophobiaSettings settings)
        {
            _currentShakePower = settings.MaxValue;
        }

        private void Start()
        {
            House.Room.OnRoomChange += ChangePower;
            House.Room.OnPlayerInRoom += Shake;
        }

        private void Shake(bool obj)
        {
            if (obj)
            {
                ChangeRigsPower(_currentShakePower);
            }
            else
                ChangeRigsPower(0f);
        }

        private void ChangePower(float value)
        {
            _currentShakePower += value;
            if (_currentShakePower <= 0)
                _currentShakePower = 0;
        }

        private void ChangeRigsPower(float value)
        {
            freeLook.GetRig(0).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = value;
            freeLook.GetRig(1).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = value;
            freeLook.GetRig(2).GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>().m_AmplitudeGain = value;
        }
    }
}