using UnityEngine;


[CreateAssetMenu(fileName = "ShipSpawn", menuName = "Ship/ShipSpawner")]
public class SOShipSpawn : ScriptableObject
{
    public GameObject SpawnPrefab;

    public Vector2 spawnPos;
}