using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {
    private GameObject _target;

    private float _bulletSpeed = 3f;
    private float _bulletRotationSpeed = 5f;

    void Update()
    {
        MoveToTarget();
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    void MoveToTarget()
    {
        if (_target != null)
        {
            Debug.DrawLine(transform.position, _target.transform.position);

            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(_target.transform.position - transform.position), _bulletRotationSpeed * Time.deltaTime);
            transform.position = Vector3.MoveTowards(transform.position, _target.transform.position, _bulletSpeed * Time.deltaTime);
        }
        else if (_target == null)
        {
            Destroy(gameObject);
        }
    }
}
