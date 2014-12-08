using UnityEngine;
using System.Collections;

public class Gridmap : MonoBehaviour {
	/*
     * Gridmap instructions:
     * 
     * Current: X*Y*Z.
     * 
     * X: Length, 
     * Y: Height,
     * Z: Width.
     * 
     * Would you like to add/remove a cube from the length? = Add/Remove an integer from every row.
     * Would you like to add/remove a cube from the width?  = Add/Remove a column.
     * 
     * What are these integers on the map? :
     * 
     * - 0 = Un-Walkeable.
     * - 1 = Walkeable.
     */
	
	public int[, ,] gridMap = new int[,,]
	{ 
		/* Current: 10x1x10 cubes. */
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // --
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // .        
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // C        
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // O        
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // L        
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // U      
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // M        
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // N       
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // S   
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // .   
		{{ 0, 0, 0, 0, 0, 0, 1, 1, 1, 1},}, // --     
		/*-------------ROWS---------------- */
	};
}
