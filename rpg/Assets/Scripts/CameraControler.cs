using UnityEngine;

public class CameraControler : MonoBehaviour
{
    private static bool kamera_obstaja;
    public GameObject followTarget;
    public float MoveSpeed;
    private Vector3 targetPos;

    // Use this for initialization
    private void Start()
    {
        //da ni duplikatov kamer
        if (!kamera_obstaja)
        {
            kamera_obstaja = true;
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
        targetPos = new Vector3(followTarget.transform.position.x, followTarget.transform.position.y,
            transform.position.z); //pozicija kamere
        transform.position = Vector3.Lerp(transform.position, targetPos, MoveSpeed * Time.deltaTime);
            //kje si, kje hočeš bit, koliko prostora ima kamera za premikat timedelta time za razlicne framerate
    }
}