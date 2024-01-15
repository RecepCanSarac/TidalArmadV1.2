using System;
using System.Collections;
using System.Collections.Generic;  // List kullanabilmek için
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerManagment : MonoBehaviour
{
    [SerializeField] Transform leftPos, rightPos, leftTopPos, rightTopPos;
    [SerializeField] int interwaveTime;
    public SpawnableEnemy Wave = new SpawnableEnemy();

    private int totalEnemies; // Toplam canavar sayýsýný saklamak için
    private List<GameObject> spawnedEnemies = new List<GameObject>();


    public GameObject panel;

    private void Start()
    {
        StartCoroutine(SpawnController());
        panel.SetActive(false);
    }

    private void Update()
    {
        if (AllEnemiesDead() == true)
        {

            panel.SetActive(true);
        }
    }
    private IEnumerator SpawnController()
    {
        CalculateTotalEnemies();

        for (int i = 0; i < Wave.Wavies.Length; i++)
        {
            for (int j = 0; j < Wave.Wavies[i].Enemy.Length; j++)
            {
                for (int a = 0; a < Wave.Wavies[i].Enemy[j].enemieNumber; a++)
                {
                    Transform pos;
                    if (Wave.Wavies[i].Enemy[j].isFlyable)
                    {
                        int randomNum = Random.Range(0, 2);
                        pos = (randomNum == 0) ? leftTopPos : rightTopPos;
                    }
                    else
                    {
                        int randomNum = Random.Range(0, 2);
                        pos = (randomNum == 0) ? leftPos : rightPos;
                    }

                    GameObject spawnedEnemy = Instantiate(Wave.Wavies[i].Enemy[j].enemies.EnemyPrefab, pos.position, Quaternion.identity);
                    spawnedEnemies.Add(spawnedEnemy);

                    yield return new WaitForSeconds(Wave.Wavies[i].Enemy[j].spawnTimer);
                }
            }

            yield return new WaitUntil(() => AllEnemiesDead());
            yield return new WaitForSeconds(Wave.Wavies[i].WaveTimer);
        }

        Debug.Log("Bölüm Tamamlandý!");
    }

    private void CalculateTotalEnemies()
    {
        totalEnemies = 0;
        foreach (var wave in Wave.Wavies)
        {
            foreach (var enemyType in wave.Enemy)
            {
                totalEnemies += enemyType.enemieNumber;
            }
        }
    }

    private bool AllEnemiesDead()
    {
        for (int i = spawnedEnemies.Count - 1; i >= 0; i--)
        {
            if (spawnedEnemies[i] == null)
            {
                spawnedEnemies.RemoveAt(i);
            }
        }

        return spawnedEnemies.Count == 0;
    }
}

[Serializable]
public class SpawnableEnemy
{
    public WaveType[] Wavies;
}

[Serializable]
public class WaveType
{
    public Enemies[] Enemy;
    public float WaveTimer;
}

[Serializable]
public class Enemies
{
    public SOEnemy enemies;
    public bool isFlyable;
    public int enemieNumber;
    public float spawnTimer;
}
