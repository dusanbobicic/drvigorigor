using UnityEngine;

public class LoadNewArea : MonoBehaviour
{
    public string exitPoint;
    public string level_to_load;
    private PlayerController thePlayer;

    // Use this for initialization

    private void Start()
    {
        thePlayer = FindObjectOfType<PlayerController>();
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.name == "Player")
        {
            Application.LoadLevel(level_to_load);

            thePlayer.startPoint = exitPoint;
        }
    }
}