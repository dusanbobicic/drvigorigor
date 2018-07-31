using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    public int playerMaxHealth, playerCurrentHealth;
    private bool flashActive;
    public float flashing;
    private float flashCounter;
    private SpriteRenderer playeRenderer;
    public float timeAlive = 0;
    public int zaPoslat;


    // Use this for initialization
    private void Start()
    {
        playerCurrentHealth = playerMaxHealth;
        playeRenderer = GetComponent<SpriteRenderer>();
    }


    // Update is called once per frame
    private void Update()
    {

        timeAlive += Time.deltaTime;

        if (playerCurrentHealth <= 0)
        {
            ConnectToClient a = new ConnectToClient();
            try
            {
                zaPoslat = (int)timeAlive;
                a.zrihtaj(zaPoslat);

            }
            catch
            {

            }
            gameObject.SetActive(false);
        }
        if (flashActive == true)
        {
            if (flashCounter > flashing * 0.66f)
            {
                playeRenderer.color = new Color(playeRenderer.color.r, playeRenderer.color.g, playeRenderer.color.b, 0);
                }
            else if (flashCounter > flashing * 0.33f)
                {
                playeRenderer.color = new Color(playeRenderer.color.r, playeRenderer.color.g, playeRenderer.color.b, 1);
                }
            else if (flashCounter >  0)
            {
                playeRenderer.color = new Color(playeRenderer.color.r, playeRenderer.color.g, playeRenderer.color.b, 0);
            }

            else  
            {
                playeRenderer.color = new Color(playeRenderer.color.r, playeRenderer.color.g, playeRenderer.color.b, 1f);
                flashActive = false;


            }
            flashCounter -= Time.deltaTime;


            if (flashing < 0)
            {
                flashActive = false;
                playeRenderer.color = new Color(playeRenderer.color.r, playeRenderer.color.g, playeRenderer.color.b, 1f);

            } 
        }

    }

    public void HurtPlayer(int dmgTaken)
    {
        playerCurrentHealth -= dmgTaken;
        flashActive = true;
        flashCounter = flashing;
    }

    public void setMaxHealth()
    {
        playerCurrentHealth = playerMaxHealth;
    }
}