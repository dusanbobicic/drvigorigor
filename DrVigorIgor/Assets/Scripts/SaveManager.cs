using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        Load();

        Debug.Log(state);
    }
    public void Save() {
        PlayerPrefs.SetString("DrIgorVigorSave", Helper.Serialize<SaveState>(state));
    }
    public void Load() {
        if (PlayerPrefs.HasKey("DrIgorVigorSave")) {
            state = Helper.Deserialize<SaveState>(PlayerPrefs.GetString("DrIgorVigorSave"));
        }
        else {
            state = new SaveState();
            Save();
            Debug.Log("Creating new save.");
        } 
    }
}
