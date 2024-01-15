using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class AgumentUIManager : MonoBehaviour
{
    public SOAgumentSystem AgumentSystem;
    public AgumentUI[] agumentUI;
    public GameObject[] panel;


    public Image[] closeImage;

    public float recommendedPrice;

    public TextMeshProUGUI textMeshProUGUI;

    private void Start()
    {
        SetRandomAgument();
        recommendedPrice = PlayerPrefs.GetFloat("recommendedPrice", recommendedPrice);
    }


    public void SetRandomAgument()
    {
        if (AgumentSystem.Aguments.Count == 0)
        {
            Debug.LogWarning("Agument listesi boþ!");
            return;
        }

        List<int> availableIndices = new List<int>();
        for (int i = 0; i < AgumentSystem.Aguments.Count; i++)
        {
            if (AgumentSystem.Aguments[i].available)
            {
                availableIndices.Add(i);
            }
        }

        if (availableIndices.Count == 0)
        {
            Debug.LogWarning("Kullanýlabilir argüman bulunamadý!");
            return;
        }

        for (int i = 0; i < agumentUI.Length; i++)
        {
            int randomIndex = availableIndices[Random.Range(0, availableIndices.Count)];
            agumentUI[i].Setup(AgumentSystem.Aguments[randomIndex].agument);
            availableIndices.Remove(randomIndex);
        }
    }
    public void Tenure()
    {
        if (EconomyManager.instance.Gold >= recommendedPrice)
        {
            EconomyManager.instance.DecreaseGold(recommendedPrice);
            recommendedPrice += recommendedPrice;
            textMeshProUGUI.text = "Need your " + recommendedPrice; 
            PlayerPrefs.SetFloat("recommendedPrice", recommendedPrice);

            SetRandomAgument();
            for (int i = 0;i < closeImage.Length; i++)
            {
                closeImage[i].gameObject.SetActive(false);
                panel[i].GetComponent<Button>().interactable = true;
            }
        }
    }
}
