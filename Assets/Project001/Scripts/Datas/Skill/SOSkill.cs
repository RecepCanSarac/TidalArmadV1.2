using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[CreateAssetMenu(fileName ="Skill",menuName ="Skill/Skill")]
public class SOSkill : ScriptableObject
{
    public string SkillName;
    public Sprite SkillSprite;
    public GameObject SkillPrefab;
}
