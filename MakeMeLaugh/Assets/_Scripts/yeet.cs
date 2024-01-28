using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class yeet : MonoBehaviour
{
    private Vector3 origin;
    public bool canYeet = false;
    public bool hasYeeted = false;
    public float yeetAngle;
    public float yeetForce;
    public Arrow arrow;
    public int bouncesLeft = 3;

    private Tilemap tilemap;
    GameMaster gm;
    Rigidbody2D rb;

    private void Awake()
    {
        gm = FindObjectOfType<GameMaster>();
    }
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrow = FindObjectOfType<Arrow>();
        tilemap = FindObjectOfType<Tilemap>();
        origin = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if (canYeet)
        {
            yeetAngle = arrow.GetAngle();
            //yeetForce = Random.Range(1.0f, 10.0f) ; // TODO: Change to actually getting a value based on Minigames;
            YEET();
        }
    }

    public void SetYeetForce(float val)
    {
        Debug.Log($"Force set to {val}");
        yeetForce = val;
    }

    public void YEET()
    {
        yeetForce *= 10;
        float YOTED_V = (1.0f + (0.2f * gm.BootLevel)) * yeetForce;

        Vector2 yeetDir = new Vector2(
            YOTED_V * Mathf.Cos(Mathf.Deg2Rad * yeetAngle),
            YOTED_V * Mathf.Sin(Mathf.Deg2Rad * yeetAngle)
            );
        Debug.Log(yeetAngle);
        Debug.Log(YOTED_V);
        Debug.Log(yeetDir);
        rb.AddForce(yeetDir, ForceMode2D.Impulse);
        rb.AddTorque(-YOTED_V);

        canYeet = false;
        hasYeeted = true;
    }

    public void ResetPotat()
    {
        gameObject.transform.position = origin;
        hasYeeted = false;
        canYeet = false;
        yeetAngle = 0.0f;
        yeetForce = 0.0f;
        bouncesLeft = 3;
        arrow.Reset();
        gameObject.SetActive(true);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        
        if (hasYeeted)
        {
            Debug.Log("Bounces left :" + (bouncesLeft - 1).ToString());
            // Check if the collision is with the Tilemap
            if (collision.gameObject.name.Equals("Farm"))
            {
                if(bouncesLeft<=0)
                {
                    // Get the contact point of the collision
                    ContactPoint2D contactPoint = collision.contacts[0];

                    // Convert the contact point to the world position
                    Vector3 hitPosition = tilemap.GetCellCenterWorld(tilemap.WorldToCell(contactPoint.point));

                    // Output the tile information
                    Debug.Log("Collided with tile at position: " + hitPosition);
                    rb.velocity = Vector2.zero; rb.angularVelocity = 0;

                    FindAnyObjectByType<Planter>().Plant(hitPosition);

                    gameObject.SetActive(false);
                }
                else
                {
                    bouncesLeft--;
                }
            }
        }
    }
}
