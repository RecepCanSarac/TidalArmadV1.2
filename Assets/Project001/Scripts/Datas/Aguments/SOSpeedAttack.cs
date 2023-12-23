using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SpeedAttack", menuName = "Aguments/SpeedAttack")]
public class SOSpeedAttack : SOAgument
{
    public SOTowerLevel[] towers;

    public override void AugmenFunc()
    {
        for (int i = 0; i < towers.Length; i++)
        {
            towers[i].attackSpeed = (towers[i].attackSpeed * 20 / 100);
        }
    }
}
