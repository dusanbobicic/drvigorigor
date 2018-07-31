using UnityEngine;

public class HurtPlayer : MonoBehaviour
{
    // Use this for initialization
    public int damageToGive;
    public GameObject DamageNumber;
    private Stats ps;
    public int currentDamage;
 



    private void Start()
    {
        ps = FindObjectOfType<Stats>();

    }

    // Update is called once per frame
    private void Update()
    {
    }


    private void OnCollisionEnter2D(Collision2D other) //ko se nek ostali objekt z 2d cillisionm dotakne se nekaj zgodi
    {
        if (other.gameObject.name == "Player")
        {
            currentDamage = damageToGive - ps.currentDef;
            if (currentDamage < 0) currentDamage = 0;
            other.gameObject.GetComponent<PlayerHealth>().HurtPlayer(currentDamage);
            var clone = (GameObject) Instantiate(DamageNumber, other.transform.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}