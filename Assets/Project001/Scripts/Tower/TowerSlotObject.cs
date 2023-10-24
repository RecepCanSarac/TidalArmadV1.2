using System;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;
using UnityEngine.SceneManagement;

public class TowerSlotObject : MonoBehaviour, IPointerClickHandler
{
    private SpriteRenderer sp;
    private Collider2D col;

    public List<SOTower> buildableTowerList = new List<SOTower>();

    public int BuildLevel { get; private set; } = 0;
    public int TowerLevel { get; private set; } = 0;
    public SOTower TowerData => currentTowerData;
    private SOTower currentTowerData;
    private TowerObject currentTower;

    
    public event Action<TowerSlotObject> OnLeftClickEvent;

    private void Start()
    {
        sp = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
    private void Update()
    {
        sp = GetComponent<SpriteRenderer>();
        col = GetComponent<Collider2D>();
    }
    public void OnPointerClick(PointerEventData eventData) //Objenin Click Handler Fonksiyonu
    {
        if (eventData.button == PointerEventData.InputButton.Left)
        {
            if (SceneManager.GetActiveScene().name == "StoreScene")
            {
                OnLeftClickEvent?.Invoke(this);
            }
        }
    }

    //Yeni Kule eklendiginde 
    public void AddTower(int index)
    {
        if (!isBuildable(index))
        {
            return;
        }

        BuildLevel = index;
        currentTowerData = buildableTowerList[index];
        currentTower = Instantiate(buildableTowerList[index].upgradeList[TowerLevel].towerPrefab, transform).GetComponent<TowerObject>();
        currentTowerData.Build();
        currentTower.TowerData = buildableTowerList[index].upgradeList[TowerLevel];
        BuyBullet(BulletManager.instance.GetBulletData(0), 0);
        SetupTowerEvent(currentTower);
        DisableSlot();
    }

    //Kule gelistiginde
    public void UpgradeTower(int index)
    {
        if (!IsUpgradable())
        {
            return;
        }

        int bulletIndex = 0;
        int bulletCount = 0;

        if (currentTower is not null)
        {
            bulletIndex = currentTower.GetBulletIndex();
            bulletCount = currentTower.GetBulletCount();

            Destroy(currentTower.gameObject);
        }


        TowerLevel = index;
        currentTower = Instantiate(currentTowerData.upgradeList[TowerLevel].towerPrefab, transform).GetComponent<TowerObject>();
        currentTower.TowerData = currentTowerData.upgradeList[TowerLevel];
        currentTowerData.Upgrade(TowerLevel);
        SetupTowerEvent(currentTower);

        currentTower.OnChangeTower(BulletManager.instance.GetBulletData(bulletIndex), bulletIndex, bulletCount);
    }

    //Load calistiginda
    public void LoadTower(int buildLevel, int towerLevel, int bulletIndex, int bulletCount)
    {
        BuildLevel = buildLevel;
        TowerLevel = towerLevel;

        currentTowerData = buildableTowerList[buildLevel];
        currentTower = Instantiate(buildableTowerList[buildLevel].upgradeList[TowerLevel].towerPrefab, transform).GetComponent<TowerObject>();
        currentTower.TowerData = buildableTowerList[buildLevel].upgradeList[TowerLevel];
        currentTower.LoadBullet(BulletManager.instance.GetBulletData(bulletIndex), bulletIndex, bulletCount);
        SetupTowerEvent(currentTower);
        Invoke("DisableSlot", 0.02f);
    }

    public void GetBulletData(out int bulletIndex, out int bulletCount)
    {
        bulletIndex = currentTower.GetBulletIndex();
        bulletCount = currentTower.GetBulletCount();
    }

    //Kontroller
    public bool isBuildable(int index)
    {

        if (buildableTowerList[index].buildPrice <= EconomyManager.instance.Gold)
        {
            return true;
        }
        else
        {
            CanvasManager.instance.SetNotify("Not enought money!");
            return false;
        }
    }
    public bool IsUpgradable()
    {
        if (TowerUpgradeCompleted())
        {
            return false;
        }

        if (currentTowerData.IsUpgradable(TowerLevel + 1))
        {
            return true;
        }
        else
        {
            CanvasManager.instance.SetNotify("Not enought money!");
            return false;
        }
    }
    public bool TowerUpgradeCompleted()
    {
        if (currentTowerData is not null && TowerLevel >= currentTowerData.upgradeList.Count - 1)
            return true;

        return false;
    }

    public void BuyBullet(SOBullet data, int index)
    {
        currentTower.OnBuyBullet(data, index);
    }
    private void SetupTowerEvent(TowerObject tower)
    {
        tower.OnLeftClickEvent += TowerOnClick;
        tower.OnBulletIsEnd += TowerChangeBullet;
    }
    private void TowerOnClick(TowerObject tower)
    {
        CanvasManager.instance.TowerUpgraderUI.Setup(this);
    }

    private void TowerChangeBullet(TowerObject tower)
    {
        tower.ChangeBullet(BulletManager.instance.GetBulletData(0), 0, 0);
    }

    public void DisableSlot()
    {
        sp.enabled = false;
        col.enabled = false;
    }
}
