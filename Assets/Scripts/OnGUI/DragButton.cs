using System.Collections;
using UnityEngine;

public class DragButton : MonoBehaviour
{
    public int type;

    private float _distance;

    private bool _draggable = false;
    private bool _onTile = false;
    private bool _build = false;

    private Vector3 _startLocation;
    private Vector3 _currentLocation;

    private Quaternion _startRotation;

    private Mesh _mesh;
    private Bounds _bounds;

    private Transform _tile;
    
    void Start()
    {
        _startLocation = transform.position;
        _startRotation = transform.rotation;

        GetAllComponents();
    }

    void GetAllComponents()
    {
        _mesh = GetComponent<MeshFilter>().mesh;
        _bounds = _mesh.bounds;
    }

    void Update()
    {
        CheckDraggable();
        CheckCollision();
    }

    void CheckDraggable()
    {
        if (_draggable)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            Vector3 rayPoint = ray.GetPoint(_distance);

            transform.position = rayPoint;
        }
    }

    void CheckCollision()
    {
        if(_draggable)
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            Debug.DrawRay(ray.origin, ray.direction * 100, Color.yellow);
    
            if (Physics.Raycast(ray, out hit))
            {
                if (hit.transform.name == "WalkTile")
                {
                    _onTile = true;
                    _tile = hit.transform;
                    SwitchStates(hit);
                }
                else
                {
                    SwitchBack();
                }
            }
        }
    }

    void SwitchStates(RaycastHit hit)
    {
        if (_onTile == true)
        {
            Vector3 position = new Vector3(hit.transform.position.x, hit.transform.position.y + _bounds.size.y, hit.transform.position.z);
            transform.position = position;
            transform.rotation = hit.transform.rotation;
        }
    }

    void SwitchBack()
    {
        _onTile = false;
        transform.rotation = _startRotation;
    }

    void OnMouseDown()
    {
        _distance = Vector3.Distance(transform.position, Camera.main.transform.position);
        _draggable = true;
        this.gameObject.layer = 2;
    }

    void OnMouseUp()
    {
        if (_onTile == true)
        {
            SpawnTower();
        }

        _draggable = false;
        SwitchBack();
        transform.position = _startLocation;
        this.gameObject.layer = 0;
    }

    void SpawnTower()
    {
        if(_build == false)
        {
            // If the tile is empty..
            GameObject manager = GameObject.FindGameObjectWithTag("Manager");
            TowerManager towerManager = manager.GetComponent<TowerManager>();

            Mesh mesh = GetComponent<MeshFilter>().mesh;
            Bounds bounds = mesh.bounds;

            Vector3 position = new Vector3(_tile.position.x, _tile.position.y + (bounds.size.y / 2), _tile.position.z);
            Vector3 size = new Vector3(bounds.size.x, transform.position.y, bounds.size.z);

            bool _hasBuild = towerManager.instantiateTower(towerManager.towerTypes[0], position, transform.rotation, size);
        }
        else if(_build == true)
        {
            // If the tile has already been build on, return null.
            return;
        }
    }
}