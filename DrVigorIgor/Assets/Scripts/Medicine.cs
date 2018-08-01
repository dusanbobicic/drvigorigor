using System.Xml;
using System.Xml.Serialization;

public class Medicine {
    public string medName = "Unnamed medicine";
    public int dosage = 0;
    public int timesPerDay = 0;
    public string[] hours;
    public string notes = "No special notes.";

    /*
    private Text[] texts;


	// Use this for initialization
	void Start () {
        texts = gameObject.GetComponentsInChildren<Text>();
        // name dosage schedule
        texts[0].text = this.medName;
        texts[1].text = this.dosage.ToString() + "mg";
        texts[2].text = this.notes;
    }

    void initialiseMedicine(string name, int dosage, int timesPerDay, string[] hours, string notes) {
        this.medName = name;
        this.dosage = dosage;
        this.timesPerDay = timesPerDay;
        this.hours = hours;
        this.notes = notes;
    }

    void updatetext() {

    }
    */
}
