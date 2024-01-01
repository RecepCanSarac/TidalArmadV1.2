using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthManagment : MonoBehaviour
{
    public SOShip ship;

    private HealthBar healthBar;

    private void Start()
    {
        healthBar = GameObject.FindGameObjectWithTag("HealtBar").GetComponent<HealthBar>();

        healthBar.SetMaxHealth(ship.health);
    }
    private void Update()
    {
        if (ship.guardianAngel == true && ship.health <= 0)
        {
            ///<summary>
            ///Guardian Angel Animation and reborn
            /// </summary>

            Debug.Log("Guardian Angel Actived");
        }
        else if (ship.guardianAngel == false && ship.health <= 0)
        {
            ///<summary>
            ///Ship Destroy Animation and Just Ship Destroy
            /// </summary>

            Debug.Log("Ship Destroyed");
        }
    }


    public void TakeDamage(float damage)
    {
        ship.health -= damage;

        healthBar.SetHealth(ship.health);
    }
}
