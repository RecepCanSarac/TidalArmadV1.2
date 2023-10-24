using System;

[Serializable]
public class TowerSaveData
{
    public int buildLevel;
    public int towerLevel;

    public int towerBulletIndex;
    public int towerBulletCount;

    public TowerSaveData(int buildLevel, int towerLevel, int towerBulletIndex, int towerBulletCount)
    {
        this.buildLevel = buildLevel;
        this.towerLevel = towerLevel;
        this.towerBulletIndex = towerBulletIndex;
        this.towerBulletCount = towerBulletCount;
    }
}

[Serializable]
public class TowerSlotSaveData
{
    public TowerSaveData[] towerSaveDatas;

    public TowerSlotSaveData(int count)
    {
        towerSaveDatas = new TowerSaveData[count];
    }
}