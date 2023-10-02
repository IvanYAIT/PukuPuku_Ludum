using UnityEngine;
using Claustrophobia;
using UnityEngine.SceneManagement;
using Zenject;

namespace UI
{
    public class WinMenuController
    {
        private const string INFINITY_MODE = "Infinity";
        private WinMenuView _view;

        [Inject]
        public WinMenuController(WinMenuView view)
        {
            _view = view;
            ClaustrophobiaController.OnZeroClaustrophobia += ShowScreen;
            _view.ContinueBtn.onClick.AddListener(Continue);
            _view.BackBtn.onClick.AddListener(Back);
        }

        private void ShowScreen()
        {
            _view.WinPanel.SetActive(true);
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
            Time.timeScale = 0;
        }

        private void Continue()
        {
            _view.WinPanel.SetActive(false);
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
            PlayerPrefs.SetInt(INFINITY_MODE , 1);
            Time.timeScale = 1;
        }

        private void Back()
        {
            SceneManager.LoadScene(0);
            Time.timeScale = 1;
        }
    }
}