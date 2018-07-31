using UnityEngine;

public class SlimeController : MonoBehaviour
{
    public float moveSpeed;
    private bool moving;
    private bool realoding;
    private Rigidbody2D rigidbody;
    private Vector3 smerPremikanja;
    private GameObject thePlayer;
    public float timeBetweenMove, timeToMove, timeBetweenMoveCounter, timeToMoveCounter;
    public float waitToReload;
    

    // Use this for initialization
    private void Start()
    {
        rigidbody = GetComponent<Rigidbody2D>();
        // timeBetweenMoveCounter = timeBetweenMove;
        //timeToMoveCounter = timeToMove;
        timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.5f, timeBetweenMoveCounter * 1.5f);
        timeToMoveCounter = Random.Range(timeToMove * 0.5f, timeToMove * 1.5f);
    }

    // Update is called once per frame
    private void Update()
    {
        //ena spremenljivka steje cas ko mobi pavziraja in ena kak dolgo se premikajo
        if (moving)
        {
            timeToMoveCounter -= Time.deltaTime;
            rigidbody.velocity = smerPremikanja;


            if (timeToMoveCounter < 0)
            {
                moving = false;
                // timeBetweenMoveCounter = timeBetweenMove;
                timeBetweenMoveCounter = Random.Range(timeBetweenMove * 0.5f, timeBetweenMoveCounter * 1.5f);
            }
        }
        else
        {
            timeBetweenMoveCounter -= Time.deltaTime; //Time.deltaTime odsteje cas (en update screena)
            rigidbody.velocity = Vector2.zero;

            if (timeBetweenMoveCounter < 0)
            {
                moving = true;
                // timeToMoveCounter = timeToMove;
                timeToMoveCounter = Random.Range(timeToMove * 0.5f, timeToMove * 1.5f);
                smerPremikanja = new Vector3(Random.Range(-1f, 1f) * moveSpeed, Random.Range(-1f, 1f) * moveSpeed, 0);
            }
        }
        if (realoding)
        {
            waitToReload -= Time.deltaTime;
            if (waitToReload < 0)
            {
                Application.LoadLevel(Application.loadedLevel);
                thePlayer.SetActive(true);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other) //ko se nek ostali objekt z 2d cillisionm dotakne se nekaj zgodi
    {
        /*  if (other.gameObject.name == "Player")
          {
             // Destroy(other.gameObject);
             other.gameObject.SetActive(false); //ko umre deaktiviramo karakterja
              realoding = true;
              thePlayer = other.gameObject;
          }
          */
    }
}