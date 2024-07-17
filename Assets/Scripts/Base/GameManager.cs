
using UnityEngine;
using UI.LoadingScene;
namespace Base.Core
{
    public class GameManager : SingletonMono<GameManager>
    {
        private const int TargetFrameRate = 60;

        protected override void Awake()
        {
            base.Awake();
            SetForcedFrameRate();
            Invoke("LoadSceneMainMenu", 3f);
        }

        private void LoadSceneMainMenu()
        {
            LoadScene(SceneName.HomeScene);
        }

        public void SetForcedFrameRate()
        {
            QualitySettings.vSyncCount = 0;
            Application.targetFrameRate = TargetFrameRate;
        }

        public void LoadScene(SceneName sceneName, bool asyncLoad = true)
        {
            GameManager.Instance.StopAllCoroutines();
            if (asyncLoad)
            {

                LoadingScene.SetSceneName(sceneName);

                UnityEngine.SceneManagement.SceneManager.LoadScene(SceneName.LoadingScene.ToString());
            }
            else
            {
                UnityEngine.SceneManagement.SceneManager.LoadScene(sceneName.ToString());
            }
        }
    }
}