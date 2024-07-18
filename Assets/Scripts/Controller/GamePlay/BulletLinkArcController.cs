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
    private GameObject _target;
    public GameObject targetObject;
    private bool canConnect;

    private void Awake()
    {
        InitDataBase();
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
        if (!_bullet_FindTargetLink || !_bullet_FindTargetLink.AcceptTarget(targetObject) && !canConnect)
        {
            targetObject = _bullet_FindTargetLink.FindTarget();
            canConnect = true;
        }
        if(canConnect && !(targetObject is null))
        {
            SetLine();
        }
    }

    private void SetLine()
    {
        _arcController.SetLine(gameObject.transform, targetObject.transform);
    }
}
