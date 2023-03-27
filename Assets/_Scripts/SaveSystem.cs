using UnityEngine;

public class SaveSystem : MonoBehaviour
{
    PlayerData playerData;

    private void Awake()
    {
        playerData = LoadGameData();
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
        System.IO.File.WriteAllText(Application.persistentDataPath + "/PlayerData.json", data);
    }

    public PlayerData LoadGameData()
    {
        string path = Application.persistentDataPath + "/PlayerData.json";

        if (!System.IO.File.Exists(path))
        {
            Save(new PlayerData());
        }

        string savedData = System.IO.File.ReadAllText(Application.persistentDataPath + "/PlayerData.json");
        PlayerData data = JsonUtility.FromJson<PlayerData>(savedData);

        return data;
    }
}
