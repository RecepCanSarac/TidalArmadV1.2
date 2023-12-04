using UnityEngine;

public class EnemyMoveController : MonoBehaviour
{
    public SOEnemy enemy;

    public float currentSpeed;
    public float currentHealth;
    private float currentDamage;

    private Rigidbody2D rb;

    private Transform target;
    private void Start()
    {
        rb = this.GetComponent<Rigidbody2D>();
        currentSpeed = enemy.speed;
        currentHealth = enemy.health;
        currentDamage = enemy.Damage;

    }
    private void Update()
    {

        Invoke("FindTarget", 0.5f);
        if (currentHealth <= 0)
            Destroy(this.gameObject);
    }

    private void FindTarget()
    {
        target = GameObject.FindGameObjectWithTag("Ship").transform;

        if (transform.position.x < target.position.x)
        {
            EnemyMove(currentSpeed);
        }
        else if (transform.position.x > target.position.x)
        {
            EnemyMove(-currentSpeed);
        }
    }

    private void EnemyMove(float speed)
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            currentSpeed = 0;
            //Atack
        }
        if (other.gameObject.GetComponent<BulletObject>())
        {
            currentHealth -= other.gameObject.GetComponent<BulletObject>().bullet.bulletDamage;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Ship"))
        {
            currentSpeed = enemy.speed;
        }
    }
    private void OnParticleCollision(GameObject other)
    {
        currentHealth -= other.gameObject.GetComponent<FlameBullet>().level.damage;
    }

}
