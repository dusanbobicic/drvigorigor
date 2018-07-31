using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.Networking;
//using Assets.Scripts;

public class ConnectToClient : MonoBehaviour {

	// Use this for initialization
	void Start () {

    }
	
    public void zrihtaj(int cas)
    {
        string[] argv;
        string username = "";
        argv = System.Environment.GetCommandLineArgs();
        if (argv.Length > 1)
        {
            username = argv[argv.Length-1];
            
        }
        /*
        else
            username = "urbanc";
        */
        string url = "http://steam.rs-labs.si/api/index.php";

        WWWForm formDate = new WWWForm();
        formDate.AddField("user", username);
        formDate.AddField("id", 2);
        formDate.AddField("time", cas);

        WWW www = new WWW(url, formDate);

        reqest(www);

    }

    // Update is called once per frame
    IEnumerator reqest (WWW www) {
   
     yield return www;
	}
   

    }
