using UnityEngine;
using UnityEngine.UI;

public class FloatingNumbers : MonoBehaviour
{
    public int damageNumber;
    public Text displayNumber;
    public float moveSpeed;
    // Use this for initialization
    private void Start()
    {
    }

    // Update is called once per frame
    private void Update()
    {
        displayNumber.text = "" + damageNumber;
        transform.position = new Vector3(transform.position.x, transform.position.y + moveSpeed * Time.deltaTime,
            transform.position.z);
    }
}