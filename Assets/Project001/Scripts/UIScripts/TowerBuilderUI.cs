using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TowerBuilderUI : MonoBehaviour
{
    [SerializeField] private GameObject[] buttonParents;
    private List<Button> buildButtons = new List<Button>();
    public GameObject panel;

    private void Start()
    {
        for (int i = 0; i < buttonParents.Length; i++)
        {
            buildButtons.Add(buttonParents[i].GetComponentInChildren<Button>());
        }
    }

    public void ShowUI(TowerSlotObject towerSlot)
    {
        gameObject.transform.position = Camera.main.WorldToScreenPoint(new Vector2(0,0));
        SetButton(towerSlot);
    }

    private void SetButton(TowerSlotObject towerSlot)
    {
        RemoveListeners();
        CloseButtons();

        panel.GetComponent<Image>().enabled = true;
        for (int i = 0; i < towerSlot.buildableTowerList.Count; i++)
        {
            int index = i;
            
            buttonParents[index].SetActive(true);
            buildButtons[index].gameObject.GetComponent<Image>().sprite = towerSlot.buildableTowerList[index].upgradeList[towerSlot.TowerLevel].towerIcon;
            buildButtons[index].onClick.AddListener(delegate { towerSlot.AddTower(index); });
            buildButtons[index].onClick.AddListener(CloseButtons);
        }
    }
    private void CloseButtons()
    {
        panel.GetComponent<Image>().enabled = false;
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
