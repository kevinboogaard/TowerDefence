using UnityEngine;
using System.Collections;
using System.Collections.Generic;

[RequireComponent(typeof(GameManager))]
public class CreatureManager : MonoBehaviour
{
    public List<GameObject> enemyTypes;
    public int[] amountEnemy; // linked with enemyTypes.

    private GameObject _enemyType;

    public List<string> getWave(int _waveNumber)
    {
        List<string> wave = new List<string>();
        int amount = amountEnemy[0];

        for (int i = 0; i < amount; i++)
        {
            wave.Add(enemyTypes[0].name);
        }
        return wave;
    }


    public void SetSkills(List<GameObject> _currentEnemies, int _wave)
    {
        for (int i = 0; i < _currentEnemies.Count; i++)
        {
            int[] skills = GetSkills(_currentEnemies, _wave, i);
            Enemy enemyClass = _currentEnemies[i].GetComponent<Enemy>();

            /* Health, Speed, Damage, Currency */

            enemyClass.health = skills[0];
            enemyClass.speed = skills[1];
            enemyClass.damage = skills[2];
            enemyClass.currency = skills[3];
        }
    }

    public List<GameObject> SpawnEnemies(List<string> _currentEnemies)
    {
        List<GameObject> _enemyList = new List<GameObject>();

        /* 
        * Count all enemies in the currentEnemy list. 
        * Translate the string into the GameObject.
        * Spawn the enemy.
        */
        for (int i = 0; i < _currentEnemies.Count; i++)
        {
            for (int j = 0; j < 1; j++)
            {
                if (enemyTypes[j].name == _currentEnemies[i])
                {
                    _enemyType = enemyTypes[j];
                }

            }

            GameObject _enemy = _enemyType;

            _enemyList.Add(_enemy);

        }

        return _enemyList;
    }

    int[] GetSkills(List<GameObject> _currentEnemies, int _wave, int _i)
    {
        int[] skills = new int[] { 0, 0, 0, 0 };

        int health;
        int speed;
        int damage;
        int currency;

        for (int i = 0; i < _currentEnemies.Count; i++)
        {
            if (_currentEnemies[i].name == "Anim_Enemy_1_Run")
            {
                health = 10 * _wave;
                speed = 2 * _wave;
                damage = 2 * _wave;
                currency = 14 * _wave;

                skills = new int[] { health, speed, damage, currency };
            }
            else if (_currentEnemies[i].name == "Anim_Enemy_2_Run 1")
            {
                health = 10 * _wave;
                speed = 2 * _wave;
                damage = 2 * _wave;
                currency = 14 * _wave;

                skills = new int[] { health, speed, damage, currency };
            }
        }

        return skills;
    }
}
