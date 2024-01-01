using UnityEngine;
using System.Collections.Generic;

public class TurnToGold : MonoBehaviour
{
    private static TurnToGold _instance;
    public static TurnToGold Instance
    {
        get
        {
            if (_instance == null)
            {
                GameObject go = new GameObject("TurnToGold");
                _instance = go.AddComponent<TurnToGold>();
            }
            return _instance;
        }
    }

    private List<EnemyMoveController> enemies = new List<EnemyMoveController>();

    private int randomNumber;

    public int Gold;

    private void Awake()
    {
        if (_instance != null && _instance != this)
        {
            Destroy(this.gameObject);
        }
        else
        {
            _instance = this;
            DontDestroyOnLoad(this.gameObject);
        }
    }

    private void Update()
    {
        UpdateEnemyList();
        RemoveDeadEnemies();
    }

    private void UpdateEnemyList()
    {
        EnemyMoveController[] allEnemies = FindObjectsOfType<EnemyMoveController>();

        foreach (EnemyMoveController enemy in allEnemies)
        {
            if (enemy != null && !enemies.Contains(enemy))
            {
                enemies.Add(enemy);
            }
        }
    }

    private void RemoveDeadEnemies()
    {
        for (int i = enemies.Count - 1; i >= 0; i--)
        {
            if (enemies[i] == null || !enemies[i].gameObject.activeSelf || enemies[i].currentHealth <= 0)
            {
                enemies[i].GetComponent<EnemyMoveController>().enemy.Gold += Gold;
                enemies.RemoveAt(i);
            }
        }
    }
}
