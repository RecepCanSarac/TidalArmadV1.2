using UnityEngine;

public class EconomyManager : MonoBehaviour
{
    #region Singleton
    public static EconomyManager instance;
    void Awake() => instance = this;
    #endregion

    public float Gold { get; private set; } = 500000;

    public void DecreaseGold(float amount)
    {
        Gold -= amount;
    }

    public void IncreaseGold(float amount)
    {
        Gold += amount;
        Debug.Log(Gold);
    }
}
