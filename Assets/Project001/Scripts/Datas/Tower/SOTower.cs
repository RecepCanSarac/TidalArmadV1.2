using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower", menuName = "Data/Tower")]
public class SOTower : ScriptableObject
{
    [Header("Base")]
    public string towerId;
    public string towerName;
    public string towerDescription;

    public float buildPrice;

    public List<SOTowerLevel> upgradeList = new List<SOTowerLevel>();

    public bool isBuildable()
    {
        if (EconomyManager.instance.Gold >= buildPrice)
        {
            return true;
        }
        return false;
    }

    public void Build()
    {
        EconomyManager.instance.DecreaseGold(buildPrice);
    }

    #region UpgradeTower
    public bool IsUpgradable(int index)
    {
        if (EconomyManager.instance.Gold >= upgradeList[index].upgradePrice)
        {
            return true;
        }
        return false;
    }

    public void Upgrade(int index)
    {
        EconomyManager.instance.DecreaseGold(upgradeList[index].upgradePrice);
    }
    #endregion
}