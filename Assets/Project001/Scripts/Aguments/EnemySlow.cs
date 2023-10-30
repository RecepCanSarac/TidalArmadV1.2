
using UnityEngine;

public class EnemySlow : MonoBehaviour
{
    public static EnemySlow instance;
    private void Awake() => instance = this;

    public SOEnemy[] enemySpeed;

    public float[] currentSpeed;

    private void OnEnable()
    {
        for (int i = 0; i < enemySpeed.Length; i++)
        {
            currentSpeed[i] = enemySpeed[i].speed;
        }
    }
    private void OnDisable()
    {
        for(int i = 0;i < enemySpeed.Length; i++)
        {
            enemySpeed[i].speed = currentSpeed[i];
        }
    }

    private void Start()
    {
        for (int i = 0; i < enemySpeed.Length; i++)
        {
            enemySpeed[i].speed = enemySpeed[i].speed;//Düzeltilicek 
        }
    }
}
