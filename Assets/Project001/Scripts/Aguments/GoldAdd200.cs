using UnityEngine;

public class GoldAdd200 : MonoBehaviour
{
    int sayac = 0;

    private void Start()
    {
        if (sayac == 0)
        {
            EconomyManager.instance.IncreaseGold(200);
            sayac = 1;
        }
    }
}
