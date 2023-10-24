using UnityEngine;

public class BulletObject : MonoBehaviour
{
    private Rigidbody2D rb;

    private float bulletSpeed;
    private float rotateSpeed = 20f;
    private float scaleMultiplier = 1f;
    private float damage;

    private Vector3 startPoint = Vector3.zero;
    private Vector3 targetPoint = Vector3.zero;

    public SOBullet bullet;

    public void Set(Vector3 targetPoint, float scale)
    {
        this.targetPoint = targetPoint;

        startPoint = transform.position;
        scaleMultiplier = scale;

        //damage = data.bulletDamage;
        bulletSpeed = 6;
    }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void FixedUpdate()
    {

        transform.position = CalculatePoint();
    }

    Vector3 CalculatePoint()
    {
        Vector2 direction = (Vector2)(targetPoint - startPoint);

        float next = Mathf.MoveTowards(transform.position.x, targetPoint.x, bulletSpeed * Time.deltaTime);
        float baseY = Mathf.Lerp(startPoint.y, targetPoint.y, (next - startPoint.x) / direction.x);
        float height = 0.2f * (next - startPoint.x) * (next - targetPoint.x) / (-.5f * direction.x) * scaleMultiplier;

        Vector3 result = new Vector3(next, baseY + height, 0);

        return result;
    }
}