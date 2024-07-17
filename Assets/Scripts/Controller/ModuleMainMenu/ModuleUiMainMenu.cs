
using Base.Core;
using Jinlab.ui.btn;
using UI.LoadingScene;
using UnityEngine;
using UnityEngine.UI;

namespace Jinlab.ModuleUi.MainMenu
{
    public class ModuleUiMainMenu : MonoBehaviour, IListenerBtn
    {
        [SerializeField] private Button _playBtn;

        private void Awake()
        {
            OnClick();
        }

        public void OnClick()
        {
            _playBtn.onClick.AddListener(OnclickPlay);
        }

        private void OnclickPlay()
        {
            GameManager.Instance.LoadScene(SceneName.GamePlayScreen);
        }
    }
}

