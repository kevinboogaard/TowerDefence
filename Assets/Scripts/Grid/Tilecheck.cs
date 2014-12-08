using UnityEngine;
using System.Collections;

public class Tilecheck : MonoBehaviour {
    /* This is the class every tile has. It switches between visible or invisible when the mouse hovers over the tile. */
    public int type = 0;

    private bool _build = false;

    void Start()
    {
        //Switch(false);
    }

    void OnMouseDown()
    {
        if (_build == false)
        {
            // If the tile is empty..
            GameObject manager = GameObject.FindGameObjectWithTag("Manager");
            TowerManager towerManager = manager.GetComponent<TowerManager>();

            Mesh mesh = GetComponent<MeshFilter>().mesh;
            Bounds bounds = mesh.bounds;

            Vector3 size = new Vector3(bounds.size.x, transform.position.y, bounds.size.z);

            _build = towerManager.instantiateTower(towerManager.towerTypes[0], transform.position, transform.rotation, size);
        }
        else if (_build == true)
        {
            // If the tile has already been build on, return null.
            return;
        }
    }

	void OnMouseOver()
	{
        if (type == 1)
        {
            Switch(true);
        }
	}
	
	void OnMouseExit()
	{
        if (type == 1)
        {
            Switch(false);
        }
	}

    void Switch(bool value)
    {
        /* Enable or Disable the renderer. */
        renderer.enabled = value; 
    }
}
