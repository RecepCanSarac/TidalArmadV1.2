using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AgumentUI : MonoBehaviour
{
    public Image agumentImage;
    public TextMeshProUGUI agumentName;
    public TextMeshProUGUI agumentDescription;
    public AgumentUIManager agumentUIManager;
    public SOAgument agument = null;


    public SOSkillSystem skillSystem;
    public void Setup(SOAgument _agument)
    {
        agumentImage.sprite = _agument.agumentImage;
        agumentName.text = _agument.agumentName;
        agumentDescription.text = _agument.agumentDescreption;
        agument = _agument;
    }
    public void OnclickAgument()
    {
        if (agument is not null)
        {
            agument.AugmenFunc();
        }
    }
}
