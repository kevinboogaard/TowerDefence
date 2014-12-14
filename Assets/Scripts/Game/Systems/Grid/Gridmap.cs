using UnityEngine;
using System.Collections;

public class Gridmap : MonoBehaviour
{
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
     * - 2 = Path.
     */

    public int[, ,] gridMap = new int[,,]
	{ 
		/* Current: 10x1x10 cubes. */
		{{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},}, // --
		{{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},}, // .        
		{{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},}, // C        
		{{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},}, // O        
		{{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},}, // L        
		{{ 2, 2, 2, 2, 2, 2, 2, 2, 2, 2},}, // U      
		{{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},}, // M        
		{{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},}, // N       
		{{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},}, // S   
		{{ 1, 1, 1, 1, 0, 0, 0, 0, 0, 0},}, // .    
		/*-------------ROWS---------------- */
	};
}
