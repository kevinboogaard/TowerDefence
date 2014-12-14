using UnityEngine;
using System.Collections;

public class GameManager : MonoBehaviour
{
    /*
     * GameManager.cs is the main manager. 
     * This manager is the manager of the game, the player and it makes sure if everything is set right.
     */

    public enum gameEvents
    {
        EVENT_OUT_OF_COMBAT = 0,
        EVENT_IN_COMBAT = 1,
    }

    public gameEvents eventGame = gameEvents.EVENT_OUT_OF_COMBAT;


    void Start()
    {
        CheckManager();
    }

    void CheckManager()
    {
        if (this.transform.position != new Vector3(0, 0, 0))
        {
            Debug.LogWarning("Warning: the Managers position is not [0x, 0y, 0z].", gameObject);
        }

        if (this.gameObject.name != "Manager")
        {
            Debug.LogWarning("Warning: " + gameObject.name + "'s name is not ['Manager']. This could cause errors in the game.");
        }

        if (this.gameObject.tag != "Manager")
        {
            Debug.LogWarning("Warning: " + gameObject.name + "'s tag is not ['Manager']. This could cause errors in the game.");
        }
    }
}
