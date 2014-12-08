using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class WaveManager : MonoBehaviour {
	public static int currentWave = 1;
	public static int nextWave;
	
	private List <GameObject> _currentEnemies = new List<GameObject>();
	private List <string> _nextEnemies = new List<string>();
	
	private CreatureManager _creatureManager;
	private bool _firstTime = true;
	
	void Start()
	{
		_creatureManager = transform.GetComponent<CreatureManager>();	
	}
	
	void Update()
	{
		if (Input.GetKeyDown ("space"))
		{
			if(_firstTime == true)
			{
				List<string> firstWave = _creatureManager.getWave(currentWave);
				_nextEnemies = _creatureManager.getWave(nextWave);
				
				_currentEnemies = _creatureManager.SpawnEnemies(firstWave);
				_creatureManager.SetSkills(_currentEnemies, currentWave);
				
				SpawnList(_currentEnemies);
				
				_firstTime = false;
				currentWave++;
			}
			else if(_firstTime == false){
				ClearList();
				
				_currentEnemies = _creatureManager.SpawnEnemies(_nextEnemies);
				_creatureManager.SetSkills(_currentEnemies, currentWave);
				
				SpawnList(_currentEnemies);
				
				currentWave++;
			}
		}
	}
	
	void SpawnList(List<GameObject> enemyList)
	{
		Vector3 _position = new Vector3(transform.position.x, 0.15f, transform.position.z);
		Quaternion _rotation = new Quaternion(0,0,0, 0);
		
		foreach (GameObject enemy in enemyList)
		{
			print (23);
			Timer(enemy, _position, _rotation, 0.5f);
		}
	}
	
	void ClearList()
	{
		foreach(GameObject enemy in _currentEnemies)
		{
			Destroy(enemy);
		}
		
		_currentEnemies.Clear();
	}
	
	IEnumerator Timer(GameObject enemy, Vector3 _position, Quaternion _rotation, float seconds) {
		print (seconds);
		yield return new WaitForSeconds(seconds);
		Instantiate (enemy, _position, _rotation);
	}
}
