using UnityEngine;
using UnityEngine.SceneManagement;

public class ShipController : MonoBehaviour
{
    public SOShip ship;
    public SOShipUpgradeble upgradeble;
    public float currentSpeed;
    public float currentHealth;
    private Rigidbody2D rb;
    private bool isFacingRight = true;

    private HealthBar healthBar;


    public float minX = -5f;
    public float maxX = 5f;
    private void Start()
    {
        currentSpeed = ship.speed;
        currentHealth = ship.health;
        rb = GetComponent<Rigidbody2D>();

        healthBar = GameObject.FindGameObjectWithTag("HealtBar").GetComponent<HealthBar>();
        healthBar.SetMaxHealth(currentHealth);
    }

    private void Update()
    {
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
           
            float hareketInput = Input.GetAxis("Horizontal"); 
            rb.velocity = new Vector2(hareketInput * currentSpeed * Time.deltaTime, 0f);
            float x = Mathf.Clamp(transform.position.x, minX, maxX);
            transform.position = new Vector3(x, transform.position.y, transform.position.z);
            if (!Mathf.Approximately(hareketInput, 0f))
            {
                Quaternion hedefRotasyon = Quaternion.Euler(0f, hareketInput < 0 ? 180f : 0f, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, hedefRotasyon, 5 * Time.deltaTime);
            }
            else
            {
                Quaternion hedefRotasyon = Quaternion.Euler(0f, isFacingRight ? 0f : 180f, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, hedefRotasyon, 5 * Time.deltaTime);
            }

            if (hareketInput > 0)
            {
                isFacingRight = true;
            }
            else if (hareketInput < 0)
            {
                isFacingRight = false;
            }
        }
    }
}
