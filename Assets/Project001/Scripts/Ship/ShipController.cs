using UnityEditor.SearchService;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.SocialPlatforms;

public class ShipController : MonoBehaviour
{
    public SOShip ship;
    public SOShipUpgradeble upgradeble;
    public float currentSpeed;
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
        if (SceneManager.GetActiveScene().buildIndex != 3)
        {
            float hareketInput = Input.GetAxis("Horizontal");
            rb.velocity = new Vector2(hareketInput * currentSpeed * Time.deltaTime, 0f);

            if (!Mathf.Approximately(hareketInput, 0f))
            {
                // Ship is moving, update rotation based on input
                Quaternion hedefRotasyon = Quaternion.Euler(0f, hareketInput < 0 ? 180f : 0f, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, hedefRotasyon, 5 * Time.deltaTime);
            }
            else
            {
                // Ship is not moving, fix rotation to either 0 or 180
                Quaternion hedefRotasyon = Quaternion.Euler(0f, isFacingRight ? 0f : 180f, 0f);
                transform.rotation = Quaternion.Lerp(transform.rotation, hedefRotasyon, 5 * Time.deltaTime);
            }

            // Update isFacingRight based on the current input
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
