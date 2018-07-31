using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private static bool igralec_obstaja; //static da samo en obstaja
    private Animator anim;
    public float attackTime;
    private float attackTimeCounter;
    public Vector2 lastMove;
    public float moveSpeed;
    private float currentMoveSpeed;
    public float diagonalMove;


    private bool playerMoving, attacking;
    private Rigidbody2D rigidbody;
    public string startPoint;
    // Use this for initialization
    private void Start()
    {
        anim = GetComponent<Animator>();
        rigidbody = GetComponent<Rigidbody2D>();
        if (!igralec_obstaja) //preveri če obstaja igralec
        {
            igralec_obstaja = true;
            DontDestroyOnLoad(transform.gameObject); //ne unici trenutnega game object-a, tega ki je na script attachan
        }
        else
        {
            Destroy(gameObject);
        }
    }

    // Update is called once per frame
    private void Update()
    {
        playerMoving = false;
        if (attacking == false)
        {
            if (Input.GetAxisRaw("Horizontal") > 0.5f || Input.GetAxisRaw("Horizontal") < -0.5f)
            {
                // transform.Translate(new Vector3(Input.GetAxisRaw("Horizontal")*moveSpeed*Time.deltaTime, 0f, 0f));
                rigidbody.velocity = new Vector2(Input.GetAxisRaw("Horizontal") * currentMoveSpeed, rigidbody.velocity.y);
                playerMoving = true;
                lastMove = new Vector2(Input.GetAxisRaw("Horizontal"), 0f);
            }
            if (Input.GetAxisRaw("Vertical") > 0.5f || Input.GetAxisRaw("Vertical") < -0.5f)
            {
                //transform.Translate(new Vector3(0f, Input.GetAxisRaw("Vertical") * moveSpeed * Time.deltaTime, 0f));
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, Input.GetAxisRaw("Vertical") * currentMoveSpeed);
                playerMoving = true;
                lastMove = new Vector2(0f, Input.GetAxisRaw("Vertical"));
            }

            if (Input.GetAxisRaw("Horizontal") < 0.5 && Input.GetAxisRaw("Horizontal") > -0.5)
                rigidbody.velocity = new Vector2(0f, rigidbody.velocity.y);

            if (Input.GetAxisRaw("Vertical") < 0.5 && Input.GetAxisRaw("Vertical") > -0.5)
                rigidbody.velocity = new Vector2(rigidbody.velocity.x, 0);
            if (Input.GetKeyDown(KeyCode.J))
            {
                attackTimeCounter = attackTime;
                attacking = true;
                rigidbody.velocity = Vector2.zero;
                anim.SetBool("IsAttacking", true);
            }
            if (Input.GetAxisRaw("Horizontal") != 0 && Input.GetAxisRaw("Vertical") != 0)
            {
                currentMoveSpeed = moveSpeed * diagonalMove;

            }
            else
            {
                currentMoveSpeed = moveSpeed;

            }
    }

        if (attackTimeCounter > 0)
            attackTimeCounter -= Time.deltaTime;
        if (attackTimeCounter <= 0)
        {
            attacking = false;
            anim.SetBool("IsAttacking", false);
        }
        anim.SetFloat("MoveX", Input.GetAxisRaw("Horizontal"));
        anim.SetFloat("MoveY", Input.GetAxisRaw("Vertical"));
        anim.SetBool("Move", playerMoving);
        anim.SetFloat("LastX", lastMove.x);
        anim.SetFloat("LastY", lastMove.y);
    }
}