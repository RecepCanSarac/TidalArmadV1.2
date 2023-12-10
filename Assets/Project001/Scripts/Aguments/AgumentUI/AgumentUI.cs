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
    public SOAgument aguments = null;


    public SOSkillSystem skillSystem;
    public void Setup(SOAgument _agument)
    {
        agumentImage.sprite = _agument.agumentImage;
        agumentName.text = _agument.agumentName;
        agumentDescription.text = _agument.agumentDescreption;
        aguments = _agument;
    }

    public void OnclickAgument()
    {
        if (aguments is not null)
        {
            Instantiate(aguments.Agument);
            string agumentTag = aguments.AgumentTag;
            GameObject taggedObject = GameObject.FindGameObjectWithTag(agumentTag);

            if (taggedObject != null)
            {
                IClickable clickable = taggedObject.GetComponent<IClickable>();

                if (clickable != null)
                {
                    clickable.Click();
                    agumentUIManager.SetRandomAgument();
                    agumentUIManager.AgumentSystem.Aguments[aguments.AgumentIndex].available = false;
                    
                    if (agumentUIManager.AgumentSystem.Aguments[aguments.AgumentIndex].agument.aktiveAgument == true)
                    {
                        skillSystem.SkilList[aguments.AgumentIndex].isAvailable = true;
                        Debug.Log(skillSystem.SkilList[aguments.AgumentIndex].isAvailable);
                    }

                    SceneManager.LoadScene("MapGenerator");
                }
                else
                {
                    Debug.LogError("IClickable bileþeni bulunamadý.");
                }
            }
            else
            {
                Debug.LogError("Etiketle eþleþen oyun nesnesi bulunamadý.");
            }
        }

    }
}
