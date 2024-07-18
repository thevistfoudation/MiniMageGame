using UnityEngine;

public class ArcController : MonoBehaviour
{
    private LineRenderer _line;

    private void Awake()
    {
        _line = GetComponentInChildren<LineRenderer>();
    }



    public void SetLine(Transform pos1, Transform pos2, float distanceMax)
    {
        var distanceTwoPoint = Vector3.Distance(pos1.position, pos2.position);
        if(distanceTwoPoint < distanceMax)
        {
            _line.SetPosition(0, pos1.position);
            _line.SetPosition(1, pos2.position);
        }
        else
        {
            _line.SetPosition(0, pos1.position);
            _line.SetPosition(1, pos1.position);
        }
    }
}
