using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "SkilActive",menuName = "Aguments/SkilActive")]
public class SOSKillActived : SOAgument
{
    public SOSkill skil;

    public SOSkillSystem SkillSystem;
    public override void AugmenFunc()
    {
        for (int i = 0; i < SkillSystem.SkilList.Count; i++)
        {
            if (skil.name == SkillSystem.SkilList[i].skil.name)
            {
                SkillSystem.SkilList[i].isAvailable = true;
            }
        }
    }
}
