using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class TowerManager : Managers {
    public List<GameObject> towerTypes = new List<GameObject>();

    public bool instantiateTower(GameObject type, Vector3 location, Quaternion rotation, Vector3 size)
    {
        GameObject tower = Instantiate(type, location, rotation) as GameObject;
        float average = (tower.transform.localScale.x + tower.transform.localScale.z) / 2;

        tower.transform.localScale = new Vector3(tower.transform.localScale.x * size.x, tower.transform.localScale.y * average, tower.transform.localScale.z * size.z);
        tower.transform.position = new Vector3(tower.transform.position.x, tower.transform.position.y + (tower.transform.localScale.y / 2), tower.transform.position.z);

        return true;
    }
}
