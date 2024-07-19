
using Controller.LoadData;
using Core.Pool;
using jinLab.Model;
using System.Linq.Expressions;
using Unity.VisualScripting;
using UnityEngine;

public class BulletController : MoveController
{
    private float _damage;
    private float _time;
    private float _timeDamage;
    private float _countTimeDamage;
    private float _bouncesMax;
    private float _PenetrationMax;
    private string _name;
   

    public void InitilizerData(float speedData, float damageData, float timeData, float bounceData, float penetration, float timeDamage)
    {
        speed = speedData;
        _damage = damageData;
        _time = timeData;
        _bouncesMax = bounceData;
        _PenetrationMax = penetration;
        _timeDamage = timeDamage;
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
            Vector3 direct = Vector3.Reflect(gameObject.transform.up, first);
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

            _countTimeDamage -= Time.deltaTime;
            if (_countTimeDamage <= 0 && _name != collision.name)
            {
                _name = collision.name;
                collision.transform.GetComponent<EnemyController>().TakeDamage(_damage);
                _countTimeDamage = _timeDamage;
                _name = null;
            }
            

            if (_PenetrationMax <= 0)
            {
                DisableBullet();
            }
        }
    }
}
