using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class speedTower : MonoBehaviour
{
    private ShipController shipController;

    public SOTowerLevel tower;
    private void Start()
    {
        shipController = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipController>();

        shipController.currentSpeed += tower.attackSpeed;
    }

}
