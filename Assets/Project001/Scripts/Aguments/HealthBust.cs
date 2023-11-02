using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBust : MonoBehaviour
{
    private ShipController Ship;

    private float currentHealth;
    private void OnEnable()
    {
        currentHealth = Ship.currentHealth;
    }
    private void OnDisable()
    {
        Ship.currentHealth = currentHealth;
    }
    private void Start()
    {
        Ship = GameObject.FindGameObjectWithTag("Ship").GetComponent<ShipController>();

        Ship.currentHealth = Ship.currentHealth + (Ship.currentHealth * 20) / 100;
    }
}
