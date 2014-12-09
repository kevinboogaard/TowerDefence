using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Tower : MonoBehaviour {
    [SerializeField]
    private List<GameObject> enemiesRange;

    private float timer = 1;

    void Update()
    {
        if(enemiesRange.Count > 0)
        { 
            GameObject target = FindTarget();

            if (timer > 1)
            {
                Fire(target);
                timer = 0;
            }

            if (enemiesRange[0] == null)
            {
                enemiesRange.Remove(enemiesRange[0]);
            }
        }

        timer += Time.deltaTime;
    }

    void OnTriggerEnter(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesRange.Add(other.gameObject);
        }
    }

    void OnTriggerExit(Collider other)
    {
        if (other.tag == "Enemy")
        {
            enemiesRange.Remove(other.gameObject);
        }
    }

    GameObject FindTarget()
    {
        GameObject enemy;

        if (enemiesRange.Count > 1)
        {
            enemiesRange.Sort(ByDistance);
        }

        enemy = enemiesRange[0];

        return enemy;
    }

    void Fire(GameObject target)
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        bullet.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        bullet.transform.position = transform.position;

        bullet.name = "Bullet";

        bullet.AddComponent<Bullet>();

        bullet.GetComponent<Bullet>().SetTarget(target);
        bullet.GetComponent<CapsuleCollider>().isTrigger = true;
    }

    int ByDistance(GameObject a, GameObject b)
    {
        float distanceToA = Vector3.Distance(transform.position, a.transform.position);
        float distanceToB = Vector3.Distance(transform.position, b.transform.position);

        return distanceToA.CompareTo(distanceToB);
    }
}
