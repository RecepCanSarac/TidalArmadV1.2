using Map;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using Random = UnityEngine.Random;



public class RandomMapManangment : MonoBehaviour
{
    public NormalLevel normalLevel = new NormalLevel();
    public ElitLevel elitLevel = new ElitLevel();
    public BossLevel bossLevel = new BossLevel();

    private void Start()
    {
        for (int i = 0; i < normalLevel.levelNumber.Length; i++)
        {
            normalLevel.levelNumber[i] = i;
        }
        for (int i = 0; i < elitLevel.levelNumber.Length; i++)
        {
            elitLevel.levelNumber[i] = i;
        }
        for (int i = 0; i < bossLevel.levelNumber.Length; i++)
        {
            bossLevel.levelNumber[i] = i;
        }
    }

    public void SetSceneLevelType(MapNode type)
    {
        switch (type.Node.nodeType)
        {
            case NodeType.MinorEnemy:
                int randomMinor = Random.Range(0, normalLevel.levelNumber.Length);
                SceneManager.LoadScene("Minor " + 0);
                break;
            case NodeType.EliteEnemy:
                int randomElit = Random.Range(0,elitLevel.levelNumber.Length);
                SceneManager.LoadScene("Elit " + randomElit);
                break;
            case NodeType.Boss:
                int randomBoss = Random.Range(0, bossLevel.levelNumber.Length);
                SceneManager.LoadScene("Boss " + randomBoss);
                break;
        }
    }
}

[Serializable]
public class NormalLevel
{
    public MapType Type;
    public int[] levelNumber;
}

[Serializable]
public class ElitLevel
{
    public MapType Type;
    public int[] levelNumber;
}

[Serializable]
public class BossLevel
{
    public MapType Type;
    public int[] levelNumber;
}