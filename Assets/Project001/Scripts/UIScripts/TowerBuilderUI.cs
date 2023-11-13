using System;
using System.Collections.Generic;
using System.Security.Policy;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuilderUI : MonoBehaviour
{
    [SerializeField] private GameObject[] buttonParents;
    private List<Button> buildButtons = new List<Button>();
    public List<towerBuilder> towers = new List<towerBuilder>();
    public GameObject panel;
    public GameObject closeBtn;
    private void Start()
    {
        for (int i = 0; i < buttonParents.Length; i++)
        {
            buildButtons.Add(buttonParents[i].AddComponent<Button>());
        }
    }

    public void ShowUI(TowerSlotObject towerSlot)
    {
        gameObject.transform.position = Camera.main.WorldToScreenPoint(new Vector2(0, 0));
        SetButton(towerSlot);
    }

    private void SetButton(TowerSlotObject towerSlot)
    {
        RemoveListeners();
        CloseButtons();
        closeBtn.SetActive(true);
        panel.GetComponent<Image>().enabled = true;
        for (int i = 0; i < towerSlot.buildableTowerList.Count; i++)
        {
            int index = i;
            buttonParents[index].SetActive(true);
            towers[index].sprite.gameObject.GetComponent<Image>().sprite = towerSlot.buildableTowerList[index].upgradeList[towerSlot.TowerLevel].towerIcon;
            towers[index].nameText.text = towerSlot.buildableTowerList[index].towerName;
            towers[index].descText.text = towerSlot.buildableTowerList[index].towerDescription;
            towers[index].GoldText.text = towerSlot.buildableTowerList[index].buildPrice.ToString() + " Krak";
            buildButtons[index].onClick.AddListener(delegate { towerSlot.AddTower(index); });
            buildButtons[index].onClick.AddListener(CloseButtons);
        }
    }
    public void CloseButtons()
    {
        panel.GetComponent<Image>().enabled = false;
        closeBtn.SetActive(false);
        foreach (var obj in buttonParents)
        {
            obj.SetActive(false);
        }
    }

    private void RemoveListeners()
    {
        foreach (var button in buildButtons)
        {
            button.onClick.RemoveAllListeners();
        }
    }
}
[Serializable]
public class towerBuilder
{
    public Button sprite;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI descText;
    public TextMeshProUGUI GoldText;
}
