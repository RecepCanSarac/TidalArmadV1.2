using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "GuardianAngel",menuName ="Aguments/GuardianAngel")]
public class SOGuardianAngel : SOAgument
{
    public SOShipSpawn ship;
    public override void AugmenFunc()
    {
        ship.SpawnPrefab.GetComponent<ShipController>().ship.guardianAngel = true;
        used = true;
    }
}
