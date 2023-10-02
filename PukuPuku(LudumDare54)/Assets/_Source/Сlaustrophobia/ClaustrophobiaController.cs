using System;
using UnityEngine;
using Zenject;

namespace Claustrophobia
{
    public class ClaustrophobiaController
    {
        private const string INFINITY_MODE = "Infinity";

        public static Action OnZeroClaustrophobia;

        private ClaustrophobiaView _view;
        private float _level;
        private int _infinity;

        [Inject]
        public ClaustrophobiaController(ClaustrophobiaView view, ClaustrophobiaSettings settings)
        {
            _infinity = PlayerPrefs.GetInt(INFINITY_MODE, 0);
            _view = view;
            _view.SetMaxSliderValue(settings.MaxValue);
            _level = settings.MaxValue;
            House.Room.OnRoomChange += ChangeSliderValue;
            House.Room.OnPlayerInRoom += ShowSlider;
        }

        private void ChangeSliderValue(float value)
        {
            _infinity = PlayerPrefs.GetInt(INFINITY_MODE);
            if (_infinity == 0)
            {
                _view.ChangeSliderValue(value);
                _level += value;
                if (_level <= 0)
                {
                    _level = 0;
                    OnZeroClaustrophobia?.Invoke();
                }
            }
        }


        private void ShowSlider(bool value) =>
            _view.ShowSlider(value);
    }
}