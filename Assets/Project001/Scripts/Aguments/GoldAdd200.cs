using UnityEngine;

public class GoldAdd200 : MonoBehaviour,IClickable
{
    int sayac = 0;
   
    public void Click()
    {
        Debug.Log("Altýn");
        //PlayerPrefs.GetInt("sayac", 0);
        //if (sayac == 0)
        //{
        //    EconomyManager.instance.IncreaseGold(200);
        //    sayac = 1;
        //    PlayerPrefs.SetInt("sayac", 1);

            //calismayabilir ayarlarýz

    }
}
