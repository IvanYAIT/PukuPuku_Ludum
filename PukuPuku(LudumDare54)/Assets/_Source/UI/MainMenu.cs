using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace UI
{
    public class MainMenu : MonoBehaviour
    {

        [SerializeField] private Button playBtn;
        void Start()
        {
            playBtn.onClick.AddListener(Play);
        }

        private void Play()
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            
        }

        private void OnDestroy()
        {
            playBtn.onClick.RemoveListener(Play);
        }
    }
}