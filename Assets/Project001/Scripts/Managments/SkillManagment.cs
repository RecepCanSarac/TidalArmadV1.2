using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManagment : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<SOSkill> skils = new List<SOSkill>();
    public SOSkillSystem skillSystem;
    GameObject skil;

    void Update()
    {
        for (int i = 1; i <= skils.Count; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                int index = i;
                PressButton(index);
            }
        }

        for (int i = 0; i < skillSystem.SkilList.Count; i++) 
        {
            if (skillSystem.SkilList[i].isAvailable == true)
            {
                if (!skils.Contains(skillSystem.SkilList[i].skil))
                {
                    skils.Add(skillSystem.SkilList[i].skil);
                }
            }
        }
    }

    void PressButton(int buttonIndex)
    {
        if ((buttonIndex >= 0 && buttonIndex < buttons.Count) && skillSystem.SkilList[buttonIndex - 1].isAvailable == true && skils[buttonIndex - 1].work == true)
        {
            StartCoroutine(Timer(buttonIndex));
            Debug.Log(buttonIndex);
        }
    }
    IEnumerator Timer(int buttonIndex)
    {
        skils[buttonIndex - 1].Skill();
        skils[buttonIndex - 1].isActive = false;
        skillSystem.SkilList[buttonIndex - 1].isAvailable = false;
        Debug.Log(skils[buttonIndex - 1].isActive);
        yield return new WaitForSeconds(skils[buttonIndex - 1].workingTime);
        skils[buttonIndex - 1].Skill();
        skils[buttonIndex - 1].isActive = true;
        skillSystem.SkilList[buttonIndex - 1].isAvailable = true;
        skils[buttonIndex - 1].work = false; 
        Debug.Log(skils[buttonIndex - 1].isActive);

        yield return new WaitForSeconds(skils[buttonIndex - 1].coolDownTime);

        skils[buttonIndex - 1].work = true;
    }

   
}
