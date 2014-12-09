using UnityEngine;
using System.Collections;

public class Navigation : MonoBehaviour {

	public GameObject target;

    public int speed = 1;
	
    private NavMeshAgent agent;

	void Start () {
        target = GameObject.Find("Location");
		agent = GetComponent<NavMeshAgent>();
	}
	
	void Update () {
        agent.speed = speed;
	    agent.SetDestination(target.transform.position);
	}
}
