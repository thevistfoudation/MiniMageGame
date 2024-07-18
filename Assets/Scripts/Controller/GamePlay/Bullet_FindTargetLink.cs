using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet_FindTargetLink : Base_FindTarget
{
    public override Vector2 posCheck => gameObject.transform.position;
    public override float range => Range;

    [HideInInspector] public float Range;

}
