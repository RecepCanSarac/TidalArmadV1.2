using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Buff", menuName = "Skills/Buff")]
public class SOBuff : SOSkill
{
    private GameObject ship;

    public SOTowerLevel[] tower;


    public float[] attackSpeed;

    public float speed;
    public override void Skill()
    {
        if (isActive == true)
        {
            ship = GameObject.FindGameObjectWithTag("Ship");

            ship.GetComponent<ShipController>().currentSpeed += speed;

            for (int i = 0; i < tower.Length; i++)
            {
                tower[i].attackSpeed += attackSpeed[i];
            }
        }
        else
        {
            ship = GameObject.FindGameObjectWithTag("Ship");

            ship.GetComponent<ShipController>().currentSpeed -= speed;

            for (int i = 0; i < tower.Length; i++)
            {
                tower[i].attackSpeed -= attackSpeed[i];
            }
        }
    }
}
