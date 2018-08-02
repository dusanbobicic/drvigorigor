using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using System.Globalization;
using UnityEngine.UI;
public class HealthController : MonoBehaviour {

    public double bar;
   // public List<Medication> Medicine;
    private double oneTick;
    public Slider hp;
    public float howMuch;

    public void HealTheSeal()
    {

        hp.value += hp.value * howMuch;
        bar = hp.value;
    }
    public void UpdateBar()  
    {
        bar -= oneTick;
        
        hp.value = (float)bar;

        Debug.Log(bar);
        Debug.Log(oneTick);


    }
    // Use this for initialization
    void Start () {
         oneTick = 100.0/( 24.0 * 60.0 * 60.0);
        InvokeRepeating("UpdateBar", 0f, 1.0f);
       // hp = GameObject.Find("Health").GetComponent<Slider>();


    }

    // Update is called once per frame

}
