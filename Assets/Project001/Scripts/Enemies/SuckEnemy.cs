using UnityEngine;

public class SuckEnemy : MonoBehaviour
{
    private EnemyMoveController controller;


    public LayerMask ship;
    private void Start() => controller = GetComponent<EnemyMoveController>();
    private void FixedUpdate() => EnemyTrigger();

    private void EnemyTrigger()
    {
        Collider2D hit = Physics2D.OverlapCircle(transform.position, controller.enemy.AttackRange, ship);
        if (hit != null)
        {
            if (hit.transform.position.x > transform.position.x)
            {
                hit.GetComponent<Rigidbody2D>().AddForce(controller.enemy.Damage * -transform.right);
            }
            else if (hit.transform.position.x < transform.position.x)
            {
                hit.GetComponent<Rigidbody2D>().AddForce(controller.enemy.Damage * transform.right);
            }
            controller.currentSpeed = 0;
        }
        else
        {
            controller.currentSpeed = controller.enemy.speed;
        }
    }

    private void OnDrawGizmosSelected()
    {
        Gizmos.DrawWireSphere(transform.position, 3f);
        Gizmos.color = Color.white;
    }
}
