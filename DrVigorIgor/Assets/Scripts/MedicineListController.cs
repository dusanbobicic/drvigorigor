using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Xml;

public class MedicineListController : MonoBehaviour {
    public GameObject medicine;
    private GameObject canvas;
    public int counter = 0;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Medicines Content");

        // load save data
        XmlDocument xmlDoc = new XmlDocument();
        xmlDoc.LoadXml(PlayerPrefs.GetString("DrIgorVigorSave"));
        XmlNodeList medicineList = xmlDoc.GetElementsByTagName("Medicine");

        counter = 0;
        foreach (XmlNode m in medicineList)
        {
            XmlNodeList mContent = m.ChildNodes;
            GameObject newMedicine = Instantiate(medicine) as GameObject;
            Text[] texts = newMedicine.GetComponentsInChildren<Text>();
            // name | dosage | times per day | hours | notes
            foreach (XmlNode c in mContent)
            {
                switch (c.Name)
                {
                    case "medName":
                        texts[0].text = c.InnerText;
                        break;
                    case "dosage":
                        texts[1].text = c.InnerText + "mg";
                        break;
                    case "timesPerDay":
                        string t = " times per day";
                        if (int.Parse(c.InnerText) == 1)
                        {
                            t = " time per day";
                        }
                        texts[2].text = c.InnerText + "" + t;
                        break;
                    case "hours":
                        if (int.Parse(c.InnerText) == 0)
                        {
                            break;
                        }
                        string tmp = " hours";
                        if (int.Parse(c.InnerText) == 1)
                        {
                            tmp = " hour";
                        }
                        texts[2].text = "every " + c.InnerText + "" + tmp;
                        break;
                    case "notes":
                        texts[3].text = c.InnerText;
                        break;
                }
            }
            // bop it on
            newMedicine.transform.SetParent(canvas.transform, false);
            // fix positioning
            newMedicine.GetComponent<RectTransform>().anchoredPosition = new Vector3 (0, (-150) * (2 * (counter++) + 1), 0);
        }
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
