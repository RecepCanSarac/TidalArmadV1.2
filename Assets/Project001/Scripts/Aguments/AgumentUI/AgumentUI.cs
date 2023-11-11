using UnityEngine.UI;
using TMPro;
using UnityEngine;

public class AgumentUI : MonoBehaviour
{
    public Image agumentImage;
    public TextMeshProUGUI agumentName;
    public TextMeshProUGUI agumentDescription;
    public AgumentUIManager agumentUIManager;
    public SOAgument aguments = null;

    private void Awake()
    {
        //this.gameObject.AddComponent<Button>();
    }
    public void Setup(SOAgument _agument)
    {
        agumentImage.sprite = _agument.agumentImage;
        agumentName.text = _agument.agumentName;
        agumentDescription.text = _agument.agumentDescreption;
        aguments = _agument;
        //gameObject.GetComponent<Button>().onClick.AddListener(delegate { OnclickAgument(); });
        Debug.Log("Say�");
    }

    public void OnclickAgument()
    {
        if (aguments is not null)
        {
            Debug.Log("Allah");
            Instantiate(aguments.Agument);
            string agumentTag = aguments.AgumentTag;
            GameObject taggedObject = GameObject.FindGameObjectWithTag(agumentTag);

            if (taggedObject != null)
            {
                IClickable clickable = taggedObject.GetComponent<IClickable>();

                if (clickable != null)
                {
                    clickable.Click();
                    
                    agumentUIManager.AgumentSystem.Aguments[aguments.AgumentIndex].available = false;
                }
                else
                {
                    Debug.LogError("IClickable bile�eni bulunamad�.");
                }
            }
            else
            {
                Debug.LogError("Etiketle e�le�en oyun nesnesi bulunamad�.");
            }
        }

    }
}
