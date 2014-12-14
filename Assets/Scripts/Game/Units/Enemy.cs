using UnityEngine;
using System.Collections;

[RequireComponent(typeof(Rigidbody))]
[RequireComponent(typeof(NavMeshAgent))]
public class Enemy : MonoBehaviour
{
    /*
     * This is the Enemyclass. Each enemy has this class, so the code must be usable for everyone.
     */

    public delegate void OnEnemyDestroy(GameObject enemy); // Delegate void, sort of a dispatch-event from Actionscript 3.
    public static event OnEnemyDestroy onEnemyDestroy;     // Make an event of the delegate.

    public int health = 1;   // Health of the enemy.
    public int speed = 1;    // Speed of the enemy.
    public int damage;   // Damage when the minion hits the base.
    public int currency; // Currency dropped when killed.

    private NavMeshAgent _agent; // Pathfinding Agent.
    private GameObject _target;  // Targetted location for the Navmeshagent.

    void Start() {
        /* Find the location of the targed and get the NavmeshAgent component */
        _target = GameObject.Find("Location");
        _agent = GetComponent<NavMeshAgent>();

        /* Set the Agent's speed, and set the destination on the target. */
        _agent.speed = speed;
        _agent.SetDestination(_target.transform.position);

        /* Make sure the tag is Enemy */
        gameObject.tag = "Enemy";
    }

    void OnCollisionEnter(Collision _other) {
        /*
         * If the tag is the same as Projectile, look if the agent isn't null.
         * If it isn't null, destroy the gameobject and the bullet.
         */
        if (_other.gameObject.tag == "Projectile")
        {
            Destroy(_other.gameObject);
            GetDamage(1);
        }
    }

    void GetDamage(int _damage)
    {
        health = health - _damage;

        if (health <= 0)
        {
            if (onEnemyDestroy != null)
            {
                onEnemyDestroy(this.gameObject);
            }

            Destroy(gameObject);
        }
    }
}