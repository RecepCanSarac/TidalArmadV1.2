using System.Collections;
using System.Collections.Generic;
using UnityEngine;
[CreateAssetMenu(fileName = "SupportBuff", menuName = "Aguments/SupportBuff")]
public class SOSupportBuff : SOAgument
{
    public SOTowerLevel[] supportTowers;
    public override void AugmenFunc()
    {
        for (int i = 0; i < supportTowers.Length; i++)
        {
            supportTowers[i].attackSpeed += (supportTowers[i].attackSpeed * 30 / 100);
        }
    }
}
