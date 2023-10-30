
using UnityEngine;

public class FastAttackSpeed : MonoBehaviour
{
    public static FastAttackSpeed instance;
    private void Awake() => instance = this;


    public SOTowerLevel[] towers = null;

    public float[] currentSpeed;

    private void OnEnable()
    {
        for (int i = 0; i < towers.Length; i++)
        {
            currentSpeed[i] = towers[i].attackSpeed;
        }
    }
    private void OnDisable()
    {
        for (int i = 0; i < towers.Length; i++)
        {
            towers[i].attackSpeed = currentSpeed[i];
        }
    }
    private void Start()
    {
        for (int i = 0; i < towers.Length; i++)
        {
            towers[i].attackSpeed = towers[i].attackSpeed + (towers[i].attackSpeed * 20)/100;
        }
    }
}
