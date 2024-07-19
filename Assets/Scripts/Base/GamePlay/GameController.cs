using Controller.LoadData;
using jinLab.Model;
using Jinlab.ui.btn;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class GameController : MonoBehaviour,IListenerBtn
{
    [SerializeField] private TextMeshProUGUI _numberEnemyDie;
    [SerializeField] private Button pauseBtn;

    [SerializeField] private ModuleUiWinController _moduleUiWinController;
    [SerializeField] private ModuleUiPauseController _moduleUiPauseController;
   
    private int _countEnemyWasSpawn;
    private int _countEnemyDie;

    private int _obstacle;
    private int _maxEnemy;
    private float _rangeEnemy;
    private float _rangeObstacle;
    private GamePlayData _gamePlayData;

    private void Awake()
    {
        this.RegisterListener(EventID.EnemyDie, (sender, param) => CheckWinCondition());
        OnClick();
        InitilizerData();
    }

    private void Start()
    {
        _numberEnemyDie.text = "Enemies Die : " + _countEnemyDie.ToString();
        StartCoroutine(SpawnEnemy());
        CreateObstacle();
    }

    private void InitilizerData()
    {
        _gamePlayData = LoadResourceController.Instance.LoadGamePlayData();
        _rangeEnemy = _gamePlayData.rangeSpawnEnemy;
        _rangeObstacle = _gamePlayData.rangeSpawnObStacle;
        _obstacle = _gamePlayData.obstacle;
        _maxEnemy = _gamePlayData.enemy;
    }

    private void CheckWinCondition()
    {
        _countEnemyDie += 1;
        _numberEnemyDie.text = "Enemies Die : " + _countEnemyDie.ToString();
        if (_countEnemyDie >= _maxEnemy)
        {
            _moduleUiWinController.gameObject.SetActive(true);
            _moduleUiWinController.InitilizerData(_countEnemyDie);
        }
    }

    private IEnumerator SpawnEnemy()
    {
        while (_countEnemyWasSpawn < _maxEnemy)
        {
            _countEnemyWasSpawn++;
            var x = Random.Range(-_rangeEnemy, _rangeEnemy);
            var y = Random.Range(-_rangeEnemy, _rangeEnemy);
            Vector3 pos = new Vector3(x, y, 0);
            CreateController.Instance.EnemyController(pos);
            yield return new WaitForSeconds(3);
        }
    }

    private void CreateObstacle()
    {
        for (int i = 0; i < _obstacle; i++)
        {
            var x = Random.Range(-_rangeObstacle, _rangeObstacle);
            var y = Random.Range(-_rangeObstacle, _rangeObstacle);
            Vector3 pos = new Vector3(x, y, 0);
           
            var controller = CreateController.Instance;
            var index = Random.Range(0, controller.numberBarrel);
            controller.Barrel(pos, index);
        }
    }

    public void OnClick()
    {
        pauseBtn.onClick.AddListener(OnClickPause);
    }

    private void OnClickPause() 
    {
        Time.timeScale = 0;   
        _moduleUiPauseController.gameObject.SetActive(true);
    }
}
