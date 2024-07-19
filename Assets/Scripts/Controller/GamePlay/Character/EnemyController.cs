using Controller.LoadData;
using Core.Pool;
using jinLab.Model;
using MoreMountains.Feedbacks;
using UnityEngine;

public class EnemyController : CharacterController
{
    private Vector3 pos;
    private EnemyData _enemyData;
    private float _hp;
    private MMF_Player _myPlayer;

    private void Awake()
    {
        _enemyData = LoadResourceController.Instance.LoadEnemyData();
        _myPlayer = this.gameObject.GetComponent<MMF_Player>();
    }

    private void OnEnable()
    {
        InitilizerData();
    }

    private void InitilizerData()
    {
       
        speed = _enemyData.speed;
        _hp = _enemyData.hp;
    }

    private void Start()
    {
        var x = Random.Range(-10, 10);
        var y = Random.Range(-10, 10);
        pos = new Vector3(x, y);
    }

    private void Update()
    {
        var distance = Vector3.Distance(pos, gameObject.transform.position);
        if (distance <= 0.5f)
        {
            var x = Random.Range(-10, 10);
            var y = Random.Range(-10, 10);
            pos = new Vector3(x, y);
        }
        var direction = pos - transform.position;
        direction.Normalize();
        Move(direction);
    }

    public void TakeDamage(float damage)
    {
        _hp -= damage;
        var text = damage.ToString();
        MMF_FloatingText floatingText = _myPlayer.GetFeedbackOfType<MMF_FloatingText>();
        floatingText.Value = text;
        _myPlayer.PlayFeedbacks(this.transform.position, damage);
        if ( _hp <= 0)
        {
            SmartPool.Instance.Despawn(gameObject);
        }
    }
}
