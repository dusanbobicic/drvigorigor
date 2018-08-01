using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class addMedicine : MonoBehaviour {
    public GameObject medicine;
    private GameObject canvas;


    // Use this for initialization
    void Start () {
        canvas = GameObject.Find("container");
    }

    public void newMedPanel() {
        GameObject newMedicine = Instantiate(medicine) as GameObject;
        newMedicine.transform.SetParent(canvas.transform, false);
    }
	
	// Update is called once per frame
	void Update () {
		
	}
}
