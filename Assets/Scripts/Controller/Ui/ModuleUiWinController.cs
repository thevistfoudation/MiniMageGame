using Base.Core;
using Jinlab.ui.btn;
using TMPro;
using UI.LoadingScene;
using UnityEngine;
using UnityEngine.UI;
public class ModuleUiWinController : MonoBehaviour, IListenerBtn
{
    [SerializeField] private Button _replayBtn;
    [SerializeField] private Button _backToMainBtn;
    [SerializeField] private TextMeshProUGUI _numberEnemyDie;

    private void Awake()
    {
        OnClick();
    }

    public void InitilizerData(int numberEnemyDie)
    {
        _numberEnemyDie.text = "Number Eney was Kills : " + numberEnemyDie.ToString();
    }

    public void OnClick()
    {
        _replayBtn.onClick.AddListener(OnClickReplay);
        _backToMainBtn.onClick.AddListener(OnClickBackToMain);
    }

    private void OnClickReplay()
    {
        GameManager.Instance.LoadScene(SceneName.GamePlayScreen);
    }

    private void OnClickBackToMain()
    {
        GameManager.Instance.LoadScene(SceneName.HomeScene);
    }
}
