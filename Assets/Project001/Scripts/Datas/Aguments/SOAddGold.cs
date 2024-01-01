using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "AddGold", menuName = "Aguments/AddGold")]
public class SOAddGold : SOAgument
{
    public int Gold;

    public override void AugmenFunc()
    {
        EconomyManager.instance.IncreaseGold(Gold);
    }
}
