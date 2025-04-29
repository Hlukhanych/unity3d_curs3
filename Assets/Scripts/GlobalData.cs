using UnityEngine;
using System;
using System.Collections.Generic;

[Serializable]
public class GameData
{
    public int lives = 3;
    public int coinsCollected = 0;
    public int hits = 0;
    public float startTime;
    public List<string> recordTable = new();
}

public class GlobalData : MonoBehaviour
{
    public static GlobalData Instance { get; private set; }
    public GameData Data { get; private set; } = new();

    public event Action OnLose;

    private bool gameOverTriggered = false;

    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);

        Data = SaveSystem.Load();
        Data.startTime = Time.time;

        OnLose += () =>
        {
            Debug.Log("Гру програно!");
            SaveSystem.Save(Data);
        // #if UNITY_EDITOR
        //         UnityEditor.EditorApplication.isPlaying = false; // Зупиняє гру в редакторі
        // #else
        //         Application.Quit(); // Закриває гру в реальній збірці
        // #endif
        };
    }

    public void AddCoin() => Data.coinsCollected++;

    public void TakeDamage()
    {
        if (gameOverTriggered) return;

        Data.lives--;
        Data.hits++;

        if (Data.lives <= 0)
        {
            TriggerLose();
        }
    }

    public void TriggerLose()
    {
        if (gameOverTriggered) return;

        gameOverTriggered = true;
        OnLose?.Invoke();
    }

    public bool IsGameOver() => Data.lives <= 0 || gameOverTriggered;

    private void OnApplicationQuit()
    {
        SaveSystem.Save(Data);
    }
}
