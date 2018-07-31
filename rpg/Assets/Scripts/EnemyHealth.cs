using UnityEngine;

public class EnemyHealth : MonoBehaviour
{

    private Stats playerStats;
        
    public int MaxHealth, CurrentHealth,expToGive;


    // Use this for initialization
    private void Start()
    {
        CurrentHealth = MaxHealth;
        playerStats = FindObjectOfType<Stats>();
    }

    // Update is called once per frame
    private void Update()
    {
        if (CurrentHealth <= 0)
        {
            Destroy(gameObject);
            playerStats.AddExperience(expToGive);
        }
    }

    public void HurtEnemy(int dmgTaken)
    {
        CurrentHealth -= dmgTaken;
    }

    public void setMaxHealth()
    {
        CurrentHealth = MaxHealth;
    }
}