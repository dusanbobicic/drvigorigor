using UnityEngine;
using UnityEngine.UI;

public class UIManager : MonoBehaviour
{
    private static bool UIExist;
    public Slider health;
    public PlayerHealth hp;
    public Text HPText;
    public Text LvlText;

    private Stats PS;
    // Use this for initialization
    private void Start()
    {
        if (UIExist == false) //preveri če obstaja igralec
        {
            UIExist = true;
            DontDestroyOnLoad(transform.gameObject); //ne unici trenutnega game object-a, tega ki je na script attachan
        }
        else
        {
            Destroy(gameObject);
        }
        PS = GetComponent<Stats>();


    }

    // Update is called once per frame
    private void Update()
    {
        health.maxValue = hp.playerMaxHealth;
        health.value = hp.playerCurrentHealth;
        HPText.text = hp.playerCurrentHealth + "/" + hp.playerMaxHealth;
        LvlText.text = "Lvl: " + PS.currentLvl;
    }
}