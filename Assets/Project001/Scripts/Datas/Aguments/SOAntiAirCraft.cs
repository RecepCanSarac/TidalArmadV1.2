using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SOAntiAirCraft", menuName = "Aguments/SOAntiAirCraft")]
public class SOAntiAirCraft : SOAgument
{
    public SOBullet[] bullets = null;
    public float slow;
    public override void AugmenFunc()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].bulletSlowEnemy += slow;
            Debug.Log(bullets[i].bulletSlowEnemy);
        }
       used = true;
    }
}
