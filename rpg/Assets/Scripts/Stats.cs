using UnityEngine;
using System.Collections;

public class Stats : MonoBehaviour {

	// Use this for initialization
    public int currentLvl;
    public int currentXp;

    public int[] toLvlUp;

    public int[] hpLvl;
    public int[] attLvl;
    public int[] defLvl;

    public int currentHP;
    public int currentAtt;
    public int currentDef;

    private PlayerHealth ph;


    void Start () {
        currentHP = hpLvl[1];
        currentAtt = attLvl[1];
        currentDef = defLvl[1];

        ph = FindObjectOfType<PlayerHealth>();

    }
	
	// Update is called once per frame
    void Update()
    {
        if (currentXp >= toLvlUp[currentLvl])
        {
            lvlUp();
        }

}

    public void AddExperience(int xpToAdd)
    {
        currentXp += xpToAdd;


    }

    public void lvlUp()
    {
        currentLvl++;


        currentHP = hpLvl[currentLvl];
        ph.playerMaxHealth = currentHP;
        ph.playerCurrentHealth += currentHP - hpLvl[currentLvl - 1];


        currentAtt = attLvl[currentLvl];
        currentDef = defLvl[currentLvl];





    }
}
