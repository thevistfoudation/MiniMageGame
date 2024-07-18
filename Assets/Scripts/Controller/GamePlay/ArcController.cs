using UnityEngine;

public class ArcController : MonoBehaviour
{
    private LineRenderer _line;


    private void Awake()
    {
        _line = GetComponentInChildren<LineRenderer>();
    }



    public void SetLine(Transform pos1, Transform pos2)
    {
        Debug.Log("setLineRender");
        _line.SetPosition(0, pos1.position);
        _line.SetPosition(1, pos2.position);
    }
}
