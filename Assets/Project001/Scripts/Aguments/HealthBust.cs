using UnityEngine;

public class HealthBust : MonoBehaviour,IClickable
{

    public SOShipSpawn ship;

 

    public void Click()
    {
        Debug.Log("HealtBust");
        //Ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipController>();

        ship.SpawnPrefab.GetComponent<ShipController>().currentHealth = ship.SpawnPrefab.GetComponent<ShipController>().currentHealth + (ship.SpawnPrefab.GetComponent<ShipController>().currentHealth * 20)/ 100;
        Debug.Log(ship.SpawnPrefab.GetComponent<ShipController>().currentHealth);
    }
}
