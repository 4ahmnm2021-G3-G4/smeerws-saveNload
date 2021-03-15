using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveController
{
    public static void SavePlayerData(PlayerData data)
    {
        BinaryFormatter bf = new BinaryFormatter();
        
        string path = Application.persistentDataPath + "/playerData.binary";
        Debug.Log("path " + path);
        FileStream fs = new FileStream(path, FileMode.Create);
        
        bf.Serialize(fs, data);
        fs.Close();
    }

    public static PlayerData LoadPlayerData()
    {
        string path = Application.persistentDataPath + "/playerData.binary";
        
        if (File.Exists(path))
        {
            BinaryFormatter bf = new BinaryFormatter();
            FileStream fs = new FileStream(path, FileMode.Open);

            PlayerData data = bf.Deserialize(fs) as PlayerData;
            fs.Close();

            return data;
        }
        else
        {
            Debug.LogError("Save file not found in " + path);
            return null;
        }
    }
}
