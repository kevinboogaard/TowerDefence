using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Gridsystem : MonoBehaviour
{
    /*
     *  This class instantiates the grid used in the game.
     *  The grid is invisible, and will reveal itself once the mouse hovers over it.
     *  The Gridmap class in /Map/Gridmap.cs, is an open class that the Artist can edit if they'd like.
     */

    public float tileWidth = 1f;
    public float tileLength = 1f;
    public float tileHeight = 0.1f;

    public Material tileMaterial;

    private Gridmap _gridClass;
    private int[, ,] _gridMap;

    void Start()
    {
        /* check the system */
        CheckSystem();

        /* initialize everything on start. */
        initializeClasses();
        initializeGridmap();
    }

    void initializeClasses()
    {
        /* Get the Gridmap class and put the array of that class in this class. */
        _gridClass = transform.GetComponent<Gridmap>();
        _gridMap = _gridClass.gridMap;
    }

    void initializeGridmap()
    {
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
        cube.transform.tag = "Tile";
        cube.transform.name = "Tile";

        cube.AddComponent<Tile>();

        cube.GetComponent<Tile>().type = type;

        cube.renderer.material = tileMaterial;

        cube.transform.position = location;
    }

    int setType(int x, int y, int z)
    {
        int type;

        if (_gridClass.gridMap[x, y, z] == 1) { type = 1; }
        else if (_gridClass.gridMap[x, y, z] == 2) { type = 2; }
        else { type = 0; }

        return type;
    }

    public void ShowAllTiles(int type = 1)
    {
        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
        {
            tile.GetComponent<Tile>().Switch(true);
        }
    }

    public void HideAllTiles(int type = 1)
    {
        foreach (GameObject tile in GameObject.FindGameObjectsWithTag("Tile"))
        {
            tile.GetComponent<Tile>().Switch(false);
        }
    }

    void CheckSystem()
    {
        if (this.transform.position != new Vector3(0, 0, 0))
        {
            Debug.LogWarning("Warning: the Systems position is not [0x, 0y, 0z].", gameObject);
        }

        if (this.gameObject.name != "System")
        {
            Debug.LogWarning("Warning: " + gameObject.name + "'s name is not ['System']. This could cause errors in the game.");
        }

        if (this.gameObject.tag != "System")
        {
            Debug.LogWarning("Warning: " + gameObject.name + "'s tag is not ['System']. This could cause errors in the game.");
        }
    }
}
