using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Roll : MonoBehaviour
{
    public float maxTimer;  //max timer
    public float timer;     //The actual timer
    public bool timerActive = false;  //Timer toggle

    public float submittedPower;    //Power to pass to the main game

    public string instructions; //Instructions to display to the player

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
            }

            if (timer <= 0)
            {
                timerActive = false;    //turn off timer
                Debug.Log("return to main"); //return to main game
            }
        }
    }

    public void UpdatePower(float newPower)
    {
        submittedPower = newPower;
    }
}
