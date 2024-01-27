using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Mashing : MonoBehaviour
{
    public KeyCode inputKey;
    public KeyCode inputKey2;

    public float maxTimer;  //max timer
    public float timer;     //The actual timer
    public bool timerActive = false;  //Timer toggle

    public float power; //The bar
    public float powerInput;    //Power per press
    public float powerDecrease;     //Powere decrease over time
    public float submittedPower;    //Power to pass to the main game

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

                if (power > 0)
                {
                    power -= powerDecrease;
                    UpdatePowerBar();


                    if (power < 0)
                    {
                        power = 0;
                    }
                }
            }

            if (timer <= 0)
            {
                submittedPower = power;     //Determine the power to pass
                timerActive = false;    //turn off timer
                timer = 0;
            }

            UpdateTimer();
        }

        if ((Input.GetKeyDown(inputKey) || Input.GetKeyDown(inputKey2)) && timerActive)
        {
            power += powerInput;
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
