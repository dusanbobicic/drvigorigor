using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using CldMedAPI.Controler;
using CldMedAPI.Data;


public class RecivingApi : MonoBehaviour {
    public string healthId;
    private List<Perscription> perscriptions;
    // Use this for initialization
    void Start () {

            
    }

    
    public void displayStuff()
    {
        DbControl a = new DbControl("drvigor", "Drugbud123");

        //perscriptions = a.getPerscriptions(healthId);
        perscriptions = a.getPerscriptions(healthId);
        for (int i = 0; i < perscriptions.Count; i++)
        {


            Debug.Log(perscriptions[i].Interval);



        }

    }
    void Update () {
		
	}
}
