using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RPS : MonoBehaviour
{
    public float maxTimer;  //max timer
    public float timer;     //The actual timer
    public bool timerActive = false;  //Timer toggle

    public float submittedPower;    //Power to pass to the main game

    public string instructions; //Instructions to display to the player

    public int godsPick;

    //For ref, 1 is rock, 2 is paper, 3 is scissors

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer;
        timerActive = true;
        godsPick = Random.Range(1, 4);  //Return a val from 1-3
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
                submittedPower = 0;
                Debug.Log("return to main"); //return to main game if no choice is made
            }
        }
    }

    public void PickOne()   //This represents picking rock
    {
        if (godsPick == 1)  //Tie
        {
            submittedPower = 0.5f;
            timerActive = false;    //turn off timer
            Debug.Log("return to main"); //return to main game
        }

        if (godsPick == 2)  //lose
        {
            submittedPower = 0;
            timerActive = false;    //turn off timer
            Debug.Log("return to main"); //return to main game
        }

        if (godsPick == 3)  //win
        {
            submittedPower = 1;
            timerActive = false;    //turn off timer
            Debug.Log("return to main"); //return to main game
        }
    }

    public void PickTwo() 
    {
        if (godsPick == 1)  //Win
        {
            submittedPower = 1f;
            timerActive = false;    //turn off timer
            Debug.Log("return to main"); //return to main game
        }

        if (godsPick == 2)  //tie
        {
            submittedPower = 0.5f;
            timerActive = false;    //turn off timer
            Debug.Log("return to main"); //return to main game
        }

        if (godsPick == 3)  //lose
        {
            submittedPower = 0;
            timerActive = false;    //turn off timer
            Debug.Log("return to main"); //return to main game
        }
    }

    public void PickThree() 
    {
        if (godsPick == 1)  //lose
        {
            submittedPower = 0f;
            timerActive = false;    //turn off timer
            Debug.Log("return to main"); //return to main game
        }

        if (godsPick == 2)  //win
        {
            submittedPower = 1;
            timerActive = false;    //turn off timer
            Debug.Log("return to main"); //return to main game
        }

        if (godsPick == 3)  //tie
        {
            submittedPower = 0.5f;
            timerActive = false;    //turn off timer
            Debug.Log("return to main"); //return to main game
        }
    }

}
