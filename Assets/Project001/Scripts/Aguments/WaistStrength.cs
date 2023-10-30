
using UnityEngine;

public class WaistStrength : MonoBehaviour
{
    public static WaistStrength instance;
    private void Awake() => instance = this;

    public SOBullet[] bullets;

    public float[] currentDamage;

    private void OnEnable()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            currentDamage[i] = bullets[i].bulletDamage;
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].bulletDamage = currentDamage[i];
        }
    }
    private void Start()
    {
        for (int i = 0; i < bullets.Length; i++)
        {
            bullets[i].bulletDamage = bullets[i].bulletDamage + (bullets[i].bulletDamage * 10) / 100;
        }
    }
}
