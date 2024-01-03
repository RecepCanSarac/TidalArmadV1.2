using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "Immortality", menuName = "Skills/Immortality")]
public class SOImmortality : SOSkill
{
    public GameObject ship;
    public override void Skill()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");

        if (isActive == true)
        {
            ship.GetComponent<ShipHealthManagment>().immortality = true;
        }
        else
        {
            ship.GetComponent<ShipHealthManagment>().immortality = false;
        }
    }
}
