using System.Collections;
using UnityEngine;

public class DragButton : MonoBehaviour
{
    public int type;

    private bool _draggable = false;
    private float _distance;
        
    void Update()
    {
        if (_draggable)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(_distance);

            transform.position = rayPoint;
        }
    }

    public void OnMouseDown()
    {
        _distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        _draggable = true;
    }

    public void OnMouseUp()
    {
        _draggable = false;
    }
}
