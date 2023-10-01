using UnityEngine;
using UnityEngine.UI;

namespace Claustrophobia
{
    public class ClaustrophobiaView : MonoBehaviour
    {
        [SerializeField] private Slider slider;

        public void SetMaxSliderValue(float value, bool fill = true)
        {
            slider.maxValue = value;

            if (fill)
                slider.value = value;
            else
                slider.value = 0;
        }

        public void ChangeSliderValue(float value) =>
            slider.value += value;

        public void ShowSlider(bool value) =>
            slider.gameObject.SetActive(value);
    }
}