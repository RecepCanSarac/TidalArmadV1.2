using UnityEngine;

public class MoreGold : MonoBehaviour
{
    public static MoreGold instance;
    private void Awake() => instance = this;

    public SOEnemy[] enemiyGolds = null;

    public int[] currentGold;

    public int AddedGold;

    private void OnEnable()
    {
        for (int i = 0; enemiyGolds.Length > i; i++)
        {
            currentGold[i] = enemiyGolds[i].Gold;
        }
    }

    private void OnDisable()
    {
        for (int i = 0; enemiyGolds.Length > i; i++)
        {
            enemiyGolds[i].Gold = currentGold[i];
        }
    }
    private void Start()
    {
        for (int i = 0; i < enemiyGolds.Length; i++)
        {
            enemiyGolds[i].Gold = enemiyGolds[i].Gold + AddedGold;
        }
    }
}
