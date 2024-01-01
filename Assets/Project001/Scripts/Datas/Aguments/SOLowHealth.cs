using System.Collections;
using System.Collections.Generic;
using System.Security.Policy;
using UnityEngine;

[CreateAssetMenu(fileName = "LowHealth", menuName = "Aguments/LowHealth")]
public class SOLowHealth : SOAgument
{
    public int percentage = 50;

    public float speed;
    public float damage;

    public SOShipSpawn ship;

    public SOBullet[] bullet;

    public override void AugmenFunc()
    {
        if (ship.SpawnPrefab.GetComponent<ShipHealthManagment>().currentHealth < (ship.SpawnPrefab.GetComponent<ShipHealthManagment>().currentHealth * percentage / 100))
        {
            for (int i = 0; i < bullet.Length; i++)
            {
                bullet[i].bulletDamage += damage;
            }
            ship.SpawnPrefab.GetComponent<ShipHealthManagment>().currentSpeed += speed;
        }
    }
}
