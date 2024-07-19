using Controller.LoadData;
using jinLab.Model;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using static UnityEngine.GraphicsBuffer;

public class BulletLinkArcController : MonoBehaviour
{
    [SerializeField] private LayerMask layerTarget;
    private Bullet_FindTargetLink _bullet_FindTargetLink;
    private ArcController _arcController;
    private ArcData _arcData;
    public GameObject targetObject;
    public bool rejectConnect;
    private float _timeCountDamage;
    private void Awake()
    {
        InitDataBase();
    }

    private void OnEnable()
    {
        rejectConnect = false;
        targetObject = null;
    }


    private void InitDataBase()
    {
        _arcController = GetComponentInChildren<ArcController>();
        _bullet_FindTargetLink = GetComponent<Bullet_FindTargetLink>();
        _arcData = LoadResourceController.Instance.LoadArcData();
        _bullet_FindTargetLink.Range = _arcData.distance;
        _bullet_FindTargetLink.layerTarget = layerTarget;
    }

    private void Update()
    {
        if (rejectConnect && targetObject)
        {
            SetLine();
            CheckCollison();
        }
        if (!_bullet_FindTargetLink.AcceptTarget(targetObject) && !rejectConnect)
        {
            if (_bullet_FindTargetLink.FindTarget())
            {
                var canConnect = _bullet_FindTargetLink.FindTarget().GetComponent<BulletLinkArcController>();
                if (!canConnect.rejectConnect)
                {
                    canConnect.rejectConnect = true;
                    canConnect.targetObject = gameObject;
                    targetObject = _bullet_FindTargetLink.FindTarget();
                    rejectConnect = true;
                }
            }
        }
    }

    public void CheckCollison()
    {
        var distance = Vector3.Distance(gameObject.transform.localPosition, targetObject.transform.localPosition);
        var direc = targetObject.transform.localPosition - transform.localPosition;
        if (distance <= _arcData.distance)
        {
            RaycastHit2D[] hits = Physics2D.RaycastAll(gameObject.transform.localPosition, direc, distance);
            Debug.DrawRay(transform.localPosition, direc, Color.cyan, 5);
            for (int i = 0; i < hits.Length; i++)
            {
                var hit = hits[i];
                if (hit.transform.CompareTag("Enemy"))
                {
                    _timeCountDamage -= Time.deltaTime;
                    if (_timeCountDamage <= 0)
                    {
                        hit.transform.GetComponent<EnemyController>().TakeDamage(_arcData.damage);
                        _timeCountDamage = _arcData.time;
                    }
                   
                }
                if (hit.transform.CompareTag("Obstacle"))
                {
                    _arcController.DisableLine();
                }
                if (hit.transform.CompareTag("Mirror"))
                {
                    _arcController.DisableLine();
                }
            }
        }
    }

    private void SetLine()
    {
        _arcController.SetLine(gameObject.transform, targetObject.transform, _arcData.distance);
    }

}
