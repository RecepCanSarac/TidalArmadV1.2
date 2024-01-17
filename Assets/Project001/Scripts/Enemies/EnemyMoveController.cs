using System.Collections;
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
            EnemyMove(currentSpeed , true);
        }
        else if (transform.position.x > target.position.x)
        {
            EnemyMove(-currentSpeed , false);
        }
    }

    private void EnemyMove(float speed , bool flip)
    {
        rb.velocity = new Vector2(speed * Time.deltaTime, rb.velocity.y);
        this.gameObject.GetComponent<SpriteRenderer>().flipX = flip;
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent<ShipHealthManagment>(out ShipHealthManagment ship))
        {
            ship.TakeDamage(currentDamage);
        }
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<ShipHealthManagment>(out ShipHealthManagment ship))
        {
            ship.TakeDamage(currentDamage);
        }
        if (other.gameObject.GetComponent<BulletObject>())
        {
            currentHealth -= other.gameObject.GetComponent<BulletObject>().bullet.bulletDamage;
            currentSpeed -= other.gameObject.GetComponent<BulletObject>().bullet.bulletSlowEnemy;
        }
        if (other.gameObject.GetComponent<FireBullet>())
        {
            StartCoroutine(Timer(3, true));
        }
        if (other.gameObject.GetComponent<SharapnelBullet>())
        {
            other.gameObject.GetComponent<SharapnelBullet>().Expolosion();
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
  
    private IEnumerator Timer(float damage, bool contact)
    {
        float number = 0;
        while (contact)
        {
            number++;
            if (number <= 10)
            {
                currentHealth -= damage;
                yield return new WaitForSeconds(1);
                Debug.Log(number);
            }
            if (number >= 10)
            {
                contact = false;
            }
        }
    }
}
