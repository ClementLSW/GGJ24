using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Target : MonoBehaviour
{
    public float popValue;  //Power per pop

    public GameObject manager;
    public Pop script;


    private void Start()
    {
        script = manager.GetComponent<Pop>();
    }

    private void OnMouseDown()
    {
        if (script.canPop == true)
        {
            script.AddPower(popValue);
            Destroy(this.gameObject);
        }

    }
}
