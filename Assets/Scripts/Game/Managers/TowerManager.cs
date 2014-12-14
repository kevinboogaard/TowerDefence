using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(GameManager))]
public class TowerManager : MonoBehaviour
{
    public List<GameObject> towerTypes = new List<GameObject>();
    [HideInInspector]
    public List<GameObject> spawnedTowers = new List<GameObject>();

    public delegate void OnTowerDestroy(GameObject tower); // Delegate void, sort of a dispatch-event from Actionscript 3.
    public static event OnTowerDestroy onTowerDestroy;     // Make an event of the delegate.

    private GameObject selectedTower;
    private GameManager manager;

    public enum towerEvents
    {
        EVENT_IDLE = 0,
        EVENT_INSTANTIATE = 1,
        EVENT_SELECTED = 2,
        EVENT_MOVE = 3,
        EVENT_UPGRADE = 4,
    }

    private towerEvents _eventTower = towerEvents.EVENT_IDLE;

    void Start()
    {
        manager = gameObject.GetComponent<GameManager>();
    }

    public GameObject InstantiateTower(GameObject _type, Vector3 _location, Quaternion _rotation)
    {
        GameObject tower = Instantiate(_type, _location, _rotation) as GameObject;
        spawnedTowers.Add(tower);

        tower.transform.position = new Vector3(tower.transform.position.x, tower.transform.position.y + (tower.transform.localScale.y / 2), tower.transform.position.z);

        return tower;
    }

    public void DestroyTower(GameObject _tower)
    {
        Destroy(_tower);
        spawnedTowers.RemoveAt(spawnedTowers.IndexOf(_tower));
    }

    public void DestroyAllTowers()
    {
        foreach (GameObject _tower in spawnedTowers)
        {
            Destroy(_tower);
            spawnedTowers.RemoveAt(spawnedTowers.IndexOf(_tower));
        }
    }

    public void SelectTower(GameObject _tower)
    {
        if (_tower != null)
        {
            if (manager.eventGame == GameManager.gameEvents.EVENT_OUT_OF_COMBAT)
            {
                selectedTower = _tower;
            }
        }
        else
        {
            Debug.LogWarning("Error: GameManager.cs: Function SelectTower, parameter: tower is null.");
        }
    }

    public void SetPosition(Vector3 _position)
    {
        if (manager.eventGame == GameManager.gameEvents.EVENT_OUT_OF_COMBAT && _eventTower == towerEvents.EVENT_MOVE)
        {
            selectedTower.transform.position = _position;
            selectedTower = null;
            _eventTower = towerEvents.EVENT_IDLE;
        }
    }

    public void UpgradeTower()
    {
        if (manager.eventGame == GameManager.gameEvents.EVENT_OUT_OF_COMBAT && _eventTower == towerEvents.EVENT_UPGRADE)
        {
            _eventTower = towerEvents.EVENT_IDLE;
            print("UPGRADE");
        }
    }
}
