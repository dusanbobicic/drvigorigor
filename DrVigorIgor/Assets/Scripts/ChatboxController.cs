using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class ChatboxController : MonoBehaviour {
    public GameObject chatbox;
    public List<string> dialog;
    public List<List<string>> dialog2;

    public string[,] di = new string[4, 2];
    private int randomN = 0;

    int turn = 0;
    Text chatText;
    // Use this for initialization
    void Start () {
        di[0,0] = "Sometimes Neal doesn't like his medicine.";
        di[0,1] = "He knows it's important to get better, though.";

        di[1,0] = "Diabetes is a disease that affects how the body uses glucose.";
        di[1,1] = "Your body needs glucose to keep running!";

        di[2, 0] = "It's very important to take your medicine just as the doctor suggests.";
        di[2, 1] = "Not taking medicine, or not taking it correctly, can make you feel terrible!";

        di[3, 0] = "The most common diabetes medicine is insulin.";
        di[3, 1] = "Without insulin around, blood sugar levels get too high.";

        randomN = Random.Range(0, 3);

        chatText = chatbox.transform.Find("Content").GetComponent<Text>();
        chatText.text = di[randomN, 0];
        turn++;
    }

    // Update is called once per frame
    void Update () {

		
	}

   public void activateChat()
    {

        if (turn < 2)
        {

            chatText.text = di[randomN, 1];
            turn++;
            
        }
        else{
            chatbox.SetActive(false);
        }
    }
}
