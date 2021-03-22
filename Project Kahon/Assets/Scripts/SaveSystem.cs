using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SaveScore(LevelManager levelManager)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/leastattempts.weez";
        FileStream stream = new FileStream(path, FileMode.Create);

        LevelData data = new LevelData(levelManager);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static LevelData LoadScore()
    {
        string path = Application.persistentDataPath + "/leastattempts.weez";
        if (File.Exists(path))
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            LevelData data = (LevelData)formatter.Deserialize(stream);
            stream.Close();

            return data;
        }

        else 
        {
            Debug.LogError ("File does not exist!: " + path);
            return null;
        }
    }
}
