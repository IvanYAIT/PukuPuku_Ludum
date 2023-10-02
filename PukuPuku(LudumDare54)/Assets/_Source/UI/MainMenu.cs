using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {
        private const string INFINITY_MODE = "Infinity";

        [SerializeField] private Button playBtn;
        void Start()
        {
            playBtn.onClick.AddListener(Play);
        }

        private void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            PlayerPrefs.SetInt(INFINITY_MODE, 0);
        }

        private void OnDestroy()
        {
            playBtn.onClick.RemoveListener(Play);
        }
    }
}