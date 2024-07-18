using Controller.LoadData;
using jinLab.Model;
using System.Collections;
using System.Collections.Generic;
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

    private void Awake()
    {
        InitDataBase();
    }

    private void OnEnable()
    {
        rejectConnect = false;
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
        }
        if (!_bullet_FindTargetLink.AcceptTarget(targetObject) && !rejectConnect)
        {
            if (_bullet_FindTargetLink.FindTarget())
            {
                var canConnect = _bullet_FindTargetLink.FindTarget().GetComponent<BulletLinkArcController>();
                if (!canConnect.rejectConnect)
                {
                    targetObject = _bullet_FindTargetLink.FindTarget();
                    rejectConnect = true;
                }
            }
        }
    }

  
    private void SetLine()
    {
        _arcController.SetLine(gameObject.transform, targetObject.transform, _arcData.distance);
    }
}
