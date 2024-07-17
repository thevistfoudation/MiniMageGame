
using Core.Pool;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MoveController
{
    private float _time;
    private float _bouncesMax;
    private float _PenetrationMax;
    public float damage;


    public void InitilizerData(float speedData, float damageData, float timeData, float bounceData, float penetration)
    {
        speed = speedData;
        damage = damageData;
        _time = timeData;
        _bouncesMax = bounceData;
        _PenetrationMax = penetration;
        Invoke("DisableBullet",_time);
    }

    void Update()
    {
        Move(this.transform.up);
    }

    private void DisableBullet()
    {
        SmartPool.Instance.Despawn(gameObject);
        CreateController.Instance.Smoke(gameObject.transform);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.transform.CompareTag("Mirror"))
        {
            var first = collision.ClosestPoint(transform.position);
            Vector2 direct = Vector2.Reflect(gameObject.transform.up, first);
            this.transform.up = direct;
            _bouncesMax -= 1;
            if( _bouncesMax <= 0)
            {
                DisableBullet();
            }
        }
        if (collision.transform.CompareTag("Enemy"))
        {
            _PenetrationMax -= 1;
            if (_PenetrationMax <= 0)
            {
                DisableBullet();
            }
        }
    }
}
