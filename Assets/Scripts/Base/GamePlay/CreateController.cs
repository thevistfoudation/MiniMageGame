using Core.Pool;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateController : SingletonMono<CreateController>
{
    [SerializeField] private BulletController bullet;
    [SerializeField] private GameObject smoke;


    public BulletController BulletController(Transform pos)
    {
        var bulletObj = SmartPool.Instance.Spawn(bullet.gameObject, pos.position,pos.rotation);
        return bulletObj.GetComponent<BulletController>();
    }

    public GameObject Smoke(Transform pos)
    {
        var smokeObj = SmartPool.Instance.Spawn(smoke.gameObject, pos.position, pos.rotation);
        return smokeObj;
    }
}
