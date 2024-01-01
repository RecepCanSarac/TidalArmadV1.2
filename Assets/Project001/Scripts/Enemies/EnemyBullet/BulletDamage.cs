using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletDamage : MonoBehaviour
{
    public float Damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent<ShipHealthManagment>(out ShipHealthManagment ship))
        {
            ship.TakeDamage(Damage);
        }
    }
}
