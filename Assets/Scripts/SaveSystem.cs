using System.IO;
using UnityEngine;

public class SaveSystem
{
    private static string path => "/Users/stanislavhlukhanych/Univer/курс3/Unity/lab1-ex2/save.json";

    public static void Save(GameData data)
    {
        string json = JsonUtility.ToJson(data, true);
        File.WriteAllText(path, json);
    }

    public static GameData Load()
    {
        if (!File.Exists(path)) return new GameData();
        string json = File.ReadAllText(path);
        return JsonUtility.FromJson<GameData>(json);
    }
}
