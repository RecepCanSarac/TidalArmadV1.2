using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(fileName = "New Tower Upgrade", menuName = "Data/TowerUpgrade")]
public class SOTowerLevel : ScriptableObject
{
    public Sprite towerIcon;
    public float upgradePrice;

    [Header("Stats")]
    public float detectRange;
    public float attackSpeed;

    public GameObject towerPrefab;
}
