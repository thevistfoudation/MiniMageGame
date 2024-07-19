using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterController : MoveController
{
    [SerializeField] private Transform bodyCharacter;
    [SerializeField] public Transform gun;
    [SerializeField] private Transform transhoot;

    protected override void Move(Vector3 direction)
    {
        if (direction != Vector3.zero)
        {
            bodyCharacter.up = direction;
        }
        base.Move(direction);
    }

    protected void RotateGun(Vector3 direction)
    {
        gun.transform.up = direction;
    }

    public void Shoot(float speedData, float damageData, float timeData, float bounceData, float penetration, float timeDamage)
    {
        var bullet = CreateController.Instance.BulletController(transhoot);
        bullet.InitilizerData(speedData,damageData,timeData,bounceData,penetration, timeDamage);
    }
}
