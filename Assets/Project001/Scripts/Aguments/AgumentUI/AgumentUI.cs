using UnityEngine.UI;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

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

            for (int i = 0; i < agumentUIManager.AgumentSystem.Aguments.Count; i++)
            {
                if (agumentUIManager.AgumentSystem.Aguments[i].agument.agumentName == agument.agumentName)
                {
                    agumentUIManager.AgumentSystem.Aguments[i].available = false;
                }
            }


            for (int i = 0; i < agumentUIManager.closeImage.Length; i++)
            {
                agumentUIManager.closeImage[i].gameObject.SetActive(true);
                agumentUIManager.panel[i].GetComponent<Button>().interactable = false;
            }
            if (!SceneManager.GetActiveScene().name.Equals("StoreScene"))
            {
                SceneManager.LoadScene("MapGenerator");
                for (int i = 0; i < agumentUIManager.closeImage.Length; i++)
                {
                    agumentUIManager.closeImage[i].gameObject.SetActive(false);
                    agumentUIManager.panel[i].GetComponent<Button>().interactable = true;
                }
            }
        }
    }
}
