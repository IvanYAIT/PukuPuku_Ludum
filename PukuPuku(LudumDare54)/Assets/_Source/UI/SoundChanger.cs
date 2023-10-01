using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;

namespace Sound
{
    public class SoundChanger : MonoBehaviour
    {
        private const string MUSIC_VOLUME = "Music";

        [SerializeField] private Slider musicSlider;
        [SerializeField] private AudioMixer mixer;

        private void Start()
        {
            musicSlider.value = PlayerPrefs.GetFloat(MUSIC_VOLUME, 1f);

            musicSlider.onValueChanged.AddListener(ChangeMusic);

            PlayerPrefs.SetFloat(MUSIC_VOLUME, musicSlider.value);
        }

        public void ChangeMusic(float value)
        {
            if(value > 0)
                mixer.SetFloat(MUSIC_VOLUME, Mathf.Log10(value)*30);
            else
                mixer.SetFloat(MUSIC_VOLUME, -80);
        }
    }
}