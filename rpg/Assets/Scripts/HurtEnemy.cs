using UnityEngine;

public class HurtEnemy : MonoBehaviour
{
    public GameObject DamageBurst;
    public GameObject DamageNumber;
    public int damageToGive;
    public int currentDamage;
    private Stats ps;
    public Transform HitPoint;
    // Use this for initialization
    private void Start()
    {
        ps = FindObjectOfType<Stats>();
        
    }

    // Update is called once per frame
    private void Update()
    {
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Hudobnez")
        {

            currentDamage = damageToGive + ps.currentAtt;
            other.gameObject.GetComponent<EnemyHealth>().HurtEnemy(currentDamage);
            Instantiate(DamageBurst, HitPoint.position, HitPoint.rotation);
            var clone = (GameObject) Instantiate(DamageNumber, HitPoint.position, Quaternion.Euler(Vector3.zero));
            clone.GetComponent<FloatingNumbers>().damageNumber = currentDamage;
        }
    }
}