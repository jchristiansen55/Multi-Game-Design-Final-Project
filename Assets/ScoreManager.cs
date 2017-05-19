using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
    public static int redCS;
    public static int redValue;
    public static int blueCS;
    public static int blueValue;

    public Text redCSDisplay;
    public Text redValueDisplay;
    public Text blueCSDisplay;
    public Text blueValueDisplay;
	// Use this for initialization
	void Start () {
        redCS = 0;
        redValue = 0;
        blueCS = 0;
        blueValue = 0;

	}
	
	// Update is called once per frame
	void Update () {
        redCSDisplay.text = (redCS).ToString();
        redValueDisplay.text = (redValue).ToString();
        blueCSDisplay.text = (blueCS).ToString();
        blueValueDisplay.text = (blueValue).ToString();

    }
}
