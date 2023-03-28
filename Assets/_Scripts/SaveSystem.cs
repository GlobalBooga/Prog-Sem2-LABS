using System;
using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    PlayerData playerData;
    string key = "1235153";
    bool encrypted = false;
    

    private void Start()
    {
        playerData = LoadGameData();
        if (playerData == null) playerData = new PlayerData();
        GameObject.Find("Player").transform.position = playerData.playerPosition;
        GameObject.Find("Player").transform.rotation = playerData.playerRotation;
    }

    private void OnApplicationQuit()
    {
        playerData.playerPosition = GameplayManager.GetPlayer().transform.position;
        playerData.playerRotation = GameplayManager.GetPlayer().transform.rotation;
        Save(playerData);
    }

    public void Save(PlayerData playerData)
    {
        string path = Application.persistentDataPath + "/PlayerData.json";

        string data = JsonUtility.ToJson(playerData);
        XORData(data);
        File.WriteAllText(path, data);
        encrypted = true;
    }

    public PlayerData LoadGameData()
    {
        string path = Application.persistentDataPath + "/PlayerData.json";

        if (!File.Exists(path))
        {
            encrypted = false;
            Save(new PlayerData());
        }
        
        string savedData = File.ReadAllText(path);

        if (encrypted)
        {
            savedData = XORData(savedData);
            encrypted = false;
        }

        PlayerData data = JsonUtility.FromJson<PlayerData>(savedData);

        File.WriteAllText(path, XORData(savedData));
        encrypted = true;

        return data;
    }

    string XORData(string data)
    {
        string result = "";
        for (int i = 0; i < data.Length; i++)
        {
            result += (char)(data[i] ^ key[i%key.Length]);
        }
        return result;
    }
}
