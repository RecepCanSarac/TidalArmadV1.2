using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "LessDamage", menuName = "Aguments/LessDamage")]
public class SOLessDamage : SOAgument
{
    public SOEnemy[] enemies;
    public override void AugmenFunc()
    {
        for (int i = 0; i < enemies.Length; i++)
        {
            enemies[i].Damage -= (enemies[i].Damage * 20/100);
        }
    }
}
