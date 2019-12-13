using UnityEngine;
using System.IO;
using System.Runtime.Serialization.Formatters.Binary;

public static class SaveSystem 
{

    public static void SavePlayer(int coins, int score) {
        BinaryFormatter formatter = new BinaryFormatter();
        string path = Application.persistentDataPath + "/player.runner";
        FileStream stream = new FileStream(path, FileMode.Create);

        PlayerData data = new PlayerData(score, coins);

        formatter.Serialize(stream, data);
        stream.Close();
    }

    public static PlayerData LoadPlayer() {
        string path = Application.persistentDataPath + "/player.runner";
        if(File.Exists(path)) {
            BinaryFormatter formatter = new BinaryFormatter();
            FileStream stream = new FileStream(path, FileMode.Open);
            PlayerData data = formatter.Deserialize(stream) as PlayerData;
            stream.Close();

            return data;

        } else {
            SavePlayer(0, 0);
            return LoadPlayer();
        }
    }
}
