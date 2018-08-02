using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class IgorAnimation : MonoBehaviour {

    public int rate = 20;
    public int duration = 5;
    private int counter;
    private int durationEnd;

    public Image igor;
    private Sprite openEyes;
    private Sprite openMouth;
    private Sprite closedEyes;

	// Use this for initialization
	void Start () {
        counter = 0;
        durationEnd = rate+duration;

        openEyes = Resources.Load<Sprite>("igor/igor");
        openMouth = Resources.Load<Sprite>("igor/igor_mouth");
        closedEyes = Resources.Load<Sprite>("igor/igor_blink");
    }
	
	// Update is called once per frame
	void Update () {
        if (counter == rate)
        {
            // blinking
            igor.sprite = closedEyes;
        }
        else if (counter == durationEnd)
        {
            // open eyes
            igor.sprite = openEyes;
            counter = -1;
        }
        counter++;
	}
}
