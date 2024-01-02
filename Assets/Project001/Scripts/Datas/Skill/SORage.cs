using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RageSkill", menuName = "Skills/RageSkill")]
public class SORage : SOSkill
{
    public int time;

    public SOBullet[] bullets;

    public float[] Damage;

    public override void Skill()
    {
        if (isActive == true)
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].bulletDamage += Damage[i];
            }
        }
        else
        {
            for (int i = 0; i < bullets.Length; i++)
            {
                bullets[i].bulletDamage -= Damage[i];
            }
        }
    }
}
