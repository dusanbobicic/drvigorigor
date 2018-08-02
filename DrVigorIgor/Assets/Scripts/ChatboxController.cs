using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChatboxController : MonoBehaviour {
    public GameObject chatbox;
    public List<string> dialog;
    int turn = 0;
    Text chatText;
    // Use this for initialization
    void Start () {
        chatText = chatbox.transform.Find("Content").GetComponent<Text>();
        chatText.text = dialog[turn];
        turn++;
        
    }

    // Update is called once per frame
    void Update () {

		
	}

   public void activateChat()
    {

        if (turn < dialog.Count )
        {

            chatText.text = dialog[turn];
            turn++;
            
        }
        else{
            chatbox.SetActive(false);
        }
    }
}
