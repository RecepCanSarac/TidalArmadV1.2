using System;
using System.Collections;
using UnityEngine;
using Random = UnityEngine.Random;

public class EnemySpawnerManagment : MonoBehaviour
{
    [SerializeField] Transform leftPos, rightPos, leftTopPos, rightTopPos;
    [SerializeField] int interwaveTime;
    public SpawnableEnemy Wave = new SpawnableEnemy();

    private void Start()
    {
        StartCoroutine(SpawnController());
    }
    private IEnumerator SpawnController()
    {
        for (int i = 0; i < Wave.Wavies.Length; i++)
        {
            for (int j = 0; j < Wave.Wavies[i].Enemy.Length; j++)
            {
                for (int a = 0; a < Wave.Wavies[i].Enemy[j].enemieNumber; a++)
                {
                    if (Wave.Wavies[i].Enemy[j].isFlyable)
                    {
                        int randomNum = Random.Range(0,2);
                        Transform pos;
                        if (randomNum == 0)
                        {
                            pos = leftTopPos;
                        }
                        else
                        {
                            pos = rightTopPos;
                        }
                        Instantiate(Wave.Wavies[i].Enemy[j].enemies.EnemyPrefab, pos.position, Quaternion.identity);
                        yield return new WaitForSeconds(Wave.Wavies[i].Enemy[j].spawnTimer);
                    }
                    if (Wave.Wavies[i].Enemy[j].isFlyable == false)
                    {
                        int randomNum = Random.Range(0, 2);
                        Transform pos;
                        if (randomNum == 0)
                        {
                            pos = leftPos;
                        }
                        else
                        {
                            pos = rightPos;
                        }
                        Instantiate(Wave.Wavies[i].Enemy[j].enemies.EnemyPrefab, pos.position, Quaternion.identity);
                        yield return new WaitForSeconds(Wave.Wavies[i].Enemy[j].spawnTimer);
                    }
                }
            }
            yield return new WaitForSeconds(Wave.Wavies[i].WaveTimer);
        }
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
