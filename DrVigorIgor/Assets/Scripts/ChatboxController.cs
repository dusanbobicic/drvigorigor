using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System.Xml;
using UnityEngine.UI;


public class ChatboxController : MonoBehaviour {
    public GameObject chatbox;
    public List<string> dialog;
    public List<List<string>> dialog2;

    public string[,] di = new string[4, 2];
    public string[] tutorialLog = new string[10];
    private int randomN = 0;
    private bool tutorial;
    private int turnsNo = 0;

    private int turn = 0;
    Text chatText;
    // Use this for initialization
    void Start () {
        di[0,0] = "Sometimes Neal doesn't like his medicine.";
        di[0,1] = "He knows it's important to take it to get better, though.";

        di[1,0] = "Almost ten percent of all people on the world have diabetes.";
        di[1,1] = "That's one for every ten people you meet!";

        di[2, 0] = "It's very important to take your medicine just as the doctor suggests.";
        di[2, 1] = "Not taking medicine, or not taking it correctly, can make you feel terrible!";

        di[3, 0] = "The most common diabetes medicine is insulin.";
        di[3, 1] = "Without insulin around, blood sugar levels get too high!";

        tutorialLog[0] = "Hi, Karolina!";
        tutorialLog[1] = "I see this is your first day with Neal.";
        tutorialLog[2] = "This is Neal. He is sick, and needs medication daily.";
        tutorialLog[3] = "What? You're sick too?";
        tutorialLog[4] = "Then you can take your medicine together with Neal!";
        tutorialLog[5] = "Don't worry.";
        tutorialLog[6] = "Neal and I will remind you when it's time to take your medication.";
        tutorialLog[7] = "And to be sure it's the right one, you must take a picture of the box.";
        tutorialLog[8] = "I'll let you know if anything goes wrong.";
        tutorialLog[9] = "Take good care of Neal!";

        randomN = Random.Range(0, 3);

        chatText = chatbox.transform.Find("Content").GetComponent<Text>();
        tutorial = !PlayerPrefs.HasKey("Tutorial") || PlayerPrefs.GetInt("Tutorial") == 1 ? true : false;

        if (tutorial)
        {
            turnsNo = 10;
            chatText.text = tutorialLog[0];
            turn++;
        } else
        {
            turnsNo = 2;
            chatText.text = di[randomN, 0];
        }
        
        turn++;
    }

    // Update is called once per frame
    void Update () {

		
	}

   public void activateChat()
    {

        if (turn < turnsNo)
        {
            if (tutorial)
            {
                chatText.text = tutorialLog[turn];
            }
            else
            {
                chatText.text = di[randomN, 1];
            }

            turn++;
        }
        else
        {
            chatbox.SetActive(false);
            if (tutorial)
            {
                PlayerPrefs.SetInt("Tutorial", 0);
            }
        }
    }
}
