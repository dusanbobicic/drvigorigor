using UnityEngine;
using System.Collections;

public class DialogHolder : MonoBehaviour {
    public string dialoge;
    private DialogManager DMA;
    public string[] dLines;

	// Use this for initialization
	void Start () {

        DMA = FindObjectOfType<DialogManager>();

	}
	
	// Update is called once per frame
	void Update () {
	
}
    private void OnTriggerStay2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            if (Input.GetKeyUp(KeyCode.Space))
            {
                //DMA.ShowBox(dialoge);

                if (!DMA.dActive)
                {

                    DMA.dLine = dLines;
                    DMA.KeriLine = 0;
                    DMA.showDialog();


                }
                if (transform.parent.GetComponent<VillagerMovment>()!= null)
                {
                    transform.parent.GetComponent<VillagerMovment>().canMove = false;

                }


            }

        }

     }
}
