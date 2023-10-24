using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class FileReadWrite
{
    public static void WriteToBinaryFile<T>(string filePath, T objectToWirite)
    {
        using (Stream stream = File.Open(filePath, FileMode.Create))
        {
            BinaryFormatter bf = new BinaryFormatter();
            bf.Serialize(stream, objectToWirite);
            stream.Close();
        }
    }

    public static T ReadFromBinaryFile<T>(string filePath)
    {
        using (Stream stream = File.Open(filePath, FileMode.Open))
        {
            BinaryFormatter bf = new BinaryFormatter();
            return (T)bf.Deserialize(stream);
        }
    }

    public static bool ExistsFile(string filePath)
    {
        return File.Exists(filePath);
    }

    public static void DeleteSaveFiles(string filePath)
    {
        Directory.Delete(filePath, true);
    }

    public static void CreateDirectory(string filePath)
    {
        Directory.CreateDirectory(filePath);
    }
    public static bool ExistsDirectory(string filePath)
    {
        return Directory.Exists(filePath);
    }


}