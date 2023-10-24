using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class ShipManagement : MonoBehaviour
{
    private CanvasManager canvasManager;

    public TowerSlotObject[] towerSlots;

    private TowerSlotObject currentSlot;

    private GameObject button;
    private void Start()
    {
        if (SceneManager.GetActiveScene().name == "StoreScene")
        {
            button = GameObject.FindGameObjectWithTag("UpgradeButton");
            button.GetComponent<Button>().onClick.AddListener(ShipSave);
        }
        canvasManager = CanvasManager.instance;
       
        for (int i = 0; i < towerSlots.Length; i++)
        {
            towerSlots[i].OnLeftClickEvent += SlotSelect;
        }

        ShipLoad();
    }
    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            SaveLoadTower.instance.Save(towerSlots);
        }
    }
    private void OnDestroy()
    {
        SaveLoadTower.instance.Save(towerSlots);
    }

    public void ShipSave()
    {
        SaveLoadTower.instance.Save(towerSlots);
    }

    public void ShipLoad()
    {
        TowerSlotSaveData data = SaveLoadTower.instance.Load();

        if (data is not null)
        {
            for (int i = 0; i < data.towerSaveDatas.Length; i++)
            {
                if (data.towerSaveDatas[i] is not null)
                {
                    int buildLevel = data.towerSaveDatas[i].buildLevel;
                    int towerLevel = data.towerSaveDatas[i].towerLevel;

                    int bulletIndex = data.towerSaveDatas[i].towerBulletIndex;
                    int bulletCount = data.towerSaveDatas[i].towerBulletCount;

                    towerSlots[i].LoadTower(buildLevel, towerLevel, bulletIndex, bulletCount);
                }
            }
        }
    }

    private void SlotSelect(TowerSlotObject towerSlot)
    {
        currentSlot = towerSlot;
        ShowBuildUI(currentSlot);
    }

    private void ShowBuildUI(TowerSlotObject towerSlot)
    {
        canvasManager.TowerBuilderUI.ShowUI(towerSlot);
    }


}