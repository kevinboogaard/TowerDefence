using UnityEngine;
using System.Collections;
using System.Collections.Generic;
			
	public enum Enemys
		{
			ENEMY_WALKER = 0
		}
	
	public class EnemySpawnScript : MonoBehaviour {
		public List<GameObject> enemyList = new List<GameObject>();
		public GameObject[] enemy;
		// Use this for initialization
		public void Spawn (Enemys type, Vector3 spawnLocation) 
		{
			Quaternion rotation = Quaternion.Euler(0,0,0);
			GameObject currentEnemy = Instantiate(enemy[(int)type],spawnLocation, rotation) as GameObject;
			enemyList.Add(currentEnemy);
		}
		
		public int Count()
		{
			int result = (int)enemyList.Count;
			return(result);
		}
		
		public void Remove(int index = 0)
		{
			enemyList.RemoveAt(index);
		}
		
		public void removeAll()
		{
			enemyList.Clear();	
		}
		
	}
