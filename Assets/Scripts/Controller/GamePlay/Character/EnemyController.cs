using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : CharacterController
{
    private Vector3 pos;

    private void Update()
    {
        Move(pos);
    }

    private bool SetNewPos()
    {
        var distance = Vector3.Distance(pos, gameObject.transform.position);

        return true;
    }
}
