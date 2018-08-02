using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class newMedPanelController : MonoBehaviour {
    public GameObject medicine;
    private GameObject canvas;
    private GameObject panel;

    private int medicineNo;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Medicines Content");
        panel = GameObject.Find("newMedPanel(Clone)");  
    }

    public void saveMedicine()
    {
        InputField[] inputs = panel.GetComponentsInChildren<InputField>();
        Medicine m = new Medicine();
        if (inputs[0].text == "" || inputs[1].text == "" || inputs[2].text == "" || inputs[3].text == "")
        {
            foreach (InputField i in inputs)
            {
                if (i.text == "")
                {
                    i.image.color = Color.red;
                } else
                {
                    i.image.color = Color.white;
                }
            }
            return;
        }
        m.medName = inputs[0].text;
        m.dosage = int.Parse(inputs[1].text);
        // parse medication entry
        m.timesPerDay = int.Parse(inputs[2].text);
        m.hours = int.Parse(inputs[2].text);
        m.notes = inputs[3].text;
        
        // make new medicine panel
        GameObject newMedicine = Instantiate(medicine) as GameObject;
        Text[] texts = newMedicine.GetComponentsInChildren<Text>();
        // set text on panels
        texts[0].text = m.medName;
        texts[1].text = m.dosage + "mg";
        string t = " times per day";
        if (m.timesPerDay == 1)
        {
            t = " time per day";
        }
        texts[2].text = m.timesPerDay + "" + t;
        texts[3].text = m.notes;
        newMedicine.transform.SetParent(canvas.transform, false);

        // set location
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(PlayerPrefs.GetString("DrIgorVigorSave"));
        XmlNodeList medicineList = xmlDoc.GetElementsByTagName("Medicine");

        int counter = medicineList.Count;
        newMedicine.GetComponent<RectTransform>().anchoredPosition = new Vector3(0, (-150) * (2 * (counter) + 1), 0);


        // add medicine to save state
        SaveManager.Instance.AddMedicine(m);

        cancelButton();
    }


    // destroys panel object
    public void cancelButton() {
        Destroy(gameObject);
    }


}
