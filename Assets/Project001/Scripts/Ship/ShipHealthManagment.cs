using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShipHealthManagment : MonoBehaviour
{
    public SOShip ship;

    public float currentHealth;
    public float currentSpeed;
    private HealthBar healthBar;

    private void Start()
    {
        
        currentHealth = PlayerPrefs.GetFloat(nameof(currentHealth), ship.health);
        currentSpeed = PlayerPrefs.GetFloat(nameof(currentSpeed), ship.speed);

        healthBar = GameObject.FindGameObjectWithTag("HealtBar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(ship.health);
        healthBar.SetHealth(currentHealth); 
    }

    private void Update()
    {

        PlayerPrefs.SetFloat(nameof(currentSpeed), currentSpeed);
        if (ship.guardianAngel == true && currentHealth <= 0)
        {
            // Guardian Angel aktifse ve sa�l�k s�f�rsa geri do�ma i�lemleri
            Debug.Log("Guardian Angel Activated");
        }
        else if (ship.guardianAngel == false && currentHealth <= 0)
        {
            // Guardian Angel aktif de�ilse ve sa�l�k s�f�rsa gemi yok olma i�lemleri
            Debug.Log("Ship Destroyed");
        }
        healthBar.SetHealth(currentHealth);
    }

    public void TakeDamage(float damage)
    {
        currentHealth -= damage;

        healthBar.SetHealth(currentHealth);
        PlayerPrefs.SetFloat(nameof(currentHealth), currentHealth);
        PlayerPrefs.Save();
    }
}
