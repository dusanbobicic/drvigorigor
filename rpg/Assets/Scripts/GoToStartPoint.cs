using UnityEngine;

public class GoToStartPoint : MonoBehaviour
{
    private CameraControler camera;

    private PlayerController player;

    public string pointName;

    public Vector2 startDirection;

    // Use this for initialization
    private void Start()
    {
        player = FindObjectOfType<PlayerController>(); //najde ovjekt tipa playercontroller
        if (player.startPoint == pointName)
        {
            player.transform.position = transform.position; //playera da na startpoint
            player.lastMove = startDirection;

            camera = FindObjectOfType<CameraControler>();
            camera.transform.position = new Vector3(transform.position.x, transform.position.y,
                camera.transform.position.z);
        }
    }

    // Update is called once per frame
    private void Update()
    {
    }
}