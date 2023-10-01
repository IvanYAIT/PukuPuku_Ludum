using Zenject;

namespace Claustrophobia
{
    public class ClaustrophobiaController
    {
        private ClaustrophobiaView _view;

        [Inject]
        public ClaustrophobiaController(ClaustrophobiaView view, ClaustrophobiaSettings settings)
        {
            _view = view;
            _view.SetMaxSliderValue(settings.MaxValue);
            House.Room.OnRoomChange += ChangeSliderValue;
            House.Room.OnPlayerInRoom += ShowSlider;
        }

        private void ChangeSliderValue(float value) =>
            _view.ChangeSliderValue(value);

        private void ShowSlider(bool value) =>
            _view.ShowSlider(value);
    }
}