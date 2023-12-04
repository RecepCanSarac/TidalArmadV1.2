using System.Collections;
using UnityEngine;

public class healthTower : MonoBehaviour
{
    private ShipController shipController;
    public SOTowerLevel tower;

    private bool isCoroutineRunning = true;

    private void Start()
    {
        shipController = GameObject.FindGameObjectWithTag("Ship")?.GetComponent<ShipController>();

        if (shipController == null)
        {
            Debug.LogError("ShipController not found or not assigned!");
            return;
        }

        StartCoroutine(Timer());
    }

    private void Update()
    {
        if (shipController != null && shipController.currentHealth <= shipController.ship?.health)
        {
            isCoroutineRunning = true;
        }
    }

    private IEnumerator Timer()
    {
        while (isCoroutineRunning)
        {
            if (shipController != null && shipController.currentHealth >= shipController.ship?.health)
            {
                isCoroutineRunning = false;
            }

            if (isCoroutineRunning)
            {
                shipController.currentHealth += tower.attackSpeed;
                yield return new WaitForSeconds(1);
            }
        }
    }
}
