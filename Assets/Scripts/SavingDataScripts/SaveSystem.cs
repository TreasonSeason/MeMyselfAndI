using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem
{
    public static void SavePlayer(healthbar bar, Inventory inv, CurrencyPouch money, StatDisplays stat)
    {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.hope";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(bar,inv, money, stat);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer()
    {
        string path = Application.persistentDataPath + "/player.hope";
        if(File.Exists(path) && new FileInfo(path).Length != 0)
        {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);

            PlayerData data = formatter.Deserialize(stream) as PlayerData;

            stream.Close();
            return data;
        }
        else
        {
            Debug.LogError("Cia error be ne error, viskas okey veikia reiskias   Save file not found in " + path);
            return null;
        }
    }
}
