using System;
using System.Collections;
using System.Collections.Generic;
using System.Reflection;
using UnityEngine;
using UnityEngine.UI;

public class UpgradePanelUI : MonoBehaviour
{
    [SerializeField] Transform content;
    [SerializeField] GameObject upgradeSlot;

    private Button upgradeButton;

    private void Start()
    {
        upgradeButton = upgradeSlot.GetComponentInChildren<Button>();
    }

    public void Show()
    {
        content.gameObject.SetActive(!content.gameObject.activeSelf);
    }
    public void Hide()
    {
        content.gameObject.SetActive(false);
        ResetPanel();
    }

    public void SetupPanel(TowerSlotObject towerSlot)
    {
        ResetPanel();

        int nextTowerIndex = towerSlot.TowerLevel + 1;

        upgradeSlot.SetActive(true);
        upgradeButton.GetComponent<Image>().sprite = towerSlot.TowerData.upgradeList[nextTowerIndex].towerIcon;
        upgradeButton.onClick.AddListener(delegate { towerSlot.UpgradeTower(nextTowerIndex); });
        upgradeButton.onClick.AddListener(delegate { Hide(); });
    }

    private void ResetPanel()
    {
        upgradeSlot.SetActive(false);
        upgradeButton.onClick.RemoveAllListeners();
    }
}