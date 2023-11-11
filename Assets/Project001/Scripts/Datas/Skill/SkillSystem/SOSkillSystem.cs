using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName ="SkillSystem",menuName ="System/SkillSystem")]
public class SOSkillSystem : ScriptableObject
{
    public List<skilsClass> SkilList = new List<skilsClass>();
}
[Serializable]
public class skilsClass
{
    public SOSkill skil;
    public bool isAvailable;
}
