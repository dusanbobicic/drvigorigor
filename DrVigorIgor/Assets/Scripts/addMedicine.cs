using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addMedicine : MonoBehaviour {
    public GameObject medicine;
    private GameObject canvas;

    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("Medicines Content");
    }

    public void newMedPanel() {
        Medicine info = new Medicine();
        // set medicine info here
        info.medName = "New Medicine";

        // make new medicine panel
        GameObject newMedicine = Instantiate(medicine) as GameObject;
        Text[] texts = newMedicine.GetComponentsInChildren<Text>();
        // set text on panels
        texts[0].text = info.medName;
        texts[1].text = "bla2";
        texts[2].text = "bla3";
        newMedicine.transform.SetParent(canvas.transform, false);

        // add medicine to save state
        SaveManager.Instance.AddMedicine(info);
    }
}
