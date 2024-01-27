using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Arrow : MonoBehaviour
{
    public bool allowInput = true;
    bool swing = false;
    float thetaDelta = 90.0f;

    float maxTheta = 80.0f;
    float minTheta = 0.0f;

    float dir = 1.0f;
    public GameObject potat;

    private void Awake()
    {
        potat = GameObject.Find("Potat"); //KEKW DigiPen level code btw
    }

    // Update is called once per frame
    void Update()
    {
        // Get Input
        if (allowInput)
        {
            if(Input.GetKeyDown(KeyCode.Space))
            {
                Debug.Log("Start Swing");
                swing = true;
            }else if(Input.GetKeyUp(KeyCode.Space))
            { 
                swing = false;
                potat.GetComponent<yeet>().canYeet = true;
            }else if (Input.GetKeyDown(KeyCode.R))
            {
                Reset();
            }
        }

        // When i need to swing
        if (swing)
        {
            Debug.Log("swing");

            //currentTheta += dir * thetaDelta * Time.deltaTime;
            //transform.RotateAround(transform.position, Vector3.forward, dir * thetaDelta * Time.deltaTime);
            float newz = transform.localEulerAngles.z + dir * thetaDelta * Time.deltaTime;
            transform.rotation = Quaternion.Euler(0, 0, Mathf.Clamp(newz, minTheta, maxTheta));
            
            // Change Directions of swing
            if (transform.localEulerAngles.z >= maxTheta)
            {
                dir = -1.0f;
            }

            if (transform.localEulerAngles.z <= minTheta)
            {
                dir = 1.0f;
            }
        }
    }

    public void Reset()
    {
        transform.rotation = Quaternion.Euler(Vector3.zero);
    }

    public float GetAngle()
    {
        return transform.localEulerAngles.z;
    }
}
