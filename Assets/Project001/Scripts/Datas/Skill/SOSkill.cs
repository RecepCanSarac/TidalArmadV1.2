using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SOSkill : ScriptableObject
{
    public string SkillName;

    public int coolDownTime;
    public int workingTime;

    public bool work;
    public Sprite SkillSprite;
    public bool isActive = true;
    public abstract void Skill();
    
}
