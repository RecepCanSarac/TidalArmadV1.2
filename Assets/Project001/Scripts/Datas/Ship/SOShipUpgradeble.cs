using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName = "New Ship", menuName = "Ship/ShipData/ShipUpgrade")]
public class SOShipUpgradeble : ScriptableObject
{
    public List<SOShip> shipUpgrade = new();
}
