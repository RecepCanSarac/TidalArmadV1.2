using UnityEngine;

public class ShipController : MonoBehaviour
{
    public SOShip ship;
    public SOShipUpgradeble upgradeble;
    private float currentSpeed;
    public float currentHealth;
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private void Start()
    {
        currentSpeed = ship.speed;
        currentHealth = ship.health;
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        float horizontalMove = Input.GetAxisRaw("Horizontal");
        rb.velocity = new Vector2(horizontalMove * currentSpeed * Time.deltaTime, rb.velocity.y);

        //if (horizontalMove > 0 && !isFacingRight)
        //{
        //    FlipShip();
        //}
        //else if (horizontalMove < 0 && isFacingRight)
        //{
        //    FlipShip();
        //}
    }

    private void FlipShip()
    {
        isFacingRight = !isFacingRight;
        Vector3 scale = transform.localScale;
        scale.x *= -1;
        transform.localScale = scale;
    }
}