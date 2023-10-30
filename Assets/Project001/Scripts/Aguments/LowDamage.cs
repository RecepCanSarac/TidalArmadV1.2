using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LowDamage : MonoBehaviour
{
    public static LowDamage instance;
    private void Awake() => instance = this;


    public SOEnemy[] enemies;

    public float[] currentDamage;

    private void OnEnable()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            currentDamage[i] = enemies[i].Damage;
        }
      
    }
    private void OnDisable()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Damage = currentDamage[i];
        }
    }
    private void Start()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Damage = enemies[i].Damage - (enemies[i].Damage * 20) / 100;
        }
    }
}
