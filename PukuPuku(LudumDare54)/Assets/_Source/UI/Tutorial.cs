using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class Tutorial : MonoBehaviour
    {
        private const string INFINITY_MODE = "Infinity";

        [SerializeField] private Button nextBtn;
        [SerializeField] private Button playBtn;
        [SerializeField] private List<GameObject> screens;

        private int _counter;

        void Start()
        {
            nextBtn.onClick.AddListener(NextDialog);
            playBtn.onClick.AddListener(Play);
            screens[0].SetActive(true);
        }

        private void NextDialog()
        {
            _counter++;
            if (_counter < screens.Count)
            {
                screens[_counter-1].SetActive(true);
                screens[_counter].SetActive(true);
                if(_counter == screens.Count - 1)
                {
                    nextBtn.gameObject.SetActive(false);
                    playBtn.gameObject.SetActive(true);
                }
            }
        }

        private void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt(INFINITY_MODE, 0);
        }
    }
}