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
        for (int i = 1; i <= buttons.Count; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                int index = i;
                PressButton(index);
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
        if ((buttonIndex >= 0 && buttonIndex < buttons.Count) && skillSystem.SkilList[buttonIndex -1].isAvailable == true)
        {
            AktiveSkill(buttonIndex);
            Debug.Log(buttonIndex);
        }
        //else
        //{
        //    Debug.LogError("Geçersiz button indeksi: " + buttonIndex);
        //}
    }

    public void AktiveSkill(int buttonIndex)
    {
        Debug.Log("buttonIndex: " + buttonIndex);

        if (skils != null && buttonIndex > 0 && buttonIndex <= skils.Count)
        {
            string skilName = skils[buttonIndex -1].SkillName;
            Debug.Log("skilName: " + skilName);

            GameObject skil = GameObject.FindGameObjectWithTag(skilName);

            if (skil != null)
            {
                ISelectedSkill skill = skil.GetComponent<ISelectedSkill>();
                if (skill != null)
                {
                    skill.ActivitedSkill();
                    Debug.Log("Çalýþýyor");
                }
                else
                {
                    Debug.LogError("ISelectedSkill bileþeni bulunamadý.");
                }
            }
            else
            {
                Debug.LogError("Skil nesnesi null.");
            }
        }
        else
        {
            Debug.LogError("Geçersiz skill indeksi: " + buttonIndex);
        }
    }



}


