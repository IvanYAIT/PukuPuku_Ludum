using UnityEngine;
using UnityEngine.UI;

namespace UI
{
    public class WinMenuView : MonoBehaviour
    {
        [SerializeField] private Button continueBtn;
        [SerializeField] private Button backBtn;
        [SerializeField] private GameObject winPanel;

        public Button ContinueBtn => continueBtn;
        public Button BackBtn => backBtn;
        public GameObject WinPanel => winPanel;
    }
}