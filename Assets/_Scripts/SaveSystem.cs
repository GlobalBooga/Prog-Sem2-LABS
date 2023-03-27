using System.IO;
using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    PlayerData playerData;

    private void Awake()
    {
        playerData = LoadGameData();
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
        string data = JsonUtility.ToJson(playerData);
        //File.Decrypt(Application.persistentDataPath + "/PlayerData.json");
        File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", data);
        //File.Encrypt(Application.persistentDataPath + "/PlayerData.json");
    }

    public PlayerData LoadGameData()
    {
        string path = Application.persistentDataPath + "/PlayerData.json";

        if (!File.Exists(path))
        {
            Save(new PlayerData());
        }

        //File.Decrypt(Application.persistentDataPath + "/PlayerData.json");
        string savedData = File.ReadAllText(Application.persistentDataPath + "/PlayerData.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(savedData);
        //File.Decrypt(Application.persistentDataPath + "/PlayerData.json");

        return data;
    }
}
