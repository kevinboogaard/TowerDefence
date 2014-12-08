using UnityEngine;
using System.Collections;

public class Managers : MonoBehaviour {
	void Start () {
	    if(gameObject.tag != "Manager")
        {
            gameObject.tag = "Manager";
        }
	}
}
