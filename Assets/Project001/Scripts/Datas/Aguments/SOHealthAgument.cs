using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "HealthBoost", menuName = "Aguments/HealthBoost")]
public class SOHealthAgument : SOAgument
{
    public SOShipSpawn ship;

    public float health;

    public override void AugmenFunc()
    {
        ship.SpawnPrefab.GetComponent<ShipController>().ship.health += (ship.SpawnPrefab.GetComponent<ShipController>().ship.health * 20 / 100);

        used = true;

        Debug.Log(ship.SpawnPrefab.GetComponent<ShipController>().ship.health);
    }
}
