using System.Collections;
using System.Collections.Generic;
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

    SOAgument agument;
    public void Setup(SOAgument _agument)
    {
     
        agumentImage.sprite = _agument.agumentImage;
        agumentName.text = _agument.agumentName;
        agumentDescription.text = _agument.agumentDescreption;
        //this.gameObject.AddComponent<Button>().onClick.AddListener(delegate { OnclickAgument(_agument.AgumentIndex); });
        aguments = _agument;
    }

    public void OnclickAgument(int agumentIndex)
    {
        Debug.Log("hebele");
        //Özellikleri burada çalýþtýrmalýyýz
        if (aguments is not null)
        {
            Instantiate(aguments.Agument);
            agumentUIManager.AgumentSystem.Aguments[agumentIndex].available = false;
        }

    }
}
