using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(GameManager))]
public class WaveManager : MonoBehaviour
{
    public static int currentWave = 1;
    public static int nextWave = currentWave + 1;

    private List<GameObject> _currentEnemies = new List<GameObject>();
    private List<string> _nextEnemies = new List<string>();

    private CreatureManager _creatureManager;
    private GameManager _manager;

    void Start()
    {
        _creatureManager = transform.GetComponent<CreatureManager>();
        _manager = gameObject.GetComponent<GameManager>();
    }

    void Update()
    {
        if (_currentEnemies.Count == 0 && _manager.eventGame != GameManager.gameEvents.EVENT_OUT_OF_COMBAT)
        {
            _manager.eventGame = GameManager.gameEvents.EVENT_OUT_OF_COMBAT;
        }

        if (Input.GetKeyDown("space"))
        {
            _manager.eventGame = GameManager.gameEvents.EVENT_IN_COMBAT;

            if (currentWave == 1)
            {
                List<string> firstWave = _creatureManager.getWave(currentWave);
                _nextEnemies = _creatureManager.getWave(nextWave);

                _currentEnemies = _creatureManager.SpawnEnemies(firstWave);
                _creatureManager.SetSkills(_currentEnemies, currentWave);

                PrepareList(_currentEnemies);

                currentWave++;
                nextWave = currentWave + 1;
            }
            else if (currentWave > 1)
            {
                _currentEnemies = _creatureManager.SpawnEnemies(_nextEnemies);
                _creatureManager.SetSkills(_currentEnemies, currentWave);

                PrepareList(_currentEnemies);

                currentWave++;
                nextWave = currentWave + 1;
            }
        }
    }

    void PrepareList(List<GameObject> _enemyList)
    {
        GameObject location = GameObject.Find("SpawnLocation");
        Vector3 _position = new Vector3(location.transform.position.x, location.transform.position.y, location.transform.position.z);
        Quaternion _rotation = location.transform.rotation;

        for (int i = 0; i < _enemyList.Count; i++)
        {
            StartCoroutine(InstantiateAllEnemies(_enemyList[i], _position, _rotation, 1f * i));
        }
    }

    IEnumerator InstantiateAllEnemies(GameObject _enemy, Vector3 _position, Quaternion _rotation, float _seconds)
    {
        yield return new WaitForSeconds(_seconds);
        Instantiate(_enemy, _position, _rotation);
    }
}
