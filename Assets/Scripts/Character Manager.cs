using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterManager : MonoBehaviour {


    public static int gold;
    public static int health;
    public static int kills, deaths, assists;
    public static int CS;
    public static int level, exp;
    public static int autoAttack;
    public static int attackSpeed;
    //public static int Mana; Resources?
    //public static int Str; Char specific stats? armor?

    public int startHealth = 150;
    public int startGold = 500;
    public int startAA = 15;

    // Use this for initialization
    void Start () {

        health = startHealth;
        gold = startGold;
        kills = deaths = assists = CS = exp = 0;
        level = 1;
        autoAttack = startAA;
    }
	
	// Update is called once per frame
	void Update () {
        if (health == 0)
        {
            //Death
            //Respawn(); //Call method to respawn champ?
        }
		
	}
}
