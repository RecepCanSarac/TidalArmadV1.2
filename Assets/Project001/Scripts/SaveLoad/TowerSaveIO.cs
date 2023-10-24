using UnityEngine;

public static class TowerSaveIO
{
    public static string savePath;
    public static string saveDir;

    static TowerSaveIO()
    {
        savePath = Application.persistentDataPath + "/Saved";
    }

    public static void SaveFile(TowerSlotSaveData data, string fileName)
    {
        if (!FileReadWrite.ExistsDirectory(savePath))
        {
            FileReadWrite.CreateDirectory(savePath);
        }

        saveDir = savePath + "/" + fileName + ".dat";

        FileReadWrite.WriteToBinaryFile(saveDir, data);
    }

    public static TowerSlotSaveData LoadFile(string fileName)
    {
        string file = savePath + "/" + fileName + ".dat";

        if (System.IO.File.Exists(file))
        {
            return FileReadWrite.ReadFromBinaryFile<TowerSlotSaveData>(file);
        }
        return null;
    }
}