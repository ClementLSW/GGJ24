using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlingDetectionZone : MonoBehaviour
{
    public float powerGain;
    public GameObject manager;
    public Fling script;

    // Start is called before the first frame update
    void Start()
    {
        script = manager.GetComponent<Fling>();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (script.submittedPower < 1)
        {
            script.AddPower(powerGain);
        }

        Destroy(collision.gameObject);
    }
}
