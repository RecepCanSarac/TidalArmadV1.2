using System.Collections;
using System.Collections.Generic;
using UnityEngine;
public enum MapType
{
    MinorEnemy,
    EliteEnemy,
    RestSite,
    Treasure,
    Store,
    Boss,
    Mystery
}

[CreateAssetMenu(fileName = "Enemy", menuName = "Enemy/Enemy")]
public class SOEnemy : ScriptableObject
{
    [Header("EnemyType")]
    public MapType MapType;
    [Header("Attributes")]
    public float health;
    public float speed;
    public float Damage;
    public int Gold;
    [Space]
    [Header("specialValue")]
    public float AttackRange;
    public float AttackSpeed;
    public Transform ShootPoint;
    public GameObject bulletPrefabs;
    [Header("GameObject")]
    public GameObject EnemyPrefab;
}
