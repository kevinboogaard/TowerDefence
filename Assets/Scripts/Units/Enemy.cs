using UnityEngine;
using System.Collections;

public class Enemy : MonoBehaviour {
	public int health;
	public int speed;
	public int damage;
	public int currency;
    
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.name == "Bullet")
        {
            Destroy(other.gameObject);
            Destroy(gameObject);
        }
    }
}
