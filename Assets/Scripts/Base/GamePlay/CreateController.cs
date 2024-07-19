using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UniRx.Examples;
using UnityEngine;
using static UnityEditor.PlayerSettings;

public class CreateController : SingletonMono<CreateController>
{
    [SerializeField] private BulletController _bullet;
    [SerializeField] private EnemyController _enemy;
    [SerializeField] private GameObject _smoke;
    [SerializeField] private GameObject[] _barrels;

    public int numberBarrel => _barrels.Length;

    public GameObject Barrel(Vector3 pos, int index)
    {
        var barrel = SmartPool.Instance.Spawn(_barrels[index], pos, _barrels[index].transform.rotation);
        return barrel;
    }

    public EnemyController EnemyController(Vector3 pos)
    {
        var enemyObj = SmartPool.Instance.Spawn(_enemy.gameObject, pos, _enemy.transform.rotation);
        return enemyObj.GetComponent<EnemyController>();
    }

    public BulletController BulletController(Transform pos)
    {
        var bulletObj = SmartPool.Instance.Spawn(_bullet.gameObject, pos.position,pos.rotation);
        return bulletObj.GetComponent<BulletController>();
    }

    public GameObject Smoke(Transform pos)
    {
        var smokeObj = SmartPool.Instance.Spawn(_smoke.gameObject, pos.position, pos.rotation);
        return smokeObj;
    }
}
