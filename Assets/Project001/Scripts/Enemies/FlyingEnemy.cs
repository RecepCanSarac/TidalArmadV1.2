using UnityEngine;

public class FlyingEnemy : MonoBehaviour
{
    private EnemyMoveController controller;
    public LayerMask ship;
    public Transform shootPoint;
    Transform target;
    private float fireRate;
    private void Start()
    {
        controller = GetComponent<EnemyMoveController>();

    }
    private void Update()
    {
        EnemyTrigger();
    }
    private void EnemyTrigger()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, controller.enemy.AttackRange, ship);
        if (hit is not null)
        {
            target = hit.transform;
            Vector2 direction = target.position - transform.position;
            direction.Normalize();
            fireRate += Time.deltaTime;
            if (fireRate > controller.enemy.AttackSpeed / 1)
            {
                Shoot(controller.enemy.bulletPrefabs, direction);
                fireRate = 0;
                controller.currentSpeed = 0;
            }
        }
        else
        {
            controller.currentSpeed = controller.enemy.speed;
        }
    }
    private void Shoot(GameObject bullet, Vector2 direction)
    {
        GameObject bul = Instantiate(bullet, shootPoint.position, Quaternion.identity);

        bul.GetComponent<Rigidbody2D>().AddForce(direction * 280);
        bul.GetComponent<Rigidbody2D>().AddForce(transform.up * 150);
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 5);
        Gizmos.color = Color.yellow;
    }
}