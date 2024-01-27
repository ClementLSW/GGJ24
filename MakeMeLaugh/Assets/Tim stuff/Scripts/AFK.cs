using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class AFK : MonoBehaviour
{
    public float maxTimer;  //max timer
    public float timer;     //The actual timer
    public bool timerActive = false;  //Timer toggle

    public float power;     
    public float submittedPower;    //Power to pass to the main game
    public float powerDecrease;     //Power to remove if anything is pressed

    public string instructions; //Instructions to display to the player

    public TextMeshProUGUI timerText;
    public TextMeshProUGUI instructionsText;
    public Slider powerBar;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
        timerActive = true;
        instructionsText.text = instructions;
    }

    // Update is called once per frame
    void Update()
    {
        if (timerActive)
        { 
            if (timer > 0) 
            { 
                timer -= Time.deltaTime;

                if (power < 0)
                {
                    power = 0;
                }

                
            }

            if (timer <= 0)
            {
                submittedPower = power;     //Determine the power to pass
                timerActive = false;    //turn off timer
                timer = 0;

                if (power < 0)
                {
                    power = 0;
                }
            }

            UpdateTimer();
        }

        if (Input.anyKeyDown)
        {
            power -= powerDecrease;
            UpdatePowerBar();
        }
    }

    public void UpdateTimer()
    {
        int seconds = Mathf.FloorToInt(timer % 60);
        timerText.text = string.Format("{0}", seconds);
    }

    public void UpdatePowerBar()
    {
        powerBar.value = power;
    }
}
