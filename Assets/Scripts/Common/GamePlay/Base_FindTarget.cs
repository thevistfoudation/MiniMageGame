using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Base_FindTarget : MonoBehaviour
{
    public LayerMask layerTarget;
    public abstract Vector2 posCheck { get; }
    public abstract float range { get; }

    public GameObject FindTarget()
    {
        var targets = FindTargets();
        if (targets.Count > 0)
            return targets[0];

        return null;
    }

    public GameObject FindTargetNearest()
    {
        var targets = FindTargets();
        if (targets.Count > 0)
        {
            targets.Sort((x, y) => Vector2.Distance(x.transform.position, posCheck).CompareTo(Vector2.Distance(y.transform.position, posCheck)));
            return targets[0];
        }

        return null;
    }

    public virtual List<GameObject> FindTargets()
    {
        List<GameObject> targets = new List<GameObject>();

        var cols = Physics2D.OverlapCircleAll(posCheck, range, layerTarget);
        
        foreach (var col in cols)
        {
            if (AcceptTarget(col.gameObject))
            {
                targets.Add(col.gameObject);
            }
        }

        return targets;
    }

    public virtual bool AcceptTarget(GameObject target)
    {
        if (target != null && target != gameObject)
        {
            return target.activeSelf && TargetInRange(target);   
        }
        return false;
    }

    public bool TargetInRange(GameObject target)
    {
        return Vector2.Distance(target.transform.position, posCheck) < range;
    }
}
