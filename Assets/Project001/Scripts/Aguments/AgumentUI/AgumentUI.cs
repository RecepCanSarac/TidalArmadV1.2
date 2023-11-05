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

    SOAgument agument;
    public void Setup(SOAgument _agument)
    {
        agumentImage.sprite = _agument.agumentImage;
        agumentName.text = _agument.agumentName;
        agumentDescription.text = _agument.agumentDescreption;
        this.gameObject.AddComponent<Button>().onClick.AddListener(delegate { OnclickAgument(_agument.AgumentIndex); });
    }

    public int OnclickAgument(int index)
    { 
        //Özellikleri burada çalýþtýrmalýyýz


        return index;
    }
}
