using UnityEngine;

public class GoldAdd200 : MonoBehaviour
{
    int sayac = 0;

    private void Start()
    {

        PlayerPrefs.GetInt("sayac",0);
        if (sayac == 0)
        {
            EconomyManager.instance.IncreaseGold(200);
            sayac = 1;
            PlayerPrefs.SetInt("sayac",1);

            //calismayabilir ayarlarýz
        }
    }
}
