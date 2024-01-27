using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Pop : MonoBehaviour
{
    public float maxTimer;  //max timer
    public float timer;     //The actual timer
    public bool timerActive = false;  //Timer toggle

    public float submittedPower;    //Power to pass to the main game

    public string instructions; //Instructions to display to the player

    public bool canPop = true;

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI instructionsText;
    public Slider powerBar;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
        timerActive = true;
        instructionsText.text = instructions;
        UpdatePowerBar();
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        {
            if (timer > 0)
            {
                timer -= Time.deltaTime;
            }

            if (timer <= 0)
            {
                timerActive = false;    //turn off timer
                canPop = false;
                timer = 0;
                Debug.Log("return to main"); //return to main game
            }

            UpdateTimer();
        }
    }

    public void AddPower(float value)
    {
        submittedPower += value;
        UpdatePowerBar();
    }

    public void UpdateTimer()
    {
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0}", seconds);
    }

    public void UpdatePowerBar()
    {
        powerBar.value = submittedPower;
    }
}
