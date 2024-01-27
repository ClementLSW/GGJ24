using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class yeet : MonoBehaviour
{
    public bool canYeet = false;
    public float yeetAngle;
    public float yeetForce;
    public Arrow arrow;
    public int bouncesLeft = 3;

    private Tilemap tilemap;

    Rigidbody2D rb;
    // Start is called before the first frame update
    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        arrow = FindObjectOfType<Arrow>();
        tilemap = FindObjectOfType<Tilemap>();
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

    private void OnCollisionEnter2D(Collision2D collision)
    {
        // Check if the collision is with the Tilemap
        if (collision.gameObject.GetComponent<TilemapCollider2D>() == tilemap.GetComponent<TilemapCollider2D>())
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
            }
            else
            {
                bouncesLeft--;
            }

        }
    }
}
