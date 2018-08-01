using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Medicine : MonoBehaviour {
    public string name = "Unnamed medicine";
    public int dosage = 0;
    public int timesPerDay = 0;
    public string[] hours;
    public string notes = "No special notes.";

    private Text[] texts;


	// Use this for initialization
	void Start () {
        texts = gameObject.GetComponentsInChildren<Text>();
        // name dosage schedule
        texts[0].text = this.name;
        texts[1].text = this.dosage.ToString() + "mg";
        texts[2].text = this.notes;
    }
	
	// Update is called once per frame
	void Update () {
       
    }

    void initialiseMedicine(string name, int dosage, int timesPerDay, string[] hours, string notes) {
        this.name = name;
        this.dosage = dosage;
        this.timesPerDay = timesPerDay;
        this.hours = hours;
        this.notes = notes;
    }

    void updatetext() {

    }
}
