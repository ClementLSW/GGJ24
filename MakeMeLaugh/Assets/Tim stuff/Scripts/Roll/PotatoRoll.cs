using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PotatoRoll : MonoBehaviour
{
    public float rotationTorque;

    void FixedUpdate()
    {
        #region Movement

            //Applying force to character for movement
            float inputX = Input.GetAxis("Horizontal");
            if (inputX != 0)
            {
                GetComponent<Rigidbody2D>().AddTorque(rotationTorque * -inputX);
            }

        #endregion
    }
}
