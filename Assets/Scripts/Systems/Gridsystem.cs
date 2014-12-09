using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gridsystem : MonoBehaviour {
	/*
     *  This class instantiates the grid used in the game.
     *  The grid is invisible, and will reveal itself once the mouse hovers over it.
     *  The Gridmap class in /Map/Gridmap.cs, is an open class that the Artist can edit if they'd like.
     */
	
	public float tileWidth = 1f;
	public float tileLength = 1f;
	public float tileHeight = 0.1f;
	
	private Gridmap _gridClass;
	private int[, ,] _gridMap;
	
	void Start() {
		/* initialize everything on start. */
		initializeClasses();
		initializeGridmap();
	}

	void initializeClasses() {
		/* Get the Gridmap class and put the array of that class in this class. */
		_gridClass = transform.GetComponent<Gridmap>();
		_gridMap = _gridClass.gridMap;
	}
	
	void initializeGridmap() {
		/* Get the length of every row/colum, and instantiate the object on the right location */
		int lengthX = _gridMap.GetLength(0);
		for (int x = 0; x < lengthX; x++)
		{
			int lengthY = _gridMap.GetLength(1);

            for (int y = 0; y < lengthY; y++)
            {
                int lengthZ = _gridMap.GetLength(2);

                for (int z = 0; z < lengthZ; z++)
                {
                    Vector3 location = new Vector3(x * tileWidth, y + tileLength, z * tileLength);
                    
                    int type = setType(x, y, z);

                    spawnTile(location, type);
                }
            }
		}
	}
	
	void spawnTile(Vector3 location, int type)
	{
		/* Create a Primitive cube. */
		GameObject cube = GameObject.CreatePrimitive(PrimitiveType.Cube);
		cube.transform.localScale = new Vector3(tileWidth, tileHeight, tileLength);
        cube.transform.parent = this.transform;
		
		cube.AddComponent<Tilecheck>();
        cube.GetComponent<Tilecheck>().type = type;

		cube.transform.position = location;
	}

    int setType(int x, int y, int z)
    {
        int type;

        if (_gridClass.gridMap[x, y, z] == 1) { type = 1; }
        else { type = 0; }

        return type;
    }
}
