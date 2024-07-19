using Base.Core;
using Jinlab.ui.btn;
using System.Collections;
using System.Collections.Generic;
using UI.LoadingScene;
using UnityEngine;
using UnityEngine.UI;

public class ModuleUiPauseController : MonoBehaviour, IListenerBtn
{
    [SerializeField] private Button _replayBtn;
    [SerializeField] private Button _resumeBtn;

    private void Awake()
    {
        OnClick();
    }

    public void OnClick()
    {
        _replayBtn.onClick.AddListener(OnClickReplay);
        _resumeBtn.onClick.AddListener(OnClickResume);
    }

    private void OnClickReplay()
    {
        Time.timeScale = 1;
        GameManager.Instance.LoadScene(SceneName.GamePlayScreen);
    }

    private void OnClickResume()
    {
        Time.timeScale = 1;
        gameObject.SetActive(false);
    }
}
