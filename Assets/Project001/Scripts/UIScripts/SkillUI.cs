using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillUI : MonoBehaviour
{
    public GameObject[] buttons;
    public Image[] images;

    public SOSkillSystem skillSystem;

    private void Update()
    {
        SkillSetup();
    }
    private void SkillSetup()
    {
       
        for (int j = 0; j < images.Length; j++)
        {
            for (int i = 0; i < skillSystem.SkilList.Count; i++)
            {
                if (skillSystem.SkilList[i].isAvailable)
                {
                    buttons[i].SetActive(true);
                }
                else
                {
                    buttons[i].SetActive(false);
                }
            }
         
        }
    }
}
