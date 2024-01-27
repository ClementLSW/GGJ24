using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CamFollow : MonoBehaviour
{
    public Transform target; // The target object to follow
    public float dampening = 5f; // The smoothness of the camera follow
    public Vector3 offset;/* = new Vector3(0f, 2f, -5f);*/ // The offset from the target

    private void Start()
    {
        offset =  transform.position - target.position;
    }

    void Update()
    {
        if (target == null)
        {
            Debug.LogError("Camera follow target is not set!");
            return;
        }

        // Calculate the desired position based on the target's position and offset
        Vector3 desiredPosition = new Vector3(target.position.x + offset.x, target.position.y + offset.y, transform.position.z);


        // Use Mathf.Lerp to smoothly interpolate between the current position and the desired position
        Vector3 smoothedPosition = Vector3.Lerp(transform.position, desiredPosition, Time.deltaTime * dampening);

        // Update the camera's position
        transform.position = smoothedPosition;
    }
}
