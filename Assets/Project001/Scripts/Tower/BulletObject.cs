using UnityEngine;

public class BulletObject : MonoBehaviour
{
    private Rigidbody2D rb;

    [SerializeField] private float bulletSpeed = 6f;
    [SerializeField] private float rotateSpeed = 20f;
    [SerializeField] private float scaleMultiplier = 1f;
    [SerializeField] private float damage;

    private Vector3 startPoint = Vector3.zero;
    private Vector3 targetPoint = Vector3.zero;

    public SOBullet bullet;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Set(Vector3 targetPoint, float scale)
    {
        this.targetPoint = targetPoint;
        startPoint = transform.position;
        scaleMultiplier = scale;
        //damage = data.bulletDamage; // Bu satýrý neden yorum satýrýna aldýnýz bilmiyorum, gerekirse açabilirsiniz.
    }

    private void Update()
    {
        MoveBullet();
    }

    private void MoveBullet()
    {
        transform.position = CalculatePoint();

        // Eðer hedefe ulaþýldýysa yok ol.
        if (Vector3.Distance(transform.position, targetPoint) < 0.1f)
        {
            DestroyBullet();
        }
    }

    private void DestroyBullet()
    {
        // Buraya gerekirse baþka kodlar ekleyebilirsiniz, örneðin patlama efekti veya skor artýþý gibi.
        Destroy(gameObject);
    }

    private Vector3 CalculatePoint()
    {
        Vector2 direction = (Vector2)(targetPoint - startPoint);

        float next = Mathf.MoveTowards(transform.position.x, targetPoint.x, bulletSpeed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPoint.y, targetPoint.y, (next - startPoint.x) / direction.x);
        float height = 0.2f * (next - startPoint.x) * (next - targetPoint.x) / (-.5f * direction.x) * scaleMultiplier;

        return new Vector3(next, baseY + height, 0);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        EnemyMoveController enemy = other.GetComponent<EnemyMoveController>();
        if (enemy != null)
        {
            // Destroy the bullet directly
            Destroy(gameObject);
        }
    }
}
