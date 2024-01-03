using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "RapidRecoveryDash", menuName = "Skills/RapidRecoveryDash")]
public class SORapidRecoveryDash : SOSkill
{
    private GameObject ship;
    public int percentage;
    public float speed;
    private float currentSpeed;
    public override void Skill()
    {
        ship = GameObject.FindGameObjectWithTag("Ship");
       
        if (isActive == true)
        {
            currentSpeed = ship.GetComponent<ShipController>().currentSpeed;
            ship.GetComponent<ShipHealthManagment>().currentHealth += ((ship.GetComponent<ShipHealthManagment>().ship.health
                - ship.GetComponent<ShipHealthManagment>().currentHealth) * percentage / 100) + ship.GetComponent<ShipHealthManagment>().currentHealth;
            ship.GetComponent<ShipController>().currentSpeed += speed;

            Debug.Log(ship.GetComponent<ShipController>().currentHealth);
        }
        else
        {
            ship.GetComponent<ShipController>().currentSpeed = currentSpeed;
        }
    }
}
