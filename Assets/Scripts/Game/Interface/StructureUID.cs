using UnityEngine;
using System.Collections;

public class StructureUID : MonoBehaviour
{
    /* The class for every draggable button */

    public int type;

    public enum uidEvents
    {
        EVENT_IDLE = 0,
        EVENT_DRAGGING = 1,
        EVENT_ONTILE = 2,
        EVENT_SPAWN = 3,
    }

    private uidEvents _eventUID = uidEvents.EVENT_IDLE;

    private Vector3 _startLocation;
    private Vector3 _currentLocation;
    private Quaternion _startRotation;

    private Transform _currentTile;
    private float _distance;
    private Gridsystem grid;

    void Start()
    {
        _startLocation = transform.position;
        _startRotation = transform.rotation;

        grid = GameObject.Find("System").GetComponent<Gridsystem>();
    }

    void Update()
    {
        CheckEvents();
    }

    void OnMouseDown()
    {
        grid.ShowAllTiles();

        if (_eventUID != uidEvents.EVENT_DRAGGING)
        {
            _eventUID = uidEvents.EVENT_DRAGGING;
        }
    }

    void OnMouseUp()
    {
        grid.HideAllTiles();

        if (_eventUID == uidEvents.EVENT_ONTILE)
        {
            _eventUID = uidEvents.EVENT_SPAWN;
        }
        else
        {
            _eventUID = uidEvents.EVENT_IDLE;
        }
    }

    void CheckEvents()
    {
        if (_eventUID == uidEvents.EVENT_IDLE)
        {
            transform.position = _startLocation;
            transform.rotation = _startRotation;
        }
        else if (_eventUID == uidEvents.EVENT_DRAGGING)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = new Vector3(ray.GetPoint(_distance).x, transform.position.y, ray.GetPoint(_distance).z);

            _distance = Vector3.Distance(transform.position, Camera.main.transform.position);

            transform.position = rayPoint;
            transform.rotation = _startRotation;
        }
        else if (_eventUID == uidEvents.EVENT_SPAWN)
        {
            SpawnTower();
            _eventUID = uidEvents.EVENT_IDLE;
        }

        if (_eventUID == uidEvents.EVENT_DRAGGING || _eventUID == uidEvents.EVENT_ONTILE)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);

            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "Tile" && this.transform.position != hit.transform.position)
                {
                    _currentTile = hit.transform;
                    _eventUID = uidEvents.EVENT_ONTILE;
                    CheckOnTile();
                }
                else
                {
                    _eventUID = uidEvents.EVENT_DRAGGING;
                }
            }
        }
    }

    void CheckOnTile()
    {
        if (_eventUID == uidEvents.EVENT_ONTILE)
        {
            Vector3 position = new Vector3(_currentTile.position.x, _currentTile.transform.position.y, _currentTile.transform.position.z);
            transform.position = position;
            transform.rotation = _currentTile.rotation;
        }
    }

    void SpawnTower()
    {
        GameObject manager = GameObject.FindGameObjectWithTag("Manager");
        TowerManager towerManager = manager.GetComponent<TowerManager>();

        Vector3 position = new Vector3(_currentTile.position.x, _currentTile.position.y - 0.5f, _currentTile.position.z);

        GameObject tower = towerManager.InstantiateTower(towerManager.towerTypes[0], position, transform.rotation);
        tower.GetComponent<Structure>().range = 1.5f;
    }
}