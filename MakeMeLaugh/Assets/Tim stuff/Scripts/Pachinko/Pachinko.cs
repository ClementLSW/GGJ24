using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pachinko : MonoBehaviour
{
    public GameObject potato;

    public float maxTimer;  //max timer
    public float timer;     //The actual timer
    public bool timerActive = false;  //Timer toggle

    public float power;
    public float submittedPower;    //Power to pass to the main game

    public bool movementActive = true;
    public float moveSpeed;
    public float maxDistance;
    public Vector3 movementvector;

    public string instructions; //Instructions to display to the player

    public bool timeoutTimerActive = false;
    public float timeoutTimer;
    public float maxTimeoutTimer;

    // Start is called before the first frame update
    void Start()
    {
        timer = maxTimer; 
        timerActive = true;
        movementvector = new Vector3(moveSpeed, 0, 0);
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
                movementActive = false;
                submittedPower = power;     //Determine the power to pass
                timerActive = false;    //turn off timer
                potato.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                timeoutTimer = maxTimeoutTimer;
                timeoutTimerActive = true;
            }
        }

        if (movementActive)
        {
            if (Input.GetKey(KeyCode.A))
            {
                potato.transform.position -= movementvector;
            }

            if (Input.GetKey(KeyCode.D))
            {
                potato.transform.position += movementvector;
            }
        }

        if (timeoutTimerActive)
        {
            if (timeoutTimer > 0)
            { 
                timeoutTimer -= Time.deltaTime;
            }

            if (timeoutTimer <= 0)
            {
                UpdatePower(0f);
            }
        }
    }

    public void UpdatePower(float newPower)
    { 
        submittedPower = newPower;
        Debug.Log("return to main"); //return to main game
    }
}
