using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static int redCS;
    public static int redValue;
    public static int blueCS;
    public static int blueValue;
    public static int redTurretsLeft;
    public static int blueTurretsLeft;
    public static int redNexusHP;
    public static int blueNexusHP;

    public Text redCSDisplay;
    public Text redValueDisplay;
    public Text blueCSDisplay;
    public Text blueValueDisplay;

    public Text redTurretDisplay;
    public Text blueTurretDisplay;
    public Text redNexusDisplay;
    public Text blueNexusDisplay;

	// Use this for initialization
	void Start () {
        redCS = 0;
        redValue = 0;
        blueCS = 0;
        blueValue = 0;
        redTurretsLeft = 6;
        blueTurretsLeft = 6;
        redNexusHP = 100;
        blueNexusHP = 100;
        
    }
	
	// Update is called once per frame
	void Update () {
        redCSDisplay.text = (redCS).ToString();
        redValueDisplay.text = (redValue).ToString();
        blueCSDisplay.text = (blueCS).ToString();
        blueValueDisplay.text = (blueValue).ToString();

        redTurretDisplay.text = (redTurretsLeft).ToString();
        blueTurretDisplay.text = (blueTurretsLeft).ToString();
        redNexusDisplay.text = (redNexusHP).ToString();
        blueNexusDisplay.text = (blueNexusHP).ToString();

    }
}
