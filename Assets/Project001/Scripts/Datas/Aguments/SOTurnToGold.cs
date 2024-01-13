using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "TurnToGold", menuName = "Aguments/TurnToGold")]
public class SOTurnToGold : SOAgument
{
    private GameObject obj;
    public override void AugmenFunc()
    {
        //obj = GameObject.FindGameObjectWithTag("TurnGold");
        //obj.SetActive(true);
    }
}
