using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class yeet : MonoBehaviour
{
    public bool canYeet = false;
    public float yeetAngle;
    public float yeetForce;
    public Arrow arrow;

    Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrow = FindObjectOfType<Arrow>();
    }

    // Update is called once per frame
    void Update()
    {
        if (canYeet)
        {
            yeetAngle = arrow.GetAngle();
            yeetForce = Random.Range(0.1f, 10.0f) ; // TODO: Change to actually getting a value based on Minigames;
            YEET();
        }
    }
    public void YEET()
    {
        Vector2 yeetDir = new Vector2(
            yeetForce * Mathf.Cos(Mathf.Deg2Rad * yeetAngle),
            yeetForce * Mathf.Sin(Mathf.Deg2Rad * yeetAngle)
            );
        Debug.Log(yeetAngle);
        Debug.Log(yeetDir);
        rb.AddForce(yeetDir, ForceMode2D.Impulse);

        canYeet = false;
    }
}
