using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomEnemyGold : MonoBehaviour
{
    public int AddGold;
    public List<SOEnemy> enemyList = new List<SOEnemy>();

    void Update()
    {
        RandomGold();
    }

    public void RandomGold()
    {
        int randomNumber = Random.Range(0, enemyList.Count);

        if (enemyList.Count == 0)
        {
            return;
        }

        SOEnemy selectedEnemy = enemyList[randomNumber];

        if (selectedEnemy.health == 0)
        {
            EnemyDied(selectedEnemy);
            EconomyManager.instance.IncreaseGold(AddGold);
        }
    }

    public void AddEnemyToTheList(SOEnemy enemy)
    {
        if (!enemyList.Contains(enemy))
        {
            enemyList.Add(enemy);
            Debug.Log("D��man listeye eklendi: " + enemy.Gold);
        }
        else
        {
            Debug.Log("D��man zaten listede var: " + enemy.Gold);
        }
    }

    public void EnemyDied(SOEnemy enemy)
    {
        if (enemyList.Contains(enemy))
        {
            enemyList.Remove(enemy);
            Debug.Log("D��man listeden ��kar�ld�: " + enemy.Gold);
        }
    }
}
