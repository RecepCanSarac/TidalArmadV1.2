
using UnityEngine;

public class SaveLoadTower : MonoBehaviour
{
    #region Singleton
    public static SaveLoadTower instance;
    private void Awake() => instance = this;
    #endregion

    public bool saveOn = true;

    public readonly string TowerSaveFile = "Tower";

    public void Save(TowerSlotObject[] towerSlots)
    {
        if (!saveOn) return;

        TowerSlotSaveData saveData = new TowerSlotSaveData(towerSlots.Length);

        for (int i = 0; i < towerSlots.Length; i++)
        {
            if (towerSlots[i].TowerData is null) continue;

            int bulletIndex;
            int bulletCount;
            towerSlots[i].GetBulletData(out bulletIndex, out bulletCount);

            saveData.towerSaveDatas[i] = new TowerSaveData(towerSlots[i].BuildLevel, towerSlots[i].TowerLevel, bulletIndex, bulletCount);
        }

        TowerSaveIO.SaveFile(saveData, TowerSaveFile);
    }

    public TowerSlotSaveData Load()
    {
        if (!saveOn) return null;

        return TowerSaveIO.LoadFile(TowerSaveFile);
    }
}