using System.Collections;
using System.Collections.Generic;
using UnityEngine;

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

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
        timerActive = true;
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
            }
        }

        if ((Input.GetKeyDown(inputKey) || Input.GetKeyDown(inputKey2)) && timerActive)
        {
            power += powerInput;
        }
    }
}
