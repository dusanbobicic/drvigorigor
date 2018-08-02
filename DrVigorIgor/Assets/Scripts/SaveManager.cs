using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveManager : MonoBehaviour {
    public static SaveManager Instance { set; get; }
    public SaveState state;

    private void Awake() {
        DontDestroyOnLoad(gameObject);
        Instance = this;
        //newSave();
        Load();
        
    }

    public void Save() {
        PlayerPrefs.SetString("DrIgorVigorSave", Helper.Serialize<SaveState>(state));
        Debug.Log(Helper.Serialize<SaveState>(state));
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
    public void AddMedicine(Medicine med) {
        state.medicines.Add(med);
        Save();
    }

    public void newSave()
    {
        state = new SaveState();
        Save();
        Debug.Log("Creating new save.");
    }
}
