using UnityEngine;


[CreateAssetMenu(fileName = "New Ship", menuName = "Ship/ShipData/New Ship")]
public class SOShip : ScriptableObject
{
    public float health;
    public float speed;

    public float price;
    public GameObject ShipPrefab;
}