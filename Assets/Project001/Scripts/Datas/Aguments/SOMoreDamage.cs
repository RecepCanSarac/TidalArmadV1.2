using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "MoreDamage", menuName = "Aguments/MoreDamage")]
public class SOMoreDamage : SOAgument
{
    public SOBullet[] bullets;
    public override void AugmenFunc()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            Debug.Log(bullets[i].bulletDamage);
            bullets[i].bulletDamage += (bullets[i].bulletDamage * 10 / 100);
            Debug.Log(bullets[i].bulletDamage);
        }
    }
}
