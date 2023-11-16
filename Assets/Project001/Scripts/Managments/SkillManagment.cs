using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManagment : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();
    [SerializeField] List<SOSkill> skils = new List<SOSkill>();
    GameObject skil;
    void Update()
    {
        for (int i = 1; i <= buttons.Count; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                PressButton(i);
            }
        }

        for (int i = 0; i < buttons.Count; i++)
        {
            if (buttons[i].GetComponent<SkillButton>().skill != null)
            {
                SOSkill skill = buttons[i].GetComponent<SkillButton>().skill;
                if (!skils.Contains(skill))
                {
                    skils.Add(skill);
                }
            }
        }
    }
    void PressButton(int buttonIndex)
    {
        if (buttonIndex >= 1 && buttonIndex <= buttons.Count)
        {
            AktiveSkill(buttonIndex);
            Debug.Log(buttonIndex);
        }
    }

    public void AktiveSkill(int buttonIndex)
    {
        string skilName = skils[buttonIndex].SkillName;
        GameObject skil = GameObject.FindGameObjectWithTag(nameof(skilName));
        if (skil != null)
        {
            ISelectedSkill skill = skil.GetComponent<ISelectedSkill>();
            if (skill != null)
            {
                skill.ActivitedSkill();
                Debug.Log("Çalýþýyor");
            }
        }

    }
}
