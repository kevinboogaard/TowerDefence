using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class CreatureManager : MonoBehaviour {
	public List<GameObject> enemyTypes;
	public int[] amountEnemy; // linked with enemyTypes.
	
	private GameObject _enemyType;
	
	public List<string> getWave (int waveNumber)
	{
		List<string> wave = new List<string>();
		int amount = amountEnemy[0];

		for(int i = 0; i < amount; i++)
		{
			wave.Add(enemyTypes[0].name);
		}
		return wave;
	}
	
	
	public void SetSkills (List<GameObject>currentEnemies, int wave)
	{
		for (int i = 0; i < currentEnemies.Count; i++)
		{
			int[] skills = GetSkills(currentEnemies, wave, i);
			Enemy enemyClass = currentEnemies[i].GetComponent<Enemy>();

			/* Health, Speed, Damage, Currency */
			
			enemyClass.health = skills[0];
			enemyClass.speed = skills[1];
			enemyClass.damage = skills[2];
			enemyClass.currency = skills[3];
		}
	}
	
	public List<GameObject> SpawnEnemies(List<string> currentEnemies)
	{
		List<GameObject> _enemyList = new List<GameObject>();
		
		/* 
		* Count all enemies in the currentEnemy list. 
		* Translate the string into the GameObject.
		* Spawn the enemy.
		*/
		for(int i = 0; i < currentEnemies.Count; i++) 
		{
			for(int j = 0; j < 1; j++)
			{
				if(enemyTypes[j].name == currentEnemies[i])
				{
					_enemyType = enemyTypes[j];
				}
				
			}
			
            GameObject _enemy =_enemyType;

            _enemyList.Add(_enemy);
            
		}
		
		return _enemyList;
	}
	
	int[] GetSkills(List<GameObject> currentEnemies, int wave, int i)
	{
		int[] skills;
		
		int health;
		int speed;
		int damage;
		int currency;
		
		
		if(currentEnemies[i].name == "Enemy_TestKonijn" + "(Clone)")
		{
				health   = 10 * wave;
				speed    = 4 * wave;
				damage   = 2 * wave;
				currency = 14 * wave;
			
				skills = new int[]{ health, speed, damage, currency };
		} else {
				skills = new int[]{ 0, 0, 0, 0 };
		}
		
		return skills;
	}
}
