using UnityEngine;

public class BloopEnemyAttack : MonoBehaviour
{
    private Rigidbody2D rb;
    private BloopEnemyMove bloop;

    public float damage;
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        bloop = GetComponent<BloopEnemyMove>();
    }
    private void FixedUpdate()
    {
        rb.velocity = new Vector2(rb.velocity.x, -bloop.bloopEnemy.AttackSpeed * Time.deltaTime);

        Destroy(gameObject, 3f);
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ship") || other.gameObject.CompareTag("Tower"))
        {
            other.gameObject.GetComponent<ShipHealthManagment>().TakeDamage(damage);
        }
    }
}
