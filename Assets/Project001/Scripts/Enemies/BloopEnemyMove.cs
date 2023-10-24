using UnityEngine;

public class BloopEnemyMove : MonoBehaviour
{
    public float amplitude = 1f;
    public float frequency = 1f;
    public float xMove = 0.01f;
    public Transform hitPoint;
    public SOEnemy bloopEnemy;
    private float currentHealth;

    private Vector3 initialPosition;

    private Transform _Target;

    float y;
    private BloopEnemyAttack attack;
    private void Start()
    {
        Invoke("FindTarget", 0.5f);
        initialPosition = transform.position;
        attack = GetComponent<BloopEnemyAttack>();
        attack.enabled = false;
        currentHealth = bloopEnemy.health;
    }

    private void Update()
    {
        if (currentHealth <= 0)
        {
            EconomyManager.instance.IncreaseGold(bloopEnemy.Gold);
            Destroy(gameObject);
        }
        bloopMove();
        EnemyMove();
    }
    private void EnemyMove()
    {
        RaycastHit2D hit = Physics2D.Raycast(hitPoint.position, -hitPoint.transform.up, bloopEnemy.AttackRange);
        if (hit.collider != null)
        {
            if (hit.collider.CompareTag("Ship") || hit.collider.CompareTag("Tower"))
            {
                Debug.DrawLine(hitPoint.position, hit.point, Color.red);
                xMove = 0;
                frequency = 0;
                Invoke("TriggerEnemy", 1f);
            }
            else
            {
                Debug.DrawLine(hitPoint.position, hit.point, Color.green);
            }
        }
    }
    private void FindTarget()
    {
        _Target = GameObject.FindGameObjectWithTag("Ship").transform;

        if (transform.position.x < _Target.position.x)
        {
            xMove *= 1;
        }
        else if (transform.position.x > _Target.position.x)
        {
            xMove *= -1;
        }
    }
    private void bloopMove()
    {
        float x = transform.position.x;
        y = amplitude + Mathf.Sin(frequency * Time.time);

        transform.position = new Vector3(x, y, transform.position.z);
        transform.Translate(xMove, 0, 0);
    }

    private void TriggerEnemy()
    {
        attack.enabled = true;
        enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.GetComponent<BulletObject>())
        {
            currentHealth -= other.gameObject.GetComponent<BulletObject>().bullet.bulletDamage;
        }
    }
}