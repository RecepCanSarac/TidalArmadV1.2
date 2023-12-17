using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "EarlyPayCheck", menuName = "Aguments/EarlyPayCheck")]
public class SOEarlyPayCheck : SOAgument
{

    public float gold;

    public override void AugmenFunc()
    {
        EconomyManager.instance.IncreaseGold(gold);
        
        used = true;

    }
}
