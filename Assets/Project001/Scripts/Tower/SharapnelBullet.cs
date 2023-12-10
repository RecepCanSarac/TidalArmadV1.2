using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharapnelBullet : MonoBehaviour
{
    public float radius;

    public float impactDamage;

    public LayerMask mask;
    public void Expolosion()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius, mask);

        if (hit.Length > 0)
        {
            foreach (Collider2D col in hit)
            {
                col.GetComponent<EnemyMoveController>().currentHealth -= impactDamage;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
