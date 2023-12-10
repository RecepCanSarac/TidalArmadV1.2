using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Barrel : MonoBehaviour
{
    public float radius;

    public LayerMask mask;

    public float Force;

    public float Damage;


    void explode()
    {
        Collider2D[] rayInfo = Physics2D.OverlapCircleAll(transform.position, radius, mask);

        foreach (Collider2D ray in rayInfo)
        {
            Vector2 Direction = ray.transform.position - transform.position;
            ray.GetComponent<Rigidbody2D>().AddForce(Direction * Force);
        }
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<EnemyMoveController>())
        {
            explode();
            collision.gameObject.GetComponent<EnemyMoveController>().currentHealth -= Damage;
            Destroy(gameObject);
        }
    }
}
