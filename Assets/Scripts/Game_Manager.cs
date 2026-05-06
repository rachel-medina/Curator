using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game_Manager : MonoBehaviour
{
    public static Game_Manager Instance;
    [Header("Time System")]
    public int currentDay = 1;

    private const string DAY_KEY = "CURRENT_DAY";


    private void Awake()
    {
        if (Instance != null && Instance != this)
        {
            Destroy(gameObject);
            return;
        }

        Instance = this;
        DontDestroyOnLoad(gameObject);
        
        LoadDay();
    }

    public void NextDay()
    {
        currentDay++;
        Debug.Log(currentDay);
    // TODO: ADD OnNewDay()
    }


    private void SaveDay()
    {
        PlayerPrefs.SetInt(DAY_KEY, currentDay);
        PlayerPrefs.Save();
    }

    private void LoadDay()
    {
        currentDay = PlayerPrefs.GetInt(DAY_KEY, 1);
    }
    

}
