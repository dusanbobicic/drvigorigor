using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class DialogManager : MonoBehaviour {
    public GameObject dBox;
    public Text dTex;
    public bool dActive;

    public string[] dLine = null;
    public int KeriLine;
	// Use this for initialization
	void Start () {
        dBox.SetActive(false);
        dActive = false;
    }

    // Update is called once per frame
    void Update() {
        if (dActive && Input.GetKeyDown(KeyCode.Space))
        {
            /*  dBox.SetActive(false);
              dActive = false;
              */
            KeriLine++;




        }
        if (KeriLine >= dLine.Length)
        {
            dBox.SetActive(false);
            dActive = false;

            KeriLine = 0;

        }

        if (dActive)
        {
            dTex.text = dLine[KeriLine];
        }
    }
    public void ShowBox(string dialog)
    {

        dActive = true;
        dBox.SetActive(true);
        dTex.text = dialog;
    }

    public void showDialog()
    {
        dActive = true;
        dBox.SetActive(true);


    }
}
