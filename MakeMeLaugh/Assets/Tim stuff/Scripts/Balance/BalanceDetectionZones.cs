using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BalanceDetectionZones : MonoBehaviour
{
    public float power;

    public GameObject manager;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag != "NoDetect")
        {
            manager.GetComponent<Balance>().UpdatePower(power);
        }

    }
}
