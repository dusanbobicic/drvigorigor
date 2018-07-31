using UnityEngine;
using System.Collections;

public class VillagerMovment : MonoBehaviour {

    public float moveSpeed;

    private Rigidbody2D rig;

    public bool isWalking;

    public float walkTime;
    public float waitTime;

    private float walkTimeCounter;
    private float waitTimeCounter;

    private int walkDirection;

    public Collider2D theWalkZone;
    private Vector2 minWalkPoint;
    private Vector2 maxWalkPoint;
    public bool hasWalkZone;

    public bool canMove;

    private DialogManager DM;

    // Use this for initialization
    void Start () {
        DM = FindObjectOfType<DialogManager>();
        rig = GetComponent<Rigidbody2D>();
        walkTimeCounter = walkTime;
        waitTimeCounter = waitTime;
        ChooseDirection();
        if (theWalkZone != null)
        {
            minWalkPoint = theWalkZone.bounds.min;
            maxWalkPoint = theWalkZone.bounds.max;
            hasWalkZone = true;
        }
        canMove = true;
    }
	
	// Update is called once per frame
	void Update () {
        if(DM.dActive == false)
        {
            canMove = true;

        }
        if(canMove == false){
            rig.velocity = Vector2.zero;
            return;

        }
        if (isWalking)
        {
            walkTimeCounter -= Time.deltaTime;
            if(walkTimeCounter <=0)
            {
                isWalking = false;
                waitTimeCounter = waitTime;

            }
            switch (walkDirection)
            {
                case 0:
                    rig.velocity = new Vector2(0, moveSpeed);
                    if(hasWalkZone && transform.position.y > maxWalkPoint.y)
                    {
                        isWalking = false;
                        walkTimeCounter = walkTime;
                    }
                    break;
                case 1:
                    rig.velocity = new Vector2(moveSpeed,0);
                    if (hasWalkZone && transform.position.x > maxWalkPoint.x)
                    {
                        isWalking = false;
                        walkTimeCounter = walkTime;
                    }
                    break;
                case 2:
                    rig.velocity = new Vector2(0, -moveSpeed);
                    if (hasWalkZone && transform.position.y < minWalkPoint.y)
                    {
                        isWalking = false;
                        walkTimeCounter = walkTime;
                    }
                    break;
                case 3:
                    rig.velocity = new Vector2(-moveSpeed, 0);
                    if (hasWalkZone && transform.position.x < minWalkPoint.x)
                    {
                        isWalking = false;
                        walkTimeCounter = walkTime;
                    }
                    break;
            }

        }
        else
        {
            waitTimeCounter -= Time.deltaTime;
            rig.velocity = Vector2.zero;

            if (waitTimeCounter<=0)
            {
                ChooseDirection();
            }

        }
	
	}
    public void ChooseDirection()
    {
        walkDirection = Random.Range(0, 4);
        isWalking = true;
        walkTimeCounter = walkTime;
     

    }

}

