using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameTime : MonoBehaviour
{
    public float playedTime;
    public Text minutesDisplay;
    public Text secondsDisplay;

    // Use this for initialization
    void Start()
    {
        playedTime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        playedTime += Time.deltaTime;

        int minutes = Mathf.FloorToInt(playedTime / 60F);
        int seconds = Mathf.FloorToInt(playedTime - minutes * 60);
        secondsDisplay.text = Mathf.RoundToInt(seconds).ToString();
        minutesDisplay.text = Mathf.RoundToInt(minutes).ToString();
    }
}


