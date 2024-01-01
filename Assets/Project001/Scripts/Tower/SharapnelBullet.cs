using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SharapnelBullet : MonoBehaviour
{
    public float radius;

    public float impactDamage;

    public LayerMask mask;

    private BulletObject bullet;

    private void Start()
    {
        bullet = GetComponent<BulletObject>();
    }
    public void Expolosion()
    {
        Collider2D[] hit = Physics2D.OverlapCircleAll(transform.position, radius, mask);

        if (hit.Length > 0)
        {
            foreach (Collider2D col in hit)
            {
                col.GetComponent<EnemyMoveController>().currentHealth -= impactDamage;
                col.GetComponent<EnemyMoveController>().currentSpeed -= bullet.bullet.bulletSlowEnemy;
            }
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.yellow;
        Gizmos.DrawWireSphere(transform.position, radius);
    }
}
