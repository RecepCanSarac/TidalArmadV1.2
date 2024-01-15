using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class AgumentUIManager : MonoBehaviour
{
    public SOAgumentSystem AgumentSystem;
    public AgumentUI[] agumentUI;
    public GameObject[] panel;


    public Image[] closeImage;

    public float recommendedPrice;

    private void Start()
    {
        SetRandomAgument();
        recommendedPrice = PlayerPrefs.GetFloat("recommendedPrice", 500000);
    }

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            Tenure();
        }
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

    private void Tenure()
    {
        if (EconomyManager.instance.Gold >= recommendedPrice)
        {
            EconomyManager.instance.DecreaseGold(recommendedPrice);
            recommendedPrice += recommendedPrice;

            PlayerPrefs.SetFloat("recommendedPrice", recommendedPrice);

            SetRandomAgument();
            for (int i = 0;i < closeImage.Length; i++)
            {
                closeImage[i].gameObject.SetActive(false);
                panel[i].GetComponent<Button>().interactable = true;
            }

        }
        else
        {
            for (int i = 0; i < closeImage.Length; i++)
            {
                closeImage[i].gameObject.SetActive(true);
                panel[i].GetComponent<Button>().interactable = false;
            }
        }
    }

}
