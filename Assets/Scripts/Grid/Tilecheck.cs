using UnityEngine;
using System.Collections;

public class Tilecheck : MonoBehaviour {
    /* This is the class every tile has. It switches between visible or invisible when the mouse hovers over the tile. */
    public int type = 0;

    void Start()
    {
        Switch(false);

        if(type == 0)
        {
            transform.name = "Tile";
        }
        else if (type == 1)
        {
            transform.name = "WalkTile";
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
