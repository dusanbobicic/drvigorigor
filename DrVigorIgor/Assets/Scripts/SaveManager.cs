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
        } 
    }

    public void ClearMedList()
    {
        state.medicines = new List<Medicine>();
        Save();
    }

    public void AddMedicine(Medicine med) {
        state.medicines.Add(med);
        Save();
    }

    public void changeName(string name)
    {
        if (name == null)
        {
            return;
        }
        state.player = name;
        Save();
    }

    public void newSave()
    {
        state = new SaveState();
        PlayerPrefs.DeleteAll();
        Save();
    }
}
