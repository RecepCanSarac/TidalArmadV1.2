using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SkillManagment : MonoBehaviour
{
    [SerializeField] List<Button> buttons = new List<Button>();

    void Update()
    {
        for (int i = 1; i <= buttons.Count; i++)
        {
            if (Input.GetKeyDown(i.ToString()))
            {
                PressButton(i);
            }
        }
    }
    void PressButton(int buttonIndex)
    {
        if (buttonIndex >= 1 && buttonIndex <= buttons.Count)
        {
            buttons[buttonIndex - 1].GetComponent<UnityEngine.UI.Button>().onClick.Invoke();
            Debug.Log(buttonIndex);
        }
    }
}
