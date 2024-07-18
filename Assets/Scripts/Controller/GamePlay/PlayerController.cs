using Com.LuisPedroFonseca.ProCamera2D;
using System.Collections;
using System.Collections.Generic;
using UniRx;
using UnityEngine;
using jinLab.Model;
using System.Net.WebSockets;
using Controller.LoadData;

public class PlayerController : CharacterController
{
    private PlayerData _playerData;
    private BulletPlayerData _bulletPlayerData;
    private float _timeShoot;
    private float _countTime;
    public static PlayerController Instance;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }

    private void Start()
    {
        ProCamera2D.Instance.AddCameraTarget(transform);
        InitilizerData();
    }

    private void InitilizerData()
    {
        _playerData = LoadResourceController.Instance.LoadPlayerData();
        _bulletPlayerData = LoadResourceController.Instance.LoadBulletPlayerData();

        speed = _playerData.speed;
        _timeShoot = _playerData.timeShoot;
    }

    private void Update()
    {

        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");
        Vector3 direction = new Vector3(horizontal, vertical);
        Move(direction);

        Vector3 gunDirection = new Vector3(
               Input.mousePosition.x - Screen.width / 2,
               Input.mousePosition.y - Screen.height / 2
           );
        RotateGun(gunDirection);

        if (Input.GetMouseButton(0))
        {
            _countTime -= Time.deltaTime;
            if (_countTime <= 0)
            {
                ShootBullet();
                _countTime = _timeShoot;
            }
           
        }
    }

    private void ShootBullet()
    {
        var speedData = _bulletPlayerData.speed;
        var damageData = _bulletPlayerData.damage;
        var timeData = _bulletPlayerData.time;
        var bounceData = _bulletPlayerData.bounceMax;
        var penetration = _bulletPlayerData.penetrationMax;
        Shoot(speedData, damageData, timeData, bounceData, penetration);
        _countTime = _timeShoot;
    }
  
}
