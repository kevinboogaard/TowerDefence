using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(SphereCollider))]
public class Structure : MonoBehaviour
{
    public List<GameObject> enemiesInRange;

    public int health;
    public int damage;
    public float attackSpeed;
    public float range = 1.5f;

    private GameManager _manager;

    void Start()
    {
        Enemy.onEnemyDestroy += RemoveFromList;
        _manager = GameObject.FindGameObjectWithTag("Manager").GetComponent<GameManager>();

        gameObject.GetComponent<SphereCollider>().radius = range;
        gameObject.GetComponent<SphereCollider>().isTrigger = true;
    }

    void Update()
    {
        if (_manager.eventGame == GameManager.gameEvents.EVENT_IN_COMBAT)
        {
            gameObject.GetComponent<SphereCollider>().enabled = true;

            if (enemiesInRange.Count > 0)
            {
                GameObject target = FindTarget();

                if (attackSpeed > 1)
                {
                    Fire(target);
                    attackSpeed = 0;
                }
                else
                {
                    attackSpeed += Time.deltaTime;
                }
            }
        }
        else if (_manager.eventGame == GameManager.gameEvents.EVENT_OUT_OF_COMBAT)
        {
            gameObject.GetComponent<SphereCollider>().enabled = false;
        }
    }

    void OnTriggerEnter(Collider _other)
    {
        if (_other.tag == "Enemy")
        {
            enemiesInRange.Add(_other.gameObject);
        }
    }

    void OnTriggerExit(Collider _other)
    {
        if (_other.tag == "Enemy")
        {
            enemiesInRange.RemoveAt(enemiesInRange.IndexOf(_other.gameObject));
        }
    }


    public void RemoveFromList(GameObject _enemy)
    {
        enemiesInRange.RemoveAt(enemiesInRange.IndexOf(_enemy));
    }


    void Fire(GameObject _target)
    {
        GameObject bullet = GameObject.CreatePrimitive(PrimitiveType.Capsule);
        bullet.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        bullet.transform.position = new Vector3(transform.position.x, transform.position.y + 2f, transform.position.z);

        bullet.name = "Projectile";
        bullet.tag = "Projectile";

        bullet.AddComponent<Projectile>();
        bullet.GetComponent<Projectile>().SetTarget(_target);
        bullet.GetComponent<Projectile>().damage = damage;
    }

    GameObject FindTarget()
    {
        GameObject _enemy;

        if (enemiesInRange.Count > 1)
        {
            enemiesInRange.Sort(ByDistance);
        }

        _enemy = enemiesInRange[0];

        return _enemy;
    }

    int ByDistance(GameObject _a, GameObject _b)
    {
        float distanceToA = Vector3.Distance(transform.position, _a.transform.position);
        float distanceToB = Vector3.Distance(transform.position, _b.transform.position);

        return distanceToA.CompareTo(distanceToB);
    }
}
